using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using System.Net;
using HeyRed.Mime;
using System.Globalization;
using HuntControl.WebUI.Models.Print.Perms.Blanks;
using FastReport;
using FastReport.Export.Pdf;
using WebGrease.Css.Extensions;

namespace HuntControl.WebUI.Controllers.ApplicantPage
{
    [ClientErrorHandler]
    [Authorize]
    public class ApplicantPageController : Controller
    {
        private string UserName => Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
        public int PageSize = 7;

        #region Инициализация Repository
        private readonly IRepository repository;
        public ApplicantPageController(IRepository repo)
        {
            repository = repo;
        }
        #endregion


        public ActionResult Main(string search)
        {
            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                PageInfo = new PageInfo(),
                Search = search
            };
            return View(model);
        }

        public ActionResult PartialMain(Guid customerId)
        {
            ViewBag.CustomerId = customerId;
            ViewBag.CustomerName = repository.DataCustomers.SingleOrDefault(dc => dc.id == customerId).customer_name;
            var customerInfo = repository.FuncHuntingCustomerInfoGetDto(customerId);
            return PartialView(customerInfo);
        }

        public JsonResult GetIndividualPhoto(Guid customerId)
        {
            var customer = repository.DataCustomers.SingleOrDefault(dc => dc.id == customerId);
            if (customer.file_ext != null && customer.file_name != null)
            {
                var settings = repository.SprSettings.ToList();
                var ftpModel =
                    new
                    {
                        ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                        ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                        ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                        ftpPass = CRPassword.Encrypt(settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                    };
                FtpFileModel ftp = new FtpFileModel();
                byte[] fileData = ftp.OpenFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, customerId + customer.file_ext, "Individual_photos");
                if (fileData != null)
                    return Json("data:" + MimeTypes.GetMimeType(customer.file_ext) + ";base64, " + Convert.ToBase64String(fileData), JsonRequestBehavior.AllowGet);
            }
            return null;
        }

        public ActionResult PartialIndividualPage(Guid customerId)
        {
            // Получаем данные клиента
            var customer = repository.DataCustomers.SingleOrDefault(dc => dc.id == customerId);

            // Устанавливаем те же ViewBag данные, что и в PartialModalEditCustomer
            ViewBag.EmployeesAutorised = repository.SprSettings.FirstOrDefault(w => w.param_name == "employees_authorized");
            ViewBag.NameOrganization = repository.SprSettings.FirstOrDefault(w => w.param_name == "name_small_organization");
            ViewBag.SerialHuntingLic = repository.SprSettings.FirstOrDefault(w => w.param_name == "serial_hunting_lic");
            ViewBag.IndividualPhoto = GetIndividualPhoto(customerId)?.Data;

            // Получаем дополнительную информацию о клиенте
            var customerInfo = repository.FuncHuntingCustomerInfoGetDto(customerId);

            // Создаем модель, которая объединит все необходимые данные
            var model = new HuntingCustomerInfoGetResultDto
            {
                Customer = customer,
                CustomerInfo = customerInfo,
            };

            ViewBag.CustomerId = customerId;
            ViewBag.CustomerName = customer?.customer_name;

            return PartialView(model);
        }

        public ActionResult PartialIndividualList(Guid? customerId, string search, int page = 1)
        {
            ViewBag.Serach = search;
            ViewBag.CustomerId = customerId;
            var individuals = customerId != null || !String.IsNullOrEmpty(search) ? repository.FuncCustomerSelect(customerId ?? Guid.Empty, search ?? "") : null;
            if (individuals == null || individuals.Count() == 0)
                return null;

            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                CustomerSelectList = individuals.OrderBy(a => a.out_customer_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = individuals.Count()
                },
            };
            return PartialView("PartialIndividualList", model);
        }

        /// <summary>
        /// Добавление нового заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddCustomer(string docSerial, string docNumber)
        {
            ViewBag.EmployeesAutorised = repository.SprSettings.Where(w => w.param_name == "employees_authorized").First();
            ViewBag.NameOrganization = repository.SprSettings.Where(w => w.param_name == "name_small_organization").First();
            ViewBag.SerialHuntingLic = repository.SprSettings.Where(w => w.param_name == "serial_hunting_lic").First();
            CustomerAddModel model = new CustomerAddModel()
            {
                data_customer = new data_customer()
                {
                    doc_serial = docSerial, 
                    doc_number = docNumber
                },
                data_customer_hunting_lic = new data_customer_hunting_lic()
                {
                    issue_date = DateTime.Now,
                    reestr_date = DateTime.Now
                }
            };
            return PartialView("PartialModalAddCustomer", model);
        }

        /// <summary>
        /// Изменение данных заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditCustomer(Guid customerId)
        {

            ViewBag.EmployeesAutorised = repository.SprSettings.Where(w => w.param_name == "employees_authorized").First();
            ViewBag.NameOrganization = repository.SprSettings.Where(w => w.param_name == "name_small_organization").First();
            ViewBag.SerialHuntingLic = repository.SprSettings.Where(w => w.param_name == "serial_hunting_lic").First();
            ViewBag.IndividualPhoto = GetIndividualPhoto(customerId)?.Data;
            return PartialView("PartialModalEditCustomer", repository.DataCustomers.SingleOrDefault(s => s.id == customerId));
        }

        [HttpPost]
        public ActionResult SubmitCustomerEditSave(data_customer customer, HttpPostedFileBase uploadFile)
        {
            try
            {
                ModelState["employees_fio"].Errors.Clear();

                if (ModelState.IsValid)
                {
                    if (customer.id == Guid.Empty)
                    {
                        customer.employees_fio = UserName;
                        if (uploadFile != null)
                        {
                            customer.file_name = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                            customer.file_ext = Path.GetExtension(uploadFile.FileName);
                        }
                        repository.Insert(customer);
                    }
                    else
                    {
                        var editModel = repository.DataCustomers.SingleOrDefault(dc => dc.id == customer.id);
                        editModel.actual_address = customer.actual_address;
                        editModel.customer_name = customer.customer_name;
                        editModel.doc_serial = customer.doc_serial;
                        editModel.doc_number = customer.doc_number;
                        editModel.doc_code = customer.doc_code;
                        editModel.doc_issue_body = customer.doc_issue_body;
                        editModel.doc_issue_date = customer.doc_issue_date;
                        editModel.customer_name = customer.customer_name;
                        editModel.customer_sex = customer.customer_sex;
                        editModel.doc_birth_date = customer.doc_birth_date;
                        editModel.doc_birth_place = customer.doc_birth_place;
                        editModel.legal_address = customer.legal_address;
                        editModel.actual_address = customer.actual_address;
                        editModel.customer_snils = customer.customer_snils;
                        editModel.phone_number1 = customer.phone_number1;
                        editModel.phone_number2 = customer.phone_number2;
                        editModel.social_organization_info = customer.social_organization_info;
                        editModel.social_job_position = customer.social_job_position;
                        editModel.social_incapable = customer.social_incapable;
                        editModel.social_pensioner = customer.social_pensioner;
                        editModel.e_mail = customer.e_mail;

                        editModel.employees_fio_modifi = UserName;
                        if (uploadFile != null)
                        {
                            editModel.file_name = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                            editModel.file_ext = Path.GetExtension(uploadFile.FileName);
                        }
                        repository.Update(editModel);
                    }
                    var settings = repository.SprSettings.ToList();
                    var ftpModel =
                        new
                        {
                            ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                            ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                            ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                            ftpPass =
                                CRPassword.Encrypt(
                                    settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                        };

                    FtpFileModel ftp = new FtpFileModel();


                    if (uploadFile != null)
                    {
                        ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, customer.id + customer.file_ext, "Individual_photos");
                        //считаем загруженный файл в массив
                        byte[] fileArray = new byte[uploadFile.ContentLength];
                        uploadFile.InputStream.Read(fileArray, 0, uploadFile.ContentLength);
                        ftp.FileSave(fileArray, ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder,
                            customer.id + Path.GetExtension(uploadFile.FileName), "Individual_photos");
                    }

                    return RedirectToAction("PartialIndividualPage", new { customerId = customer.id });
                }
                throw new Exception("Ошибка валидации!");
            }
            catch (Exception ex)
            {
                return PartialView(ex);
            }
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="customerId">id</param>
        [HttpPost]
        public ActionResult SubmitCustomerDelete(Guid customerId, string comment)
        {
            data_customer deletedCustomer = repository.DataCustomers.SingleOrDefault(c => c.id == customerId);
            deletedCustomer.is_remove = true;
            deletedCustomer.date_remove = DateTime.Now;
            deletedCustomer.employees_fio_modifi = UserName;
            deletedCustomer.commentt_remove = comment;
            repository.Update(deletedCustomer);
            return Json("Запись успешно удалена", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет заявителя
        /// </summary>
        /// <param name="customer">объект заявителя</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCustomerSave(CustomerAddModel testModel, HttpPostedFileBase uploadFile)
        {
            ModelState["data_customer.employees_fio"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.employees_fio"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.serial_license"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.number_license"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.issue_date"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.reestr_date"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.employees_authorized"]?.Errors.Clear();
            ModelState["data_customer_hunting_lic.issue_body"]?.Errors.Clear();
            //ModelState["data_services_customer.document_place_stay_number"]?.Errors.Clear();
            //ModelState["data_services_customer.document_place_stay_date"]?.Errors.Clear();
            //ModelState["data_services_customer.document_place_stay_issue_body"]?.Errors.Clear();
            if (ModelState.IsValid)
            {
                if (testModel.data_customer.id == Guid.Empty)
                {
                    testModel.data_customer.employees_fio = UserName;
                    if (uploadFile != null)
                    {
                        testModel.data_customer.file_name = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                        testModel.data_customer.file_ext = Path.GetExtension(uploadFile.FileName);
                    }
                    repository.Insert(testModel.data_customer);
                }
                else
                {
                    var editModel = repository.DataCustomers.SingleOrDefault(dc => dc.id == testModel.data_customer.id);
                    editModel.actual_address = testModel.data_customer.actual_address;
                    editModel.customer_name = testModel.data_customer.customer_name;
                    editModel.doc_serial = testModel.data_customer.doc_serial;
                    editModel.doc_number = testModel.data_customer.doc_number;
                    editModel.doc_code = testModel.data_customer.doc_code;
                    editModel.doc_issue_body = testModel.data_customer.doc_issue_body;
                    editModel.doc_issue_date = testModel.data_customer.doc_issue_date;
                    editModel.customer_name = testModel.data_customer.customer_name;
                    editModel.customer_sex = testModel.data_customer.customer_sex;
                    editModel.doc_birth_date = testModel.data_customer.doc_birth_date;
                    editModel.doc_birth_place = testModel.data_customer.doc_birth_place;
                    editModel.legal_address = testModel.data_customer.legal_address;
                    editModel.actual_address = testModel.data_customer.actual_address;
                    editModel.customer_snils = testModel.data_customer.customer_snils;
                    editModel.phone_number1 = testModel.data_customer.phone_number1;
                    editModel.phone_number2 = testModel.data_customer.phone_number2;
                    editModel.social_organization_info = testModel.data_customer.social_organization_info;
                    editModel.social_job_position = testModel.data_customer.social_job_position;
                    editModel.social_incapable = testModel.data_customer.social_incapable;
                    editModel.social_pensioner = testModel.data_customer.social_pensioner;
                    editModel.e_mail = testModel.data_customer.e_mail;

                    editModel.employees_fio_modifi = UserName;
                    if (uploadFile != null)
                    {
                        editModel.file_name = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                        editModel.file_ext = Path.GetExtension(uploadFile.FileName);
                    }
                    repository.Update(editModel);
                }
                if (testModel.data_customer_hunting_lic?.number_license !=  null)
                {
                    data_customer_hunting_lic huntingLic = new data_customer_hunting_lic
                    {
                        data_customer_id = testModel.data_customer.id,
                        serial_license = testModel.data_customer_hunting_lic.serial_license,
                        number_license = testModel.data_customer_hunting_lic.number_license,
                        issue_date = testModel.data_customer_hunting_lic.issue_date,
                        reestr_date = testModel.data_customer_hunting_lic.reestr_date,
                        employees_authorized = testModel.data_customer_hunting_lic.employees_authorized,
                        issue_body = testModel.data_customer_hunting_lic.issue_body,
                        spr_employees_id = repository.SprEmployees.SingleOrDefault(s => s.employees_login == User.Identity.Name).id,
                        employees_fio = UserName
                    };
                    repository.Insert(huntingLic);
                }
                else
                {
                    testModel.data_customer_hunting_lic = null;
                }

                //if (testModel.data_services_customer != null)
                //{
                //    data_services_customer huntingLic = new data_services_customer
                //    {
                //        data_services_id = testModel.data_customer.id,
                //        document_place_stay_number = testModel.data_services_customer.document_place_stay_number,
                //        document_place_stay_date = testModel.data_services_customer.document_place_stay_date,
                //        document_place_stay_issue_body = testModel.data_services_customer.document_place_stay_issue_body,
                //        spr_employees_id = repository.SprEmployees.SingleOrDefault(s => s.employees_login == User.Identity.Name).id,
                //        employees_fio = UserName
                //    };
                //    repository.Insert(huntingLic);
                //}
                //else
                //{
                //    testModel.data_services_customer = null;
                //}

                var settings = repository.SprSettings.ToList();
                var ftpModel =
                    new
                    {
                        ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                        ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                        ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                        ftpPass =
                            CRPassword.Encrypt(
                                settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                    };

                FtpFileModel ftp = new FtpFileModel();


                if (uploadFile != null)
                {
                    ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, testModel.data_customer.id + testModel.data_customer.file_ext, "Individual_photos");
                    //считаем загруженный файл в массив
                    byte[] fileArray = new byte[uploadFile.ContentLength];
                    uploadFile.InputStream.Read(fileArray, 0, uploadFile.ContentLength);
                    ftp.FileSave(fileArray, ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder,
                        testModel.data_customer.id + Path.GetExtension(uploadFile.FileName), "Individual_photos");
                }

                return RedirectToAction("PartialIndividualPage", new { customerId = testModel.data_customer.id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет файл
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCustomerPhotoDelete(string fileName)
        {
            var settings = repository.SprSettings.ToList();
            var ftpModel =
                new
                {
                    ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                    ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                    ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                    ftpPass =
                        CRPassword.Encrypt(
                            settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                };

            FtpFileModel ftp = new FtpFileModel();
            ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, fileName, "Individual_photos");
            return Json("Файл успешно удален", JsonRequestBehavior.AllowGet);
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Охотничий билет  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialHuntingLic(Guid customerId)
        {
            ViewBag.CustomerId = customerId;
            return PartialView("HuntingLic/PartialHuntingLic");
        }

        /// <summary>
        /// Добавление охотничьего билета
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingLic(Guid customerId)
        {
            ViewBag.EmployeesAutorised = repository.SprSettings.Where(w => w.param_name == "employees_authorized").First();
            ViewBag.NameOrganization = repository.SprSettings.Where(w => w.param_name == "name_small_organization").First();
            ViewBag.SerialHuntingLic = repository.SprSettings.Where(w => w.param_name == "serial_hunting_lic").First();
            return PartialView("HuntingLic/PartialModalAddHuntingLic", new data_customer_hunting_lic { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", data_customer_id = customerId });
        }

        /// <summary>
        /// Изменение данных охотничьего билета
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingLic(Guid huntingLicId)
        {
            return PartialView("HuntingLic/PartialModalEditHuntingLic", repository.DataCustomerHuntingLics.SingleOrDefault(s => s.id == huntingLicId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет охотничий билет
        /// </summary>
        /// <param name="huntingLic">объект охотничьего билета</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingLicSave(data_customer_hunting_lic huntingLic)
        {
            if (ModelState.IsValid)
            {
                if (huntingLic.id == Guid.Empty)
                {
                    repository.Insert(huntingLic);
                }
                else
                {
                    huntingLic.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
                    repository.Update(huntingLic);
                }
                return RedirectToAction("PartialTableHuntingLics", new { customerId = huntingLic.data_customer_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="huntingLicId">id охотбилета</param>
        /// <returns>частичное представление таблицы </returns>
        [HttpPost]
        public ActionResult SubmitHuntingLicDelete(Guid huntingLicId)
        {
            data_customer_hunting_lic deleteHuntingLic = repository.DataCustomerHuntingLics.SingleOrDefault(dchl => dchl.id == huntingLicId);
            repository.Delete(deleteHuntingLic);
            return RedirectToAction("PartialTableHuntingLics", new { customerId = deleteHuntingLic.data_customer_id });
        }

        public ActionResult PartialTableHuntingLics(Guid customerId, int page = 1)
        {
            var huntingLics = repository.DataCustomerHuntingLics.Where(dch => dch.data_customer_id == customerId).OrderByDescending(o => o.issue_date);
            ViewBag.CustomerId = customerId;
            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                HuntingLicList = huntingLics,
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingLics.Count()
                },
            };
            return PartialView("HuntingLic/PartialTableHuntingLics", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Разрешение на охоту  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Получение списка групп видов
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        public ActionResult GetHuntingFarmGroupTypes(Guid huntingFarmId)
        {
            var currentDate = DateTime.Now.AddMonths(-6);

            var seasons = repository.SprSeasonOpens
                .Where(so => so.date_stop >= currentDate)
                .Join(repository.SprSeasons,
                    so => so.spr_season_id,
                    s => s.id,
                    (so, s) => new
                    {
                        season_id = s.id,
                        season_open_id = so.id,
                        season_name = s.season_name,
                        date_start = so.date_start,
                        date_stop = so.date_stop,
                        s_form_type_id = s.s_form_type_id
                    })
                .OrderBy(x => x.season_name)
                .ThenBy(x => x.date_start)
                .ToList();

            return Json(seasons, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Получение списка видов охоты
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        public ActionResult GetHuntingFarmHuntingTypes(Guid huntingFarmSeasonId)
        {
            var huntingTypes = repository.SprHuntingTypes
            .OrderBy(s => s.type_name)
            .Select(s => new {
                id = s.id,
                text = s.type_name
            }).ToList();
            return Json(huntingTypes, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Таблица Лимитов к животным
        /// </summary>
        /// <returns>частичное представление таблицы</returns>
        public ActionResult PartialTableAnimalLimits(Guid huntingFarmSeasonId, Guid huntingTypeId)
        {
            var animals = repository.SprSeasonOpenAnimals
            .Where(s => s.spr_season_open_id == huntingFarmSeasonId)
            .Join(repository.SprAnimals,
                s => s.spr_animal_id,
                ss => ss.id,
                (s, ss) => new HuntingLimitAnimalSelectResult
                {
                    out_spr_animal_id = ss.id,
                    out_animal_name = ss.animal_name,
                    out_limit_day = s.norm_day,
                    out_limit_season = s.norm_season,
                })
            .OrderBy(result => result.out_animal_name)
            .ToList();
            return PartialView("HuntingLic/HuntingLicPerm/PartialTableAnimalLimits", animals);
        }

        public ActionResult GetSeasonDates(Guid? seasonId)
        {
            if (seasonId == null || seasonId.Value == Guid.Empty)
            {
                return Json(new
                {
                    startDate = "",
                    endDate = ""
                }, JsonRequestBehavior.AllowGet);
            }

            var season = repository.SprHuntingFarmSeasons
                .FirstOrDefault(s => s.id == seasonId.Value);

            if (season != null)
            {
                return Json(new
                {
                    startDate = season.date_start.ToString("yyyy-MM-dd"),
                    endDate = season.date_stop.ToString("yyyy-MM-dd")
                }, JsonRequestBehavior.AllowGet);
            }

            return Json(new
            {
                startDate = "",
                endDate = ""
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Добавление разрешения на охоту
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddHuntingLicPerm(Guid customerId)
        {
            var huntingFarms = repository.SprHuntingFarms
            .OrderBy(s => s.hunting_farm_name)
            .Select(s => new {
                id = s.id,
                out_hunting_farm_name = s.hunting_farm_name
            })
            .ToList();

            var huntingLics = repository.DataCustomerHuntingLics
            .Where(d => d.data_customer_id == customerId && d.cancelled_date == null)
            .Select(d => new {
                out_data_customer_hunting_lic = d.id,
                out_serial_number_license = d.serial_license + " " + d.number_license
            }).ToList();

            var a = huntingFarms.ToList();

            var methodRemoves = repository.SprMethodRemoves
            .Where(mr => mr.is_remove != true)
            .OrderBy(mr => mr.method_name)
            .Select(mr => new {
                id = mr.id,
                text = mr.method_name
            })
            .ToList();

            ViewBag.HuntingLics = new SelectList(huntingLics, "out_data_customer_hunting_lic", "out_serial_number_license", huntingLics?.FirstOrDefault().out_data_customer_hunting_lic);
            ViewBag.HuntingFarms = new SelectList(huntingFarms.OrderBy(s => s.out_hunting_farm_name), "id", "out_hunting_farm_name");
            ViewBag.HuntingTypes = new SelectList(repository.SprHuntingTypes.Where(ht => ht.is_remove != true).ToList().OrderBy(s => s.type_name), "id", "type_name");
            ViewBag.MethodRemoves = new SelectList(methodRemoves, "id", "text");
            var employee = repository.SprEmployees.SingleOrDefault(s => s.id == new Guid("505c4cc2-3811-477b-8fd2-4850f50c178a"));//Идрисов Тимур Тагирович Начальник отдела
            var jobPos = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == employee.id).Select(s => new { s.spr_employees_job_pos.job_pos_name }).FirstOrDefault()?.job_pos_name;

            ViewBag.SprEmployees = new SelectList(repository.SprEmployees.OrderBy(o => o.employees_fio), "id", "employees_fio");
            return PartialView("HuntingLic/HuntingLicPerm/PartialModalAddHuntingLicPerm", new data_customer_hunting_lic_perm { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_employees_id = employee?.id ?? Guid.Empty, fio_given = employee?.employees_fio, job_pos_name = jobPos });
        }

        /// <summary>
        /// Изменение данных разрешения на охоту
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditHuntingLicPerm(Guid huntingLicPermId)
        {
            ViewBag.MethodRemoves = new SelectList(repository.SprMethodRemoves.OrderBy(s => s.method_name), "id", "method_name");
            Guid spr_employees_id = repository.DataCustomerHuntingLicPerms.FirstOrDefault(w => w.id == huntingLicPermId).spr_employees_id;
            ViewBag.SprEmployees = new SelectList(repository.SprEmployees.OrderBy(s => s.employees_fio), "id", "employees_fio", spr_employees_id);
            return PartialView("HuntingLic/HuntingLicPerm/PartialModalEditHuntingLicPerm", repository.DataCustomerHuntingLicPerms.SingleOrDefault(s => s.id == huntingLicPermId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет разрешение на охоту
        /// </summary>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingLicPermSave(data_customer_hunting_lic_perm huntingLicPerm, List<HuntingLimitAnimalSelectResult> animalLimits, Guid?[] hunting_farm_arr_id)
        {
            if (ModelState.IsValid)
            {
                if (huntingLicPerm.id == Guid.Empty && animalLimits != null && animalLimits.Any(a => a.out_spr_animal_id != null))
                {
                    var season = repository.SprHuntingFarmSeasons
                    .FirstOrDefault(s => s.id == huntingLicPerm.spr_hunting_farm_season_id);
                    // Заполняем date_start и date_stop из сезона
                    huntingLicPerm.date_start = huntingLicPerm.date_start;
                    huntingLicPerm.date_stop = huntingLicPerm.date_stop;

                    repository.Insert(huntingLicPerm);
                    foreach (var animalLimitModel in animalLimits)
                    {
                        if (animalLimitModel.out_spr_animal_id == null) continue;
                        //if (!(animalLimitModel.out_limit_day > 0) && !(animalLimitModel.out_limit_season > 0)) continue;
                        var model = new data_customer_hunting_lic_perm_animal
                        {
                            limit_day = animalLimitModel.out_limit_day ?? 0,
                            limit_season = animalLimitModel.out_limit_season ?? 0,
                            spr_animal_id = animalLimitModel.out_spr_animal_id ?? Guid.Empty,
                            employees_fio = UserName,
                            data_customer_hunting_lic_perm_id = huntingLicPerm.id,
                            animal_age = animalLimitModel.out_animal_age ?? 0,
                            animal_sex = animalLimitModel.out_animal_sex ?? 0,
                            date_start = animalLimitModel.out_date_start ?? DateTime.Now,
                            date_stop = animalLimitModel.out_date_stop ?? DateTime.Now,
                            spr_hunting_farm_season_id = huntingLicPerm?.spr_hunting_farm_season_id ?? Guid.Empty
                        };
                        repository.Insert(model);
                    }
                    if (hunting_farm_arr_id != null)
                    {
                        repository.Inserts(hunting_farm_arr_id.Select(item =>
                            new data_customer_hunting_lic_perm_hunting()
                            {
                                spr_hunting_farm_id = item,
                                data_customer_hunting_lic_perm_id = huntingLicPerm.id
                            }).ToList());
                    }
                }
                else
                {
                    huntingLicPerm.employees_fio_modifi = UserName;
                    repository.Update(huntingLicPerm);
                }

                return Json("Запись успешно сохранена", JsonRequestBehavior.AllowGet);
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="huntingLicPermId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingLicPermRecovery(Guid huntingLicPermId)
        {
            data_customer_hunting_lic_perm recoveryHuntingLicPerm = repository.DataCustomerHuntingLicPerms.SingleOrDefault(w => w.id == huntingLicPermId);
            recoveryHuntingLicPerm.is_remove = false;
            repository.Update(recoveryHuntingLicPerm);
            return Json("Запись успешно восстановлена", JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="huntingLicPermId">id разрешения</param>
        /// <returns>частичное представление таблицы </returns>
        [HttpPost]
        public ActionResult SubmitHuntingLicPermDelete(Guid huntingLicPermId, string comment)
        {
            data_customer_hunting_lic_perm deletedHuntingLicPerm = repository.DataCustomerHuntingLicPerms.SingleOrDefault(w => w.id == huntingLicPermId);
            data_customer_hunting_lic customerLic = repository.DataCustomerHuntingLics.SingleOrDefault(w => w.id == deletedHuntingLicPerm.data_customer_hunting_lic_id);
            deletedHuntingLicPerm.is_remove = true;
            deletedHuntingLicPerm.date_remove = DateTime.Now;
            deletedHuntingLicPerm.employees_fio_modifi = UserName;
            deletedHuntingLicPerm.commentt_remove = comment;
            repository.Update(deletedHuntingLicPerm);
            return RedirectToAction("PartialTableHuntingLicPerms", new { customerId = customerLic.data_customer_id });
            //return Json("Запись успешно удалена", JsonRequestBehavior.AllowGet);
        }
    public ActionResult PartialTableHuntingLicPerms(Guid customerId, bool isRemove = false, int page = 1)
        {
            ViewBag.HuntingFarmId = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name);
            ViewBag.IsRemove = isRemove;
            ViewBag.CustomerId = customerId;

            var huntingLicPerms = repository.FuncDataCustomerHuntingLicPermSelect(customerId).Where(x=>x.out_is_remove != true);
            ApplicantPermViewModel model = new ApplicantPermViewModel
            {
                dataCustomerInfoGetsList = huntingLicPerms.OrderBy(x=>x.out_set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingLicPerms.Count()
                },
            };
            return PartialView("HuntingLic/HuntingLicPerm/PartialTableHuntingLicPerms", model);
        }


        /// <summary>
        /// Лимиты на животного
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        //[HttpPost]
        public ActionResult PartialModalAnimalLimit(Guid huntingLicPermId, bool isRemove = false)
        {
            var model = repository.DataCustomerHuntingLicPermAnimals.Where(w => w.data_customer_hunting_lic_perm_id == huntingLicPermId).Include(w => w.spr_animal);
            model = !isRemove ? model.Where(w => w.is_remove != true) : model;
            ViewBag.HuntingLicPermId = huntingLicPermId;
            ViewBag.IsRemove = isRemove;
            return PartialView("HuntingLic/HuntingLicPerm/AnimalLimits/PartialModalAnimalLimit", model);
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="animalLimitId">id лимита</param>
        /// <returns>частичное представление таблицы </returns>
        [HttpPost]
        public ActionResult SubmitModalAnimalLimitDelete(Guid animalLimitId, string comment)
        {
            data_customer_hunting_lic_perm_animal deletedAnimalLimit = repository.DataCustomerHuntingLicPermAnimals.SingleOrDefault(w => w.id == animalLimitId);
            deletedAnimalLimit.is_remove = true;
            deletedAnimalLimit.date_remove = DateTime.Now;
            deletedAnimalLimit.employees_fio_modifi = UserName;
            deletedAnimalLimit.commentt_remove = comment;
            repository.Update(deletedAnimalLimit);
            return RedirectToAction("PartialModalAnimalLimit", new { huntingLicPermId = deletedAnimalLimit.data_customer_hunting_lic_perm_id, isRemove = true });
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="animalLimitId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitModalAnimalLimitRecovery(Guid animalLimitId)
        {
            data_customer_hunting_lic_perm_animal recoveryAnimalLimit = repository.DataCustomerHuntingLicPermAnimals.SingleOrDefault(w => w.id == animalLimitId);
            recoveryAnimalLimit.is_remove = false;
            repository.Update(recoveryAnimalLimit);
            return RedirectToAction("PartialModalAnimalLimit", new { huntingLicPermId = recoveryAnimalLimit.data_customer_hunting_lic_perm_id, isRemove = true });
        }

        /// <summary>
        /// Сохраняет изменения или добавления
        /// </summary>
        /// <param name="huntingLicPermAnimals">объект</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingFarmAnimalSave(List<data_customer_hunting_lic_perm_animal> huntingLicPermAnimals)
        {
            foreach (var huntingLicPermAnimal in huntingLicPermAnimals)
            {
                var model = repository.DataCustomerHuntingLicPermAnimals.SingleOrDefault(lpa => lpa.id == huntingLicPermAnimal.id);
                model.limit_day = huntingLicPermAnimal.limit_day;
                model.limit_season = huntingLicPermAnimal.limit_season;
                model.employees_fio_modifi = UserName;
                repository.Update(model);
            }
            return Json("Записи успешно сохранены.", JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Таблица Редактирования Лимитов к животным
        /// </summary>
        /// <returns>частичное представление таблицы</returns>
        public ActionResult PartialTableEditAnimalLimits(Guid huntingLicPermId)
        {
            var perm = repository.DataCustomerHuntingLicPerms.SingleOrDefault(w => w.id == huntingLicPermId);
            var huntingFarmSeasonId = perm?.spr_hunting_farm_season_id ?? Guid.Empty;
            var huntingTypeId = perm?.spr_hunting_type_id ?? Guid.Empty;
            var permAnimals = repository.DataCustomerHuntingLicPermAnimals.Where(w => w.data_customer_hunting_lic_perm_id == huntingLicPermId).ToList();
            var animals = repository.FuncHuntingLimitAnimalSelect(huntingFarmSeasonId, huntingTypeId).ToList().Where(w => permAnimals.All(pa => pa.spr_animal_id != w.out_spr_animal_id));
            ViewBag.HuntingLicPermId = huntingLicPermId;
            return PartialView("HuntingLic/HuntingLicPerm/AnimalLimits/PartialTableEditAnimalLimits", animals);
        }

        /// <summary>
        /// Добавление новых лимитов к старому разрешению на охоту
        /// </summary>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitEditAnimalLimit(List<HuntingLimitAnimalSelectResult> animalLimits, Guid huntingLicPermId, Guid huntingFarmSeasonId)
        {
            if (!ModelState.IsValid) throw new Exception("Ошибка валидации!");
            foreach (var animalLimitModel in animalLimits)
            {
                if (animalLimitModel.out_spr_animal_id == null) continue;
                if (!(animalLimitModel.out_limit_day > 0) && !(animalLimitModel.out_limit_season > 0)) continue;
                var model = new data_customer_hunting_lic_perm_animal
                {
                    limit_day = animalLimitModel.out_limit_day ?? 0,
                    limit_season = animalLimitModel.out_limit_season ?? 0,
                    spr_animal_id = animalLimitModel.out_spr_animal_id ?? Guid.Empty,
                    employees_fio = UserName,
                    data_customer_hunting_lic_perm_id = huntingLicPermId,
                    animal_age = animalLimitModel.out_animal_age ?? 0,
                    animal_sex = animalLimitModel.out_animal_sex ?? 0,
                    date_start = animalLimitModel.out_date_start ?? DateTime.Now,
                    date_stop = animalLimitModel.out_date_stop ?? DateTime.Now,
                    spr_hunting_farm_season_id = huntingFarmSeasonId
                };
                repository.Insert(model);
            }
            return RedirectToAction("PartialModalAnimalLimit", new { huntingLicPermId });
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Оплата на разрешение  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult TableHuntingLicPermPayments(Guid customerId, bool isRemove = false, int page = 1)
        {
            ViewBag.CustomerId = customerId;
            ViewBag.IsRemove = isRemove;
            var huntingLicPermPayments = repository.DataCustomerHuntingLicPermPayments.Where(hlpp => hlpp.data_customer_id == customerId).Include(a => a.spr_taxation);
            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                HuntingLicPermPaymentList = huntingLicPermPayments.OrderByDescending(a => a.payment_date_enter).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = huntingLicPermPayments.Count()
                },
            };
            return PartialView("HuntingLic/HuntingLicPermPayment/TableHuntingLicPermPayments", model);
        }

        [HttpPost]
        public ActionResult AddHuntingLicPermPayment(Guid customerId)
        {
            var userId = repository.SprEmployees.SingleOrDefault(s => s.employees_login == User.Identity.Name).id;
            ViewBag.Tax = new SelectList(repository.SprTaxations.OrderBy(s => s.tax_name), "id", "tax_name");
            return PartialView("HuntingLic/HuntingLicPermPayment/AddHuntingLicPermPayment", new data_customer_hunting_lic_perm_payment { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", data_customer_id = customerId, spr_employees_id = userId, payment_date_enter = DateTime.Now });
        }

        [HttpPost]
        public ActionResult EditHuntingLicPermPayment(Guid paymentId)
        {
            var userId = repository.SprEmployees.SingleOrDefault(s => s.employees_login == User.Identity.Name).id;
            ViewBag.Tax = new SelectList(repository.SprTaxations.OrderBy(s => s.tax_name), "id", "tax_name");
            return PartialView("HuntingLic/HuntingLicPermPayment/EditHuntingLicPermPayment", repository.DataCustomerHuntingLicPermPayments.SingleOrDefault(s => s.id == paymentId));
        }

        [HttpPost]
        public ActionResult SubmitHuntingLicPermPayment(data_customer_hunting_lic_perm_payment huntingLicPermPayment)
        {
            var hunting = repository.DataCustomers.SingleOrDefault(s => s.id == huntingLicPermPayment.data_customer_id);
            string[] customerFio = hunting.customer_name.Split();
            var docNumber = hunting.doc_number;
            var docSerial = hunting.doc_serial;
            if (ModelState.IsValid)
            {
                if (huntingLicPermPayment.id == Guid.Empty)
                {
                    if (huntingLicPermPayment.payment_type == 1)
                    {
                        huntingLicPermPayment.payment_purpose = "Госпошлина";
                    }
                    else
                    {
                        huntingLicPermPayment.payment_purpose = "Сбор";

                    }
                    huntingLicPermPayment.document_code = "01";
                    huntingLicPermPayment.document_number = docNumber;
                    huntingLicPermPayment.document_serial = docSerial;
                    huntingLicPermPayment.customer_last_name = customerFio[0];
                    huntingLicPermPayment.customer_first_name = customerFio[1];
                    huntingLicPermPayment.customer_middle_name = customerFio[2];

                    repository.Insert(huntingLicPermPayment);
                }
                return RedirectToAction("TableHuntingLicPermPayments", new { customerId = huntingLicPermPayment.data_customer_id });
            }
            throw new Exception("Ошибка валидации!");
        }


        [HttpPost]
        public ActionResult SubmitHuntingLicPermPaymentDelete(Guid huntingLicPermPaymentId)
        {
            data_customer_hunting_lic_perm_payment deletedHuntingLicPerm = repository.DataCustomerHuntingLicPermPayments.SingleOrDefault(w => w.id == huntingLicPermPaymentId);
            repository.Delete(deletedHuntingLicPerm);
            //deletedHuntingLicPerm.is_remove = true;
            //deletedHuntingLicPerm.date_remove = DateTime.Now;
            //repository.Update(deletedHuntingLicPerm);
            //return Json("Запись успешно удалена", JsonRequestBehavior.AllowGet);
            return RedirectToAction("TableHuntingLicPermPayments", new { customerId = deletedHuntingLicPerm.data_customer_id });
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Корешки  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Изменение
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalHuntingLicPermBack(Guid huntingLicPermId)
        {
            var huntingLicPermBack = repository.DataCustomerHuntingLicPermBacks.Include("data_customer_hunting_lic_perm_back_animal.spr_animal").SingleOrDefault(s => s.data_customer_hunting_lic_perm_id == huntingLicPermId) ??
                new data_customer_hunting_lic_perm_back { data_customer_hunting_lic_perm_id = huntingLicPermId, employees_fio = UserName, date_back = DateTime.Now };
            var animals = repository.FuncHuntingBackAnimalSelect(huntingLicPermId);
            ViewBag.Animals = animals;
            return PartialView("HuntingLic/HuntingLicPerm/HuntingLicPermBack/PartialModalHuntingLicPermBack", huntingLicPermBack);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет корешки
        /// </summary>
        /// <param name="huntingLicPermBack">объект корешка</param>
        /// <param name="huntingLicPermBackAnimals"></param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitHuntingLicPermBackSave(data_customer_hunting_lic_perm_back huntingLicPermBack, List<data_customer_hunting_lic_perm_back_animal> huntingLicPermBackAnimals)
        {
            if (huntingLicPermBack.id == Guid.Empty)
            {
                repository.Insert(huntingLicPermBack);
                foreach (var dataCustomerHuntingLicPermBackAnimal in huntingLicPermBackAnimals)
                {
                    dataCustomerHuntingLicPermBackAnimal.employees_fio = UserName;
                    dataCustomerHuntingLicPermBackAnimal.data_customer_hunting_lic_perm_back_id = huntingLicPermBack.id;
                    repository.Insert(dataCustomerHuntingLicPermBackAnimal);
                }
            }
            else
            {
                huntingLicPermBack.employees_fio_modifi = UserName;
                repository.Update(huntingLicPermBack);
                foreach (var dataCustomerHuntingLicPermBackAnimal in huntingLicPermBackAnimals)
                {
                    if (dataCustomerHuntingLicPermBackAnimal.id == null)
                    {
                        dataCustomerHuntingLicPermBackAnimal.employees_fio = UserName;
                        dataCustomerHuntingLicPermBackAnimal.data_customer_hunting_lic_perm_back_id = huntingLicPermBack.id;
                        repository.Insert(dataCustomerHuntingLicPermBackAnimal);
                    }
                    else
                    {
                        var updateModel = repository.DataCustomerHuntingLicPermBackAnimals.SingleOrDefault(s => s.id == dataCustomerHuntingLicPermBackAnimal.id);
                        updateModel.employees_fio_modifi = UserName;
                        updateModel.count_animal = dataCustomerHuntingLicPermBackAnimal.count_animal;
                        repository.Update(updateModel);
                    }
                }
            }
            var customerId = repository.DataCustomerHuntingLicPerms.Include(i => i.data_customer_hunting_lic).SingleOrDefault(w => w.id == huntingLicPermBack.data_customer_hunting_lic_perm_id).data_customer_hunting_lic.data_customer_id;
            return RedirectToAction("PartialTableHuntingLicPerms", new { customerId });
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Нарушения  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление нарушений
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddViolations(Guid customerId)
        {
            ViewBag.SprEmployees = new SelectList(repository.SprEmployees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.HuntingFarms = new SelectList(repository.SprHuntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            ViewBag.Violations = new SelectList(repository.SprViolations.Where(x => x.is_remove != true).OrderBy(s => s.violation_article), "id", "violation_article");
            ViewBag.SprDefinitionTypes = new SelectList(repository.SprDefinitionTypes.OrderBy(s => s.definition_name), "id", "definition_name");
            ViewBag.SprViolationsPart = new SelectList(repository.SprViolationsPart.OrderBy(s => s.part_), "id", "part_");
            ViewBag.DataCustomer = repository.DataCustomers.Where(w => w.id == customerId).First();
            ViewBag.SprBailliffs = new SelectList(repository.SprBailiffs.OrderBy(s => s.name_bailiffs), "id", "name_bailiffs");
            ViewBag.HeadManaging = repository.SprSettings.Where(w => w.param_name == "head_managing").First();
            ViewBag.HeadProtectionNature = repository.SprSettings.Where(w => w.param_name == "head_protection_nature").First();
            ViewBag.NameOrganization = repository.SprSettings.Where(w => w.param_name == "name_organization").First();
            ViewBag.SprOrganization = new SelectList(repository.SprOrganizations.OrderBy(s => s.name_organization), "id", "name_organization");
            ViewBag.HuntingLic = repository.DataCustomerHuntingLics.Where(w => w.data_customer_id == customerId).First();
            ViewBag.SprBailiffsResult = new SelectList(repository.SprBailiffsResult.OrderBy(s => s.result_name), "id", "result_name");
            ViewBag.SprOrganizationsResult = new SelectList(repository.SprOrganizationsResult.OrderBy(s => s.result_name), "id", "result_name");
            return PartialView("Violations/PartialModalAddViolations", new data_customer_violations { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", data_customer_id = customerId });
        }

        /// <summary>
        /// Изменение данных нарушения
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditViolations(Guid violationsId)
        {
            data_customer_violations dc = repository.DataCustomerViolations.Where(w => w.id == violationsId).Include(i => i.data_customer).First();
            spr_employees spr_emp = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == dc.pr_spr_employees_id).SingleOrDefault();
            ViewBag.SprEmployees = spr_emp != null ? new SelectList(repository.SprEmployees.OrderBy(s => s.employees_fio), "id", "employees_fio", spr_emp.id) : new SelectList(repository.SprEmployees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            spr_violations_part spr_vp = repository.SprViolationsPart.Include(i => i.spr_violations).Where(w => w.id == dc.pr_spr_violations_part_id).SingleOrDefault();
            ViewBag.Violations = spr_vp != null ? new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article", spr_vp.spr_violations.id) : new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article");

            ViewBag.HuntingFarms = new SelectList(repository.SprHuntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            ViewBag.SprDefinitionTypes = new SelectList(repository.SprDefinitionTypes.OrderBy(s => s.definition_name), "id", "definition_name");
            ViewBag.SprViolationsPart = new SelectList(repository.SprViolationsPart.OrderBy(s => s.part_), "id", "part_");
            ViewBag.SprBailliffs = new SelectList(repository.SprBailiffs.OrderBy(s => s.name_bailiffs), "id", "name_bailiffs");
            ViewBag.SprOrganization = new SelectList(repository.SprOrganizations.OrderBy(s => s.name_organization), "id", "name_organization");

            ViewBag.alSprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.al_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.defSprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.def_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.resSprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.res_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.al20SprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.al20_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.pr20SprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.pr20_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.baiSprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.bai_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.trSprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.tr_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.disSprEmployees = new SelectList(repository.SprEmployees, "id", "employees_fio", repository.SprEmployees.Where(w => w.id == dc.dis_spr_employees_id).SingleOrDefault()?.id);
            ViewBag.SprBailiffsResult = new SelectList(repository.SprBailiffsResult, "id", "result_name", repository.SprBailiffsResult.Where(w => w.id == dc.bai_spr_bailiffs_result_id).SingleOrDefault()?.id);
            ViewBag.SprOrganizationsResult = new SelectList(repository.SprOrganizationsResult, "id", "result_name", repository.SprOrganizationsResult.Where(w => w.id == dc.tr_spr_organization_result_id).SingleOrDefault()?.id);
            return PartialView("Violations/PartialModalEditViolations", repository.DataCustomerViolations.SingleOrDefault(s => s.id == violationsId));
        }


        /// <summary>
        /// Сохраняет изменнения или добавляет нарушения
        /// </summary>
        /// <param name="violations">объект нарушения</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitViolationsSave(data_customer_violations violations)
        {
            violations.employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? "";
            //if (ModelState.IsValid)
            //{
            if (violations.id == Guid.Empty)
            {
                repository.Insert(violations);
            }
            else
            {
                violations.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? "";
                repository.Update(violations);
            }
            return RedirectToAction("PartialTableViolations", new { customerId = violations.data_customer_id });
            //}
            //throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="violationsId">id нарушения</param>
        /// <returns>частичное представление таблицы </returns>
        [HttpPost]
        public ActionResult SubmitViolationsDelete(Guid violationsId)
        {
            var violations = repository.DataCustomerViolations.SingleOrDefault(v => v.id == violationsId);
            repository.Delete(violations);
            return RedirectToAction("PartialTableViolations", new { customerId = violations?.data_customer_id ?? Guid.Empty });
        }

        public ActionResult PartialTableViolations(Guid customerId, int page = 1)
        {
            //var violations = repository.DataCustomerViolations.Where(dcv => dcv.data_customer_id == customerId).Include(i=>i.data_customer_violations_file);
            var violations = repository.FuncCustomerViolationsSelect(customerId);
            ViewBag.CustomerId = customerId;
            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                ViolationList = violations.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = violations.Count()
                },
            };
            return PartialView("Violations/PartialTableViolations", model);
        }

        /// <summary>
        /// Документы
        /// </summary>
        /// <returns>частичное представление модального окна</returns>        
        public ActionResult PartialModalTableViolationsFileList(Guid violationsId, int page = 1)
        {
            var docs = repository.DataCustomerViolationsFile.Where(dcvf => dcvf.data_customer_violations_id == violationsId);
            ViewBag.DataCustomerViolationsId = violationsId;
            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                ViolationFileList = docs.OrderByDescending(a => a.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = docs.Count()
                },
            };
            return PartialView("Violations/PartialModalTableViolationsFile", model);
        }
        public FileResult FileDownload(Guid file_id)
        {
            var dcv_file = repository.DataCustomerViolationsFile.Where(f => f.id == file_id).First();
            var model = repository.FuncGetFtpSettings();
            Uri serverUri = new Uri(String.Format("ftp://{0}:{1}@{2}/{3}/{4}{5}", model.out_ftp_user, model.out_ftp_password, model.out_ftp_server, model.out_ftp_folder + "/Scan_violations", dcv_file.id, dcv_file.file_ext));
            WebClient request = new WebClient();
            byte[] newFileData = request.DownloadData(serverUri.ToString());
            var stream = new MemoryStream(newFileData);

            request.Dispose();
            return File(stream.ToArray(), MimeTypesMap.GetMimeType(dcv_file.file_ext), dcv_file.file_name + dcv_file.file_ext);
        }

        public Dictionary<string, string> GetMarksValue(Guid violation_id)
        {
            Dictionary<string, string> marks = new Dictionary<string, string>();
            data_customer_violations dcv = repository.DataCustomerViolations.Include(i => i.spr_violations_part.spr_violations).Where(w => w.id == violation_id).First();
            marks.Add(nameof(dcv.al20_date), dcv.al20_date != null ? dcv.al20_date.ToString().Substring(0, 10) : "");
            marks.Add("al20_date_min", dcv.al20_date != null ? ((DateTime)dcv.al20_date).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.al20_date_invitations), dcv.al20_date_invitations != null ? dcv.al20_date_invitations.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.al20_date_receiving), dcv.al20_date_receiving != null ? dcv.al20_date_receiving.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.al20_number), dcv.al20_number);

            marks.Add(nameof(dcv.al_date), dcv.al_date != null ? dcv.al_date.ToString().Substring(0, 10) : "");
            marks.Add("al_date_min", dcv.al_date != null ? ((DateTime)dcv.al_date).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.al_number), dcv.al_number);
            marks.Add(nameof(dcv.al_date_invitations), dcv.al_date_invitations != null ? dcv.al_date_invitations.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.al_date_receiving), dcv.al_date_receiving != null ? dcv.al_date_receiving.ToString().Substring(0, 10) : "");

            marks.Add(nameof(dcv.bai_address), dcv.bai_address);
            marks.Add(nameof(dcv.bai_attached), dcv.bai_attached);
            marks.Add(nameof(dcv.bai_date_sent), dcv.bai_date_sent != null ? dcv.bai_date_sent.ToString().Substring(0, 10) : "");
            marks.Add("bai_date_sent_dd", dcv.bai_date_sent?.ToString("dd"));
            marks.Add("bai_date_sent_MM", dcv.bai_date_sent?.ToString("MM"));
            marks.Add("bai_date_sent_yy", dcv.bai_date_sent?.ToString("yy"));
            marks.Add("bai_date_sent_min", dcv.bai_date_sent != null ? ((DateTime)dcv.bai_date_sent).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.bai_head), dcv.bai_head);
            marks.Add(nameof(dcv.bai_head_protection_nature), dcv.bai_head_protection_nature);
            marks.Add(nameof(dcv.bai_name_bailiffs), dcv.bai_name_bailiffs);
            marks.Add(nameof(dcv.bai_number), dcv.bai_number);

            marks.Add(nameof(dcv.def_date_definition), dcv.def_date_definition != null ? dcv.def_date_definition.ToString().Substring(0, 10) : "");
            marks.Add("def_date_definition_min", dcv.def_date_definition != null ? ((DateTime)dcv.def_date_definition).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.def_date_handing), dcv.def_date_handing != null ? dcv.def_date_handing.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.def_date_sent), dcv.def_date_sent != null ? dcv.def_date_sent.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.def_head_managing), dcv.def_head_managing);
            marks.Add(nameof(dcv.def_nomer), dcv.def_nomer);

            marks.Add(nameof(dcv.dis_basis_discontinued), dcv.dis_basis_discontinued);
            marks.Add(nameof(dcv.dis_date), dcv.dis_date != null ? dcv.dis_date.ToString().Substring(0, 10) : "");
            marks.Add("dis_date_min", dcv.dis_date != null ? ((DateTime)dcv.dis_date).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.dis_date_receiving), dcv.dis_date_receiving != null ? dcv.dis_date_receiving.ToString().Substring(0, 10) : "");
            marks.Add("dis_date_receiving_min", dcv.dis_date_receiving != null ? ((DateTime)dcv.dis_date_receiving).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.dis_date_receiving_copy), dcv.dis_date_receiving_copy != null ? dcv.dis_date_receiving_copy.ToString().Substring(0, 10) : "");
            marks.Add("dis_date_receiving_copy_min", dcv.dis_date_receiving_copy != null ? ((DateTime)dcv.dis_date_receiving_copy).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.dis_number), dcv.dis_number);

            marks.Add("part1", dcv.spr_violations_part != null ? dcv.spr_violations_part.spr_violations.violation_article : "");
            marks.Add("part2", dcv.spr_violations_part != null ? dcv.spr_violations_part.part_.ToString() : "");

            marks.Add(nameof(dcv.pl_date), dcv.pl_date?.ToString("f", CultureInfo.CreateSpecificCulture("ru-RU")));
            marks.Add(nameof(dcv.pl_place), dcv.pl_place);

            marks.Add(nameof(dcv.pr20_attached), dcv.pr20_attached);
            marks.Add(nameof(dcv.pr20_customer_address_legal), dcv.pr20_customer_address_legal);
            marks.Add(nameof(dcv.pr20_date), dcv.pr20_date != null ? dcv.pr20_date.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.pr20_date_receipt), dcv.pr20_date_receipt != null ? dcv.pr20_date_receipt.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.pr20_document), dcv.pr20_document);
            marks.Add(nameof(dcv.pr20_explanation), dcv.pr20_explanation);
            marks.Add(nameof(dcv.pr20_head_protection_nature), dcv.pr20_head_protection_nature);
            marks.Add(nameof(dcv.pr20_inn), dcv.pr20_inn);
            marks.Add(nameof(dcv.pr20_job_pos_name), dcv.pr20_job_pos_name);
            marks.Add(nameof(dcv.pr20_name_create), dcv.pr20_name_create);
            marks.Add(nameof(dcv.pr20_number), dcv.pr20_number);
            marks.Add(nameof(dcv.pr20_place), dcv.pr20_place);

            marks.Add(nameof(dcv.pr_address_consideration), dcv.pr_address_consideration);
            marks.Add(nameof(dcv.pr_article), dcv.pr_article);
            marks.Add(nameof(dcv.pr_attached), dcv.pr_attached);
            marks.Add(nameof(dcv.pr_birth_date), dcv.pr_birth_date != null ? dcv.pr_birth_date.ToString().Substring(0, 10) : "");
            marks.Add("pr_birth_date_year", dcv.pr_birth_date != null ? dcv.pr_birth_date.ToString().Substring(6, 4) : "");
            marks.Add(nameof(dcv.pr_birth_place), dcv.pr_birth_place);
            marks.Add(nameof(dcv.pr_citizenship), dcv.pr_citizenship);
            marks.Add(nameof(dcv.pr_customer_address), dcv.pr_customer_address);
            marks.Add(nameof(dcv.pr_customer_name), dcv.pr_customer_name);
            string[] customerFIO;
            string customerFIOini = "";
            if (dcv.pr_customer_name != null)
            {
                customerFIO = dcv.pr_customer_name.Split(' ');
                customerFIOini = customerFIO.Count() >= 3 ? customerFIO[0] + " " + customerFIO[1].Substring(0, 1).ToUpper() + ". " + customerFIO[2].Substring(0, 1).ToUpper() + "." : dcv.pr_customer_name;
            }
            marks.Add("pr_customer_name_ini", customerFIOini);
            marks.Add(nameof(dcv.pr_customer_phone_number), dcv.pr_customer_phone_number);
            marks.Add(nameof(dcv.pr_date_create), dcv.pr_date_create != null ? dcv.pr_date_create.ToString().Substring(0, 10) : "");
            marks.Add("pr_date_create_dd", dcv.pr_date_create?.ToString("dd"));
            marks.Add("pr_date_create_MM", dcv.pr_date_create?.ToString("MM"));
            marks.Add("pr_date_create_yy", dcv.pr_date_create?.ToString("yy"));
            marks.Add("pr_date_create_hh", dcv.pr_time_create?.ToString("hh"));
            marks.Add("pr_date_create_mm", dcv.pr_time_create?.ToString("mm"));
            marks.Add("pr_date_create_min", dcv.pr_date_create != null ? ((DateTime)dcv.pr_date_create).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add("pr_date_create_full", dcv.pr_date_create != null ? ((DateTime)dcv.pr_date_create).ToString("F", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г. __ ч. __ мин.");
            marks.Add("pr_date_create_time", dcv.pr_date_create != null ? dcv.pr_date_create.ToString().Substring(11, dcv.pr_date_create.ToString().Length - 11) : "");
            marks.Add(nameof(dcv.pr_date_examination), dcv.pr_date_examination.ToString());
            marks.Add("pr_date_examination_dd", dcv.pr_date_examination?.ToString("dd"));
            marks.Add("pr_date_examination_MM", dcv.pr_date_examination?.ToString("MM"));
            marks.Add("pr_date_examination_yy", dcv.pr_date_examination?.ToString("yy"));
            marks.Add("pr_date_examination_hh", dcv.pr_date_examination?.ToString("HH"));
            marks.Add("pr_date_examination_mm", dcv.pr_date_examination?.ToString("mm"));
            marks.Add("pr_date_examination_full", dcv.pr_date_examination != null ? ((DateTime)dcv.pr_date_examination).ToString("F", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г. __ ч. __ мин.");
            marks.Add(nameof(dcv.pr_date_in_ogm), dcv.pr_date_in_ogm != null ? dcv.pr_date_in_ogm.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.pr_date_law_violation), dcv.pr_date_law_violation != null ? ((DateTime)dcv.pr_date_law_violation).ToString("f", CultureInfo.CreateSpecificCulture("ru-RU")) : "");
            marks.Add(nameof(dcv.pr_date_receiving), dcv.pr_date_receiving != null ? dcv.pr_date_receiving.ToString().Substring(0, 10) : "");
            marks.Add("pr_date_receiving_dd", dcv.pr_date_receiving?.ToString("dd"));
            marks.Add("pr_date_receiving_MM", dcv.pr_date_receiving?.ToString("MM"));
            marks.Add("pr_date_receiving_yy", dcv.pr_date_receiving?.ToString("yy"));
            marks.Add("pr_date_receiving_min", dcv.pr_date_receiving != null ? ((DateTime)dcv.pr_date_receiving).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.pr_date_receiving_letter), dcv.pr_date_receiving_letter != null ? dcv.pr_date_receiving_letter.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.pr_dependent), dcv.pr_dependent);
            marks.Add(nameof(dcv.pr_description), dcv.pr_description);
            marks.Add(nameof(dcv.pr_document), dcv.pr_document);
            marks.Add(nameof(dcv.pr_explanation), dcv.pr_explanation);
            marks.Add(nameof(dcv.pr_gun), dcv.pr_gun);
            marks.Add(nameof(dcv.pr_gun_caliber), dcv.pr_gun_caliber);
            marks.Add(nameof(dcv.pr_gun_number), dcv.pr_gun_number);
            marks.Add(nameof(dcv.pr_gun_permission_date_stop), dcv.pr_gun_permission_date_stop != null ? dcv.pr_gun_permission_date_stop.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.pr_gun_permission_issued), dcv.pr_gun_permission_issued);
            marks.Add(nameof(dcv.pr_gun_permission_number), dcv.pr_gun_permission_number);
            marks.Add(nameof(dcv.pr_hunting_farm_name), dcv.pr_hunting_farm_name);
            marks.Add(nameof(dcv.pr_hunting_lic_issue_body), dcv.pr_hunting_lic_issue_body);
            marks.Add(nameof(dcv.pr_hunting_lic_issue_date), dcv.pr_hunting_lic_issue_date != null ? dcv.pr_hunting_lic_issue_date.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.pr_hunting_lic_number), dcv.pr_hunting_lic_number);
            marks.Add(nameof(dcv.pr_hunting_lic_serial), dcv.pr_hunting_lic_serial);
            marks.Add(nameof(dcv.pr_job_pos_name), dcv.pr_job_pos_name);
            marks.Add(nameof(dcv.pr_marital_status), dcv.pr_marital_status);
            marks.Add(nameof(dcv.pr_motor_transport), dcv.pr_motor_transport);
            //--
            var pr_create_employee = repository.SprEmployees.Where(w => w.id == dcv.pr_spr_employees_id_create);
            marks.Add(nameof(dcv.pr_name_create), pr_create_employee.Count() != 0 ? pr_create_employee.First().employees_fio : "");
            string[] pr_create_employeeFIO;
            string pr_create_employeeFIOini = "";
            if (pr_create_employee.Count() != 0)
            {
                pr_create_employeeFIO = pr_create_employee.First().employees_fio.Split(' ');
                pr_create_employeeFIOini = pr_create_employeeFIO.Count() >= 3 ? pr_create_employeeFIO[0] + " " + pr_create_employeeFIO[1].Substring(0, 1).ToUpper() + ". " + pr_create_employeeFIO[2].Substring(0, 1).ToUpper() + "." : pr_create_employee.First().employees_fio;
            }
            marks.Add("pr_name_create_ini", pr_create_employeeFIOini);
            //--
            marks.Add(nameof(dcv.pr_no_legal_products), dcv.pr_no_legal_products);
            marks.Add(nameof(dcv.pr_number_case), dcv.pr_number_case);
            marks.Add(nameof(dcv.pr_number_letter), dcv.pr_number_letter);
            marks.Add(nameof(dcv.pr_number_protocol), dcv.pr_number_protocol);
            marks.Add(nameof(dcv.pr_place_protocol), dcv.pr_place_protocol);
            marks.Add(nameof(dcv.pr_place_work), dcv.pr_place_work);
            marks.Add(nameof(dcv.pr_resistance), dcv.pr_resistance);
            marks.Add(nameof(dcv.pr_spr_hunting_farm_id), dcv.pr_spr_hunting_farm_id.ToString());
            marks.Add(nameof(dcv.pr_spr_violations_part_id), dcv.pr_spr_violations_part_id.ToString());
            marks.Add(nameof(dcv.pr_witnesses1), dcv.pr_witnesses1);
            string[] pr_witnesses1FIO;
            string pr_witnesses1FIOini = "";
            if (dcv.pr_witnesses1 != null)
            {
                pr_witnesses1FIO = dcv.pr_witnesses1.Split(' ');
                pr_witnesses1FIOini = pr_witnesses1FIO.Count() >= 3 ? pr_witnesses1FIO[0] + " " + pr_witnesses1FIO[1].Substring(0, 1).ToUpper() + ". " + pr_witnesses1FIO[2].Substring(0, 1).ToUpper() + "." : dcv.pr_witnesses1;
            }
            marks.Add("pr_witnesses1_ini", pr_witnesses1FIOini);
            marks.Add(nameof(dcv.pr_witnesses2), dcv.pr_witnesses2);
            string[] pr_witnesses2FIO;
            string pr_witnesses2FIOini = "";
            if (dcv.pr_witnesses2 != null)
            {
                pr_witnesses2FIO = dcv.pr_witnesses2.Split(' ');
                pr_witnesses2FIOini = pr_witnesses2FIO.Count() >= 3 ? pr_witnesses2FIO[0] + " " + pr_witnesses2FIO[1].Substring(0, 1).ToUpper() + ". " + pr_witnesses2FIO[2].Substring(0, 1).ToUpper() + "." : dcv.pr_witnesses2;
            }
            marks.Add("pr_witnesses2_ini", pr_witnesses2FIOini);

            marks.Add(nameof(dcv.res_amount_fine), dcv.res_amount_fine.ToString());
            marks.Add(nameof(dcv.res_amount_harm), dcv.res_amount_harm.ToString());
            marks.Add("res_amount_full", (dcv.res_amount_fine + dcv.res_amount_harm).ToString());
            marks.Add(nameof(dcv.res_date), dcv.res_date != null ? dcv.res_date.ToString().Substring(0, 10) : "");
            marks.Add("res_date_dd", dcv.res_date?.ToString("dd"));
            marks.Add("res_date_MM", dcv.res_date?.ToString("MM"));
            marks.Add("res_date_yy", dcv.res_date?.ToString("yy"));
            marks.Add("res_date_min", dcv.res_date != null ? ((DateTime)dcv.res_date).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.res_date_entry), dcv.res_date_entry != null ? dcv.res_date_entry.ToString().Substring(0, 10) : "");
            marks.Add("res_date_entry_min", dcv.res_date_entry != null ? ((DateTime)dcv.res_date_entry).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.res_date_handing), dcv.res_date_handing != null ? dcv.res_date_handing.ToString().Substring(0, 10) : "");
            marks.Add(nameof(dcv.res_date_receiving_letter), dcv.res_date_receiving_letter != null ? dcv.res_date_receiving_letter.ToString().Substring(0, 10) : "");
            marks.Add("res_date_receiving_letter_dd", dcv.res_date_receiving_letter?.ToString("dd"));
            marks.Add("res_date_receiving_letter_MM", dcv.res_date_receiving_letter?.ToString("MM"));
            marks.Add("res_date_receiving_letter_yy", dcv.res_date_receiving_letter?.ToString("yy"));
            marks.Add("res_date_receiving_letter_min", dcv.res_date_receiving_letter != null ? ((DateTime)dcv.res_date_receiving_letter).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.res_date_receiving), dcv.res_date_receiving != null ? dcv.res_date_receiving.ToString().Substring(0, 10) : "");
            marks.Add("res_date_receiving_dd", dcv.res_date_receiving?.ToString("dd"));
            marks.Add("res_date_receiving_MM", dcv.res_date_receiving?.ToString("MM"));
            marks.Add("res_date_receiving_yy", dcv.res_date_receiving?.ToString("yy"));
            marks.Add("res_date_receiving_min", dcv.res_date_receiving != null ? ((DateTime)dcv.res_date_receiving).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.res_date_receiving_copy), dcv.res_date_receiving_copy != null ? dcv.res_date_receiving_copy.ToString().Substring(0, 10) : "");
            marks.Add("res_date_receiving_copy_dd", dcv.res_date_receiving_copy?.ToString("dd"));
            marks.Add("res_date_receiving_copy_MM", dcv.res_date_receiving_copy?.ToString("MM"));
            marks.Add("res_date_receiving_copy_yy", dcv.res_date_receiving_copy?.ToString("yy"));
            marks.Add("res_date_receiving_copy_min", dcv.res_date_receiving_copy != null ? ((DateTime)dcv.res_date_receiving_copy).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.res_details_trust), dcv.res_details_trust);
            marks.Add(nameof(dcv.res_head_managing), dcv.res_head_managing);
            marks.Add(nameof(dcv.res_number), dcv.res_number);
            marks.Add(nameof(dcv.res_number_letter), dcv.res_number_letter);
            marks.Add(nameof(dcv.res_payment), dcv.res_payment == true ? "Да" : "Нет");
            marks.Add(nameof(dcv.res_payment_date), dcv.res_payment_date != null ? dcv.res_payment_date.ToString().Substring(0, 10) : "");
            marks.Add("res_payment_date_dd", dcv.res_payment_date?.ToString("dd"));
            marks.Add("res_payment_date_MM", dcv.res_payment_date?.ToString("MM"));
            marks.Add("res_payment_date_yy", dcv.res_payment_date?.ToString("yy"));
            marks.Add("res_payment_date_min", dcv.res_payment_date != null ? ((DateTime)dcv.res_payment_date).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");

            marks.Add(nameof(dcv.tr_date_sent), dcv.tr_date_sent != null ? dcv.tr_date_sent.ToString().Substring(0, 10) : "");
            marks.Add("tr_date_sent_min", dcv.tr_date_sent != null ? ((DateTime)dcv.tr_date_sent).ToString("D", CultureInfo.CreateSpecificCulture("ru-RU")) : "\u0022 __ \u0022 __________ ____ г.");
            marks.Add(nameof(dcv.tr_head_protection_nature), dcv.tr_head_protection_nature);
            marks.Add(nameof(dcv.tr_name_organization), dcv.tr_name_organization);
            marks.Add(nameof(dcv.tr_number), dcv.tr_number);
            marks.Add(nameof(dcv.tr_text), dcv.tr_text);

            return marks;
        }
        public FileResult ProtocolDownload(string path, string file_name, Guid violation_id)
        {
            //--документ--
            string s = Server.MapPath(path);
            var doc = new byte[0];
            doc = System.IO.File.ReadAllBytes(s);
            byte[] newFileData = doc;
            var stream = new MemoryStream(newFileData);
            //--Метки из базы--
            Dictionary<string, string> marks_value = GetMarksValue(violation_id);
            //--заполнение меток--
            using (WordprocessingDocument document = WordprocessingDocument.Open(stream, true))
            {
                Body documentBody = document.MainDocumentPart.Document.Body;
                List<Paragraph> paragraphsWithMarks = documentBody.Descendants<Paragraph>().Where(x => System.Text.RegularExpressions.Regex.IsMatch(x.InnerText, @".*\[\w+\].*")).ToList();
                foreach (Paragraph paragraph in paragraphsWithMarks)
                {
                    foreach (System.Text.RegularExpressions.Match markMatch in System.Text.RegularExpressions.Regex.Matches(paragraph.InnerText, @"\[\w+\]", System.Text.RegularExpressions.RegexOptions.Compiled))
                    {
                        string paragraphMarkValue = markMatch.Value.Trim(new[] { '[', ']' });
                        if (marks_value.TryGetValue(paragraphMarkValue, out string markValueFromCollection))
                        {
                            string editedParagraphText = paragraph.InnerText.Replace(markMatch.Value, markValueFromCollection);
                            paragraph.RemoveAllChildren<DocumentFormat.OpenXml.Wordprocessing.Run>();
                            paragraph.AppendChild<DocumentFormat.OpenXml.Wordprocessing.Run>(new DocumentFormat.OpenXml.Wordprocessing.Run(new DocumentFormat.OpenXml.Wordprocessing.Text(editedParagraphText)));
                        }
                    }
                }
            }
            stream.Close();
            return File(stream.ToArray(), "application/vnd.openxmlformats-officedocument.wordprocessingml.document", file_name + ".docx");
        }
        [HttpPost]
        public ActionResult SubmitViolationsFileSave(data_customer_violations_file dcv_file, HttpPostedFileBase uploadFile)
        {
            if (uploadFile != null)
            {
                dcv_file.data_customer_violations_id = dcv_file.data_customer_violations_id;
                dcv_file.file_name = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                //if (ModelState.IsValid)
                //{
                if (dcv_file.id == Guid.Empty)
                {
                    dcv_file.employees_fio = UserName;
                    if (uploadFile != null)
                    {

                        dcv_file.file_ext = Path.GetExtension(uploadFile.FileName);
                        dcv_file.file_size = (int)uploadFile.ContentLength / 1024;

                    }
                    repository.Insert(dcv_file);
                }
                else
                {
                    dcv_file.employees_fio_modifi = UserName;
                    if (uploadFile != null)
                    {
                        dcv_file.file_name = Path.GetFileNameWithoutExtension(uploadFile.FileName);
                        dcv_file.file_ext = Path.GetExtension(uploadFile.FileName);
                    }
                    repository.Update(dcv_file);
                }

                var settings = repository.SprSettings.ToList();
                var ftpModel =
                    new
                    {
                        ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                        ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                        ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                        ftpPass =
                            CRPassword.Encrypt(
                                settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                    };

                FtpFileModel ftp = new FtpFileModel();

                if (uploadFile != null)
                {
                    ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, dcv_file.id + dcv_file.file_ext, "Scan_violations");
                    //считаем загруженный файл в массив
                    byte[] fileArray = new byte[uploadFile.ContentLength];
                    uploadFile.InputStream.Read(fileArray, 0, uploadFile.ContentLength);
                    ftp.FileSave(fileArray, ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder,
                        dcv_file.id + Path.GetExtension(uploadFile.FileName), "Scan_violations");
                }
                return RedirectToAction("PartialModalTableViolationsFileList", new { violationsId = dcv_file.data_customer_violations_id });
                //}
                //    throw new Exception("Ошибка валидации!");
            }
            else
            {
                return RedirectToAction("PartialModalTableViolationsFileList", new { violationsId = dcv_file.data_customer_violations_id });
            }
        }
        public ActionResult SubmitViolationsFileDelete(Guid violationsfile_id)
        {
            var violations_file = repository.DataCustomerViolationsFile.SingleOrDefault(v => v.id == violationsfile_id);
            Guid violations_id = repository.DataCustomerViolationsFile.SingleOrDefault(v => v.id == violationsfile_id).data_customer_violations_id;
            repository.Delete(violations_file);
            return RedirectToAction("PartialModalTableViolationsFileList", new { violationsId = violations_id });
        }
        public JsonResult GetSprViolationsPart(Guid violations_id)
        {
            var result = repository.SprViolationsPart.Where(w => w.spr_violations_id == violations_id).Select(s => new { s.id, text = s.part_ });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSprBailiffs(Guid bailiffs_id)
        {
            var result = repository.SprBailiffs.Where(w => w.id == bailiffs_id).First();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSprOrganizations(Guid organization_id)
        {
            var result = repository.SprOrganizations.Where(w => w.id == organization_id).First();
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetSprEmployees(Guid employees_id)
        {
            var result = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Where(w => w.id == employees_id).Select(s => new { s.employees_fio, s.spr_employees_job_pos.job_pos_name }).First();
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  История изменений  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialTableChangeLogs(Guid customerId, string search, int page = 1)
        {
            ViewBag.CustomerId = customerId;
            ViewBag.Serach = search;
            var dataChangeLogs = repository.DataChangeLogs.Where(dcv => dcv.data_customer_id == customerId);
            dataChangeLogs = String.IsNullOrEmpty(search) ? dataChangeLogs :
                search.ToLower().Split().Aggregate(dataChangeLogs, (current, item) => current.Where(h => h.field_name_.ToLower().Contains(item) || h.table_name_.ToLower().Contains(item)));
            ApplicantPageViewModel model = new ApplicantPageViewModel
            {
                DataChangeLogList = dataChangeLogs.OrderByDescending(a => a.date_change).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = dataChangeLogs.Count()
                },
            };
            return PartialView("ChangeLogs/PartialTableChangeLogs", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Печать  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public enum DataTypeViolations
        {
            Protocol,
            Materials,
            Definition,
            Decree,
            Notification
        }
        public enum DataTypePerm
        {
            Perm,
            Blank
        }

        public ActionResult PartialPrintViolations(Guid dataViolationId, DataTypeViolations dataTypeViolations)
        {


            var model = repository.DataCustomerViolations.Include(i => i.data_customer.data_customer_hunting_lic).SingleOrDefault(dcv => dcv.id == dataViolationId);
            switch (dataTypeViolations)
            {
                case DataTypeViolations.Materials:
                    return PartialView("Print/Violations/PartialPrintMaterials", model);

                case DataTypeViolations.Protocol:
                    return PartialView("Print/Violations/PartialPrintProtocol", model);

                case DataTypeViolations.Notification:
                    return PartialView("Print/Violations/PartialPrintNotification", model);

                case DataTypeViolations.Definition:
                    return PartialView("Print/Violations/PartialPrintDefinition", model);

                case DataTypeViolations.Decree:
                    return PartialView("Print/Violations/PartialPrintDecree", model);
            }
            throw new Exception("Ошибка при печати!");
        }

        public ActionResult PartialPrintHuntingLicPerm(Guid permsId, int animalGroupTypeIdentity, DataTypePerm dataTypePerms, string seasonName, string castomerId, short blankSide = 1)
        {
            switch (dataTypePerms)
            {
                case DataTypePerm.Perm:
                    {
                        var model = repository.FuncGetHuntingLicPermsResult(permsId);
                        // Временно
                        if (castomerId == "93667f14-ed83-4b9c-8540-bd8297823d61")
                        {
                            var modell = new HuntingLicPermsResult {
                                out_head_services = "Гебекову К.Д.",
                                out_customer_name = "Касумов Мурад Абдурашидович",
                                out_address = "Республика Дагестан, г. Дербент, ул. Генерала Араблинского д. 17А",
                                out_doc_serial = "82 13",
                                out_doc_number = "382590",
                                out_doc_issue_body = "ТП УФМС России по Респ. Дагестан в Хунзахском районе от",
                                out_doc_issue_date = new DateTime(2013, 10, 18),
                                out_hunting_type_name = "спортивная и любительская охота",
                                out_season_name = "1 (одна) особь половозрастного дикого кабана, за исключением самок с приплодом текущего года",
                                out_date_start = new DateTime(2021, 6, 1),
                                out_date_stop = new DateTime(2021, 9, 30),
                                out_hunting_farm_name = "Общедоступные охотничьи угодья Дербентского, Табасаранского, Магарамкентского, Ахтынского, Курахского, Хивского, Селеман-Стальского, Рутульского районов",
                                out_hunting_lic_issue_date = new DateTime(2018, 1, 17),
                                out_hunting_lic_serial = "05",
                                out_hunting_lic_number = "№ 083864",
                                out_charge_ = 450,
                                out_tariff_ = 650,
                                out_employees_fio = model.out_employees_fio 
                            };
                            return PartialView("Print/Perms/PartialPrintPerm", modell);
                        }
                        // ========= 
                        return PartialView("Print/Perms/PartialPrintPerm", model);
                    }
                case DataTypePerm.Blank:

                    int formTypeId = repository.GetSeasonFormTypeIdByPermsId(permsId);

                    switch (formTypeId)
                    {
                        case 1: // Пушные
                            {
                                var model = new BlankViewModel<FormFurInfoResult>
                                {
                                    Model = repository.FuncFormFurInfo(permsId),
                                };
                                model.AnimalList = repository.FuncFormAnimalSelect(permsId);
                                return PartialView("Print/Perms/Blanks/Furs", model);
                            }
                        case 2: // Медведь
                            {
                                var model = repository.FuncFormBearInfo(permsId);
                                return PartialView("Print/Perms/Blanks/Bears", model);
                            }
                        case 3: // Копытные
                            {
                                var model = repository.FuncFormUngulateInfo(permsId);
                                return PartialView("Print/Perms/Blanks/Ungulates", model);
                            }
                        case 4: // Птица
                        default:
                            {
                                var model = new BlankViewModel<FormBirdInfoResult>
                                {
                                    Model = repository.FuncFormBirdInfo(permsId),
                                };
                                model.AnimalList = repository.FuncFormAnimalSelect(permsId);
                                model.AnimalList.ForEach(animal =>
                                {
                                    animal.out_limit_day = animal.out_limit_day == "-" ? "б/о" : animal.out_limit_day;
                                    animal.out_limit_season = animal.out_limit_season == "-" ? "б/о" : animal.out_limit_season;
                                });

                                // Временно
                                if (castomerId == "93667f14-ed83-4b9c-8540-bd8297823d61")
                                {
                                    var modelll = new FormBearInfoResult
                                    {
                                        out_animal_age = "",
                                        out_animal_name = "Кабан",
                                        out_animal_sex = null,
                                        out_customer_name = model.Model.out_customer_name,
                                        out_date_given = new DateTime(2021, 07, 05),
                                        out_date_start = new DateTime(2021, 06, 01),
                                        out_date_stop = new DateTime(2021, 09, 30),
                                        out_fio_given = "Джамалутдинов М. Г",
                                        out_hunting_farm_name = "Общедоступные охотничьи угодья Дербентского, Табасаранского, Магарамкентского, Ахтынского, Курахского, Хивского, Сулейман-Стальского, Рутульского районов",
                                        out_hunting_lic_issue_date = new DateTime(2018, 01, 17),
                                        out_hunting_lic_number = "083864",
                                        out_hunting_lic_serial = "05",
                                        out_hunting_type_name = "Любительская и спортивная охота",
                                        out_organization_name = "Минприроды РД",
                                        out_region_name = "Республика Дагестан",
                                    };
                                    return PartialView("Print/Perms/Blanks/Bears", modelll);
                                }

                                return PartialView("Print/Perms/Blanks/Birds", model);
                            }
                    }
            }
            throw new Exception("Ошибка при печати!");
        }

        private string FastReportPrint()
        {
            Report report = new Report();
            var path = AppDomain.CurrentDomain.BaseDirectory + "Content\\reports\\Birds.frx";
            report.Load(path);

            report.Prepare();

            PDFExport export = new PDFExport();
            using (MemoryStream ms = new MemoryStream())
            {
                export.Export(report, ms);
                ms.Flush();
                byte[] bytes = ms.ToArray();
                return Convert.ToBase64String(bytes, 0, bytes.Length);
            }
        }

        #endregion
    }
}