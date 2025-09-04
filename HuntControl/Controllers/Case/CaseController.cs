using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HeyRed.Mime;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;
using HuntControl.WebUI.Models.Print.Case.Statement;
using Ionic.Zip;

namespace HuntControl.WebUI.Controllers.Case
{
    [ClientErrorHandler]
    [Authorize]
    public partial class CaseController : Controller
    {
        public ActionResult Main(string infoId)
        {
            if (String.IsNullOrEmpty(infoId))
            {
                return RedirectToAction("Cases", "Case");
            }
            var employee = repository.SprEmployees.Include(i => i.spr_employees_job_pos).SingleOrDefault(se => se.employees_login == User.Identity.Name);
            data_services_view_log model = new data_services_view_log
            {
                employees_fio = employee?.employees_fio ?? "",
                data_services_info_id = infoId,
                spr_employees_id = employee?.id ?? Guid.Empty,
                employees_job_pos_name = employee?.spr_employees_job_pos?.job_pos_name ?? "",
            };
            repository.Insert(model);
            ViewBag.InfoId = infoId;
            var serviceInfo = repository.FuncCaseServicesInfoGet(infoId);
            return View(serviceInfo);
        }



        public ActionResult Cases()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }

            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.SubServices = new SelectList(repository.SprServicesSubs.Where(e => e.is_remove != true).OrderBy(s => s.service_sub_name_small), "id", "service_sub_name_small");
            ViewBag.SubServiceStatuses = new SelectList(repository.SprServicesSubStatuses.OrderBy(s => s.status_name), "id", "status_name");
            ViewBag.SubServiceWayGets = new SelectList(repository.SprServicesSubWayGets.Where(e => e.is_remove != true).OrderBy(s => s.name_way), "id", "name_way");

            return View();
        }

        public ActionResult PartialTableCases(Guid? employeeId, string dateStart, string dateStop, Guid? subServiceId, short? subServiceStatusId, Guid? subServiceWayGetId)
        {
            DateTime dtStart = Convert.ToDateTime(dateStart);
            DateTime dtStop = Convert.ToDateTime(dateStop);
           
            var cases = repository.FuncCaseSelect(employeeId ?? Guid.Empty, dtStart, dtStop, subServiceId, subServiceStatusId, subServiceWayGetId);
            CaseViewModel model = new CaseViewModel
            {
                CaseSelectResultList = cases,
            };
            return PartialView(model);
        }
        public ActionResult ModalSearch(Guid? customerId, string search, int page = 1)
        {
            ViewBag.Search = search;
            ViewBag.CustomerId = customerId;
            var individuals = repository.FuncCustomerSelect(customerId ?? Guid.Empty, search ?? "");
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
                Search = search
            };
            return PartialView(model);
        }
        public ActionResult ModalShowSearchIndividualPage(Guid? customerId, string search, int page = 1)
        {
            ViewBag.Search = search;
            ViewBag.CustomerId = customerId;
            var individuals = customerId != null || !String.IsNullOrEmpty(search) ? repository.FuncCustomerSelect(customerId ?? Guid.Empty, search ?? "") : null;

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
                Search = search
            };
            return PartialView(model);
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Архив обращений ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|
        public ActionResult CaseArchive()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }

            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.SubServices = new SelectList(repository.SprServicesSubs.Where(e => e.is_remove != true).OrderBy(s => s.service_sub_name_small), "id", "service_sub_name_small");
            ViewBag.SubServiceStatuses = new SelectList(repository.SprServicesSubStatuses.OrderBy(s => s.status_name), "id", "status_name");
            ViewBag.SubServiceWayGets = new SelectList(repository.SprServicesSubWayGets.Where(e => e.is_remove != true).OrderBy(s => s.name_way), "id", "name_way");

            return View();
        }
        public ActionResult PartialTableCaseArchive(Guid? employeeId, Guid employeesIdExecution, string dateStart, string dateStop, Guid? subServiceId, short? subServiceStatusId, Guid? subServiceWayGetId)
        {
            DateTime dtStart = Convert.ToDateTime(dateStart);
            DateTime dtStop = Convert.ToDateTime(dateStop);

            var cases = repository.FuncCaseArchiveSelect(employeeId ?? Guid.Empty, employeesIdExecution, dtStart, dtStop, subServiceId, subServiceStatusId, subServiceWayGetId);
            CaseViewModel model = new CaseViewModel
            {
                CaseSelectResultList = cases,
            };
            return PartialView(model);
        }


        #endregion
        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Документы ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialDocuments(Guid serviceId)
        {
            ViewBag.ServiceId = serviceId;
            var documents = repository.FuncCaseServicesDocumentSelect(serviceId).OrderBy(o => o.out_type).ThenBy(o => o.out_document_name);
            return PartialView("CaseDetails/Documents/PartialDocuments", documents);
        }

        public ActionResult UploadDocument(string infoid, Guid documentid)
        {
            ViewBag.InfoId = infoid;
            ViewBag.DocumentId = documentid;
            return PartialView("CaseDetails/Documents/UploadDocument");
        }

        public ActionResult PartialTableDocumentFiles(Guid documentId)
        {
            var files = repository.FuncCaseServicesDocumentFileSelect(documentId);
            return PartialView("CaseDetails/Documents/PartialTableDocumentFiles", files);
        }

        public FileResult SubmitDocumentFileDownload(Guid documentFileId, string documentFileName, string documentFileExt, string infoId)
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

            byte[] newFileData = ftp.OpenFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, documentFileId + documentFileExt, "Cases/" + infoId);




            var mimeType = MimeTypesMap.GetMimeType(documentFileExt);
            return File(newFileData, mimeType, documentFileName + documentFileExt);
        }

        protected byte[] fileByte(Guid documentFileId, string documentFileName, string documentFileExt, string infoId)
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

            byte[] newFileData = ftp.OpenFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, documentFileId + documentFileExt, "Cases/" + infoId);
            return newFileData;
        }


        static string custName;
        public FileResult SubmitDocumentFilesDownload(Guid serviceId)
        {
            ViewBag.ServiceId = serviceId;
            var documents = repository.FuncCaseServicesDocumentSelect(serviceId).OrderBy(o => o.out_type).ThenBy(o => o.out_document_name);
            var documentsId = documents.Select(s => s.out_id).ToArray();
            

            ZipFile zip = new ZipFile(Encoding.GetEncoding(866));
            MemoryStream msZip = new MemoryStream();


            foreach (var item in documentsId)
                {
                    var files = repository.FuncCaseServicesDocumentFileSelect((Guid)item).ToArray();
                    for(int i = 0; i<files.Length;i++)
                        if (files == null)
                        {
                            continue;
                        }
                        else
                        {
                            byte[] file = fileByte((Guid)files[i].out_id, files[i].out_file_name, files[i].out_file_ext, files[i].out_data_services_info_id);


                        Stream stream = new MemoryStream(file);
                        zip.AddEntry($"{files[i].out_file_name}_{DateTime.Now.ToString("ssffffff")}{files[i].out_file_ext}", stream);

               
                    custName = files[i].out_customer_fio;
                    }
             
            }
            zip.Save(Response.OutputStream);
            Response.ContentType = "application/zip";
            return File(msZip, System.Net.Mime.MediaTypeNames.Application.Octet, custName + ".zip");
        }

        public ActionResult SubmitDocumentFileUpload(Guid? documentId, string infoId)
        {
            if (Request.Files.Count > 0)
            {
                var file = Request.Files[0];

                if (file != null && file.ContentLength > 0)
                {
                    var employee =
                        repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name);
                    data_services_file fileModel = new data_services_file
                    {
                        data_services_info_id = infoId,
                        data_services_table_id = documentId ?? Guid.Empty,
                        file_ext = Path.GetExtension(file.FileName),
                        file_name = Path.GetFileNameWithoutExtension(file.FileName),
                        file_size = file.ContentLength,
                        employees_fio = employee.employees_fio,
                        spr_employees_id = employee.id
                    };
                    repository.Insert(fileModel);
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

                    //считаем загруженный файл в массив
                    byte[] fileArray = new byte[file.ContentLength];
                    file.InputStream.Read(fileArray, 0, file.ContentLength);
                    ftp.FileSave(fileArray, ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder + "/Cases",
                        fileModel.id + fileModel.file_ext, infoId);
                    return Json(fileModel.id, JsonRequestBehavior.AllowGet);
                }
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Ошибка при добавлении файла", JsonRequestBehavior.AllowGet);
        }

        public string SubmitDocumentFileOpen(Guid documentFileId, string documentFileName, string documentFileExt, string infoId)
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
            byte[] fileData = ftp.OpenFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder + "/Cases", documentFileId + documentFileExt, infoId);
            return Convert.ToBase64String(fileData);
        }

        public ActionResult SubmitDocumentFileDelete(Guid documentFileId)
        {
            var file = repository.DataServicesFiles.SingleOrDefault(dsf => dsf.id == documentFileId);
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

            var statusFtp = ftp.RemoveFile(ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, documentFileId + file?.file_ext, "Cases/" + file?.data_services_info_id);
            if (statusFtp == FtpStatusCode.CommandOK || statusFtp == FtpStatusCode.FileActionAborted)
            {
                repository.Delete(file);
                return Json("Запись успешно удалена", JsonRequestBehavior.AllowGet);
            }

            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Json("Ошибка при удалении файла", JsonRequestBehavior.AllowGet);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Бланки ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialBlanks(Guid serviceId)
        {
            CaseDetailViewModel model = new CaseDetailViewModel
            {
                SprServicesSubFileFolderList = repository.DataServices.Where(ds => ds.id == serviceId).Join(repository.SprServicesSubFileFolders, ds => ds.spr_services_sub_id, ssff => ssff.spr_services_sub_id, (ds, ssff) => ssff)
            };
            return PartialView("CaseDetails/Blanks/PartialBlanks", model);
        }

        public ActionResult PartialTableBlankDocuments(Guid? folderId)
        {
            CaseDetailViewModel model = new CaseDetailViewModel
            {
                SprServicesSubFileList = repository.SprServicesSubFiles.Where(ssf => ssf.spr_services_sub_file_folder_id == folderId).Include(ssf => ssf.spr_standards_file),
            };
            return PartialView("CaseDetails/Blanks/PartialTableBlankDocuments", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Этапы  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Следующий этап
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalNextRouteStage(Guid serviceId)
        {
            var employeeId = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name).id;
            var routeStages = repository.FuncCaseServicesRoutesStageNextSelect(serviceId, employeeId);
            ViewBag.ServiceId = serviceId;
            ViewBag.Employees = new SelectList(repository.SprEmployees.Select(s => new { s.id, s.employees_fio, s.spr_employees_job_pos.job_pos_name }).OrderBy(s => s.employees_fio), "id", "employees_fio", "job_pos_name", 1);
            return PartialView("CaseDetails/RouteStages/PartialModalNextRouteStage", routeStages);
        }

        /// <summary>
        /// добавляет этап
        /// </summary>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitNextRouteStageSave(Guid? employeeId, int routeStageId, Guid serviceId, string comment)
        {
            var employeeIdFact = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name).id;
            var employee = employeeId != null ? repository.SprEmployees.SingleOrDefault(se => se.id == employeeId) : repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name);
            var infoId = repository.DataServices.SingleOrDefault(ds => ds.id == serviceId).data_services_info_id;
            data_services_routes_stage model = new data_services_routes_stage
            {
                data_services_id = serviceId,
                spr_employees_id = employee.id,
                spr_routes_stage_id = routeStageId,
                data_services_info_id = infoId,
                employees_fio = employee.employees_fio,
                employees_fio_fact = UserName,
                spr_employees_id_fact = employeeIdFact,
                commentt = comment
            };
            repository.Insert(model);
            return RedirectToAction("PartialTableRouteStages", new { serviceId });
        }

        public ActionResult PartialTableRouteStages(Guid serviceId)
        {
            var employeeId = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name)?.id ?? Guid.Empty;
            CaseDetailViewModel model = new CaseDetailViewModel
            {
                DataServiceId = serviceId,
                CaseServicesRoutesStageSelectResultList = repository.FuncCaseServicesRoutesStageSelect(serviceId, employeeId),
            };
            return PartialView("CaseDetails/RouteStages/PartialTableRouteStages", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Заявители  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddCustomer(Guid serviceId)
        {
            var infoId = repository.DataServices.SingleOrDefault(ds => ds.id == serviceId)?.data_services_info_id;
            ViewBag.IdentityDocuments = new SelectList(repository.SprDocumentIdentities.OrderBy(s => s.document_name), "id", "document_name");
            return PartialView("CaseDetails/Customers/PartialModalAddCustomer", new data_services_customer { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", data_services_id = serviceId, data_services_info_id = infoId });
        }

        /// <summary>
        /// Изменение данных заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditCustomer(Guid customerId)
        {
            ViewBag.IdentityDocuments = new SelectList(repository.SprDocumentIdentities.OrderBy(s => s.document_name), "id", "document_name");
            return PartialView("CaseDetails/Customers/PartialModalEditCustomer", repository.DataServicesCustomers.SingleOrDefault(dsc => dsc.id == customerId));
        }

        /// <summary>
        /// Сохраняет изменения или добавляет заявителя
        /// </summary>
        /// <param name="customer">объект заявителя</param>
        /// <returns>частичное представление таблицы "Животные"</returns>
        [HttpPost]
        public ActionResult SubmitCustomerSave(data_services_customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.id == Guid.Empty)
                {
                    customer.spr_services_sub_tr_id = 1912196;
                    customer.customer_type = 3;
                    repository.Insert(customer);
                }
                else
                {
                    customer.employees_fio_modifi = UserName;
                    repository.Update(customer);
                }
                return RedirectToAction("PartialTableCustomers", new { serviceId = customer.data_services_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="customerId">id животного</param>
        /// <returns>частичное представление таблицы "Животные"</returns>
        [HttpPost]
        public ActionResult SubmitCustomerDelete(Guid customerId)
        {
            var customer = repository.DataServicesCustomers.SingleOrDefault(dsc => dsc.id == customerId);
            repository.Delete(customer);
            return RedirectToAction("PartialTableCustomers", new { serviceId = customer.data_services_id });
        }

        public ActionResult PartialTableCustomers(Guid serviceId)
        {
            CaseDetailViewModel model = new CaseDetailViewModel
            {
                DataServicesCustomers = repository.DataServicesCustomers.Where(ds => ds.data_services_id == serviceId).Include(dsc => dsc.spr_services_sub_type_recipient),
                DataServiceId = serviceId
            };
            return PartialView("CaseDetails/Customers/PartialTableCustomers", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ СМЭВ  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Выполнение СМЭВ запроса
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalSmevRequest(Guid serviceId)
        {
            ViewBag.InfoId = repository.DataServices.SingleOrDefault(ds => ds.id == serviceId).data_services_info_id;
            var smevRequests = repository.FuncCaseServicesSmevRequestSelect(serviceId);
            return PartialView("CaseDetails/Smev/PartialModalSmevRequest", smevRequests);
        }
        /// <summary>
        /// Запрос ответа
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalSmevRequestAnsver(Guid id)
        {
            return PartialView("CaseDetails/Smev/PartialModalSmevRequestAnsver", id);
        }
        [HttpPost]
        public JsonResult GetServiceDocuments(string infoId)
        {
            var result = repository.FuncCaseServicesFileSelect(infoId);
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult PartialSmevRequestDataForm(int smevRequestId, string infoId)
        {
            var model = repository.DataServicesCustomers.SingleOrDefault(dsc => dsc.data_services_info_id == infoId && dsc.customer_type == 1);
            ViewBag.InfoId = infoId;
            ViewBag.ServiceId = model.data_services_id;
            var path = repository.SprSmevRequests.SingleOrDefault(ssr => ssr.id == smevRequestId)?.path;
            string smevPath = "~/Views/SmevTemplates/" + path;
            return PartialView(smevPath, new SmevRequestFormModel
            {
                CustomerName = model.customer_fio,
                DocumentBirthPlace = model.document_birth_place,
                DocumentNumber = model.document_number,
                CustomerSnils = model.customer_snils,
                DocumentBirthDate = model.document_birth_date,
                DocumentIssueDate = model.document_issue_date,
                DocumentSerial = model.document_serial,
                DocumentIssuePlace = model.document_issue_body,
                CustomerEmail = model.customer_email,
                CustomerInn = model.customer_inn,
                CustomerSex = model.customer_sex,
                CustomerTel1 = model.customer_tel1,
                CustomerTel2 = model.customer_tel2,
                DocumentCode = model.document_code,
                CustomerLegalAddress = model.customer_address
            });
        }

        /// <summary>
        /// Сохраняет изменения или добавляет заявителя
        /// </summary>
        /// <param name="customer">объект заявителя</param>
        /// <returns>частичное представление таблицы "Животные"</returns>
        [HttpPost]
        public ActionResult SubmitSmevRequestSave(data_services_customer customer)
        {
            if (ModelState.IsValid)
            {
                if (customer.id == Guid.Empty)
                {
                    customer.spr_services_sub_tr_id = 1912196;
                    customer.customer_type = 3;
                    repository.Insert(customer);
                }
                else
                {
                    repository.Update(customer);
                }
                return RedirectToAction("PartialTableCustomers", new { serviceId = customer.data_services_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="customerId">id животного</param>
        /// <returns>частичное представление таблицы "Животные"</returns>
        [HttpPost]
        public ActionResult SubmitSmevRequestDelete(Guid customerId)
        {
            var customer = repository.DataServicesCustomers.SingleOrDefault(dsc => dsc.id == customerId);
            repository.Delete(customer);
            return RedirectToAction("PartialTableCustomers", new { serviceId = customer.data_services_id });
        }

        public ActionResult PartialTableSmevRequests(Guid serviceId)
        {
            var employeeId = repository.SprEmployees.First(se => se.employees_login == User.Identity.Name).id;

            CaseDetailViewModel model = new CaseDetailViewModel
            {
                FuncSmevList = repository.FuncCaseServicesSmevSelect(serviceId, employeeId),
                DataServiceId = serviceId
            };
            return PartialView("CaseDetails/Smev/PartialTableSmevRequests", model);
        }

        ///// <summary>
        ///// Прикрепление к услуге
        ///// </summary>
        ///// <param name="customerId">id животного</param>
        ///// <returns>частичное представление таблицы "Животные"</returns>
        //[HttpPost]
        //public JsonResult jsonUploadSmevResult(data_services_file file_model, string string_byte)
        //{
        //    if (string_byte != String.Empty && UploadSmevDocument(file_model, string_byte) != Guid.Empty)
        //    {
        //        return Json(true, JsonRequestBehavior.AllowGet);
        //    }
        //    else
        //        return Json(false, JsonRequestBehavior.AllowGet);
        //}
        //public Guid UploadSmevDocument(data_services_file data_services_file, string image64)
        //{
        //    var employees = repository.SprEmployees.First(se => se.employees_login == User.Identity.Name);
        //    var data_services = repository.DataServices.Where(w => w.id == data_services_file.data_services_table_id).First();            
        //    //--
        //    data_services_file fileModel = new data_services_file
        //    {
        //        data_services_info_id = data_services.data_services_info_id,
        //        data_services_table_id = data_services.id,
        //        file_ext = ".jpg",
        //        file_name = Guid.NewGuid().ToString(),
        //        file_size = Convert.FromBase64String(image64).Length,
        //        employees_fio = employees.employees_fio,
        //        spr_employees_id = employees.id
        //    };

        //    repository.Insert(fileModel);
        //    data_services_file.spr_employees = null;

        //    var settings = repository.SprSettings.ToList();
        //    var ftpModel =
        //        new
        //        {
        //            ftpServer = settings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
        //            ftpFolder = settings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
        //            ftpLogin = settings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
        //            ftpPass =
        //                CRPassword.Encrypt(
        //                    settings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
        //        };

        //    FtpFileModel ftp = new FtpFileModel();
        //    ftp.FileSave(Convert.FromBase64String(image64), ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, fileModel.id + fileModel.file_ext, "Cases/" + fileModel.data_services_info_id);
        //    if (!ftp.FileSave(Convert.FromBase64String(image64), ftpModel.ftpServer, ftpModel.ftpLogin, ftpModel.ftpPass, ftpModel.ftpFolder, fileModel.id + fileModel.file_ext, "Cases/"+ fileModel.data_services_info_id))
        //    {
        //        repository.Delete(fileModel);
        //        throw new HttpException("Ошибка подключения к ФТП.");
        //        //return Guid.Empty;
        //    }
        //    else
        //    {
        //        return data_services_file.id;
        //    }

        //}
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Примечания  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|
        public ActionResult PartialTableCommentts(Guid serviceId)
        {
            var employee = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name);
            CaseDetailViewModel model = new CaseDetailViewModel
            {
                DataServicesCommentsList = repository.DataServicesComments.Where(dsc => dsc.data_services_id == serviceId).OrderBy(o => o.date_enter),
                DataServiceId = serviceId,
                DataServiceList = repository.DataServices.Where(s => s.id == serviceId),
                EmployeeId = employee.id
            };
            ViewBag.WayGetId = new Guid("15a759ba-e23f-4204-9866-c90ee79ce134");
            ViewBag.InfoId = repository.DataServices.SingleOrDefault(ds => ds.id == serviceId)?.data_services_info_id;
            return PartialView("CaseDetails/Comments/PartialTableComments", model);
        }

        public ActionResult SubmitCommentSave(data_services_commentt dataServicesCommentt, bool? epguCheck)
        {
            if (ModelState.IsValid)
            {
                var employee = repository.SprEmployees.Include(i => i.spr_employees_job_pos).Include(ii => ii.spr_employees_department).SingleOrDefault(se => se.employees_login == User.Identity.Name);

                if (dataServicesCommentt.id == Guid.Empty)
                {
                    dataServicesCommentt.employees_fio = employee?.employees_fio ?? "";
                    dataServicesCommentt.spr_employees_id = employee?.id ?? Guid.Empty;
                    dataServicesCommentt.date_enter = DateTime.Now;
                    if (epguCheck == true)
                    {
                        dataServicesCommentt.epgu = 2;
                    }
                    else
                    {
                        dataServicesCommentt.epgu = 0;
                    }
                    repository.Insert(dataServicesCommentt);
                }
                else
                {
                    var editComment = repository.DataServicesComments.Where(w => w.id == dataServicesCommentt.id).SingleOrDefault();
                    editComment.employees_fio_modifi = UserName;
                    editComment.commentt = dataServicesCommentt.commentt;
                    repository.Update(editComment);
                }
                return RedirectToAction("PartialTableCommentts", new { serviceId = dataServicesCommentt.data_services_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="commentId">id комментария</param>
        /// <returns>частичное представление таблицы </returns>
        [HttpPost]
        public ActionResult SubmitCommentDelete(Guid commentId, string comment)
        {
            data_services_commentt deletedComment = repository.DataServicesComments.SingleOrDefault(w => w.id == commentId);
            deletedComment.is_remove = true;
            deletedComment.date_remove = DateTime.Now;
            deletedComment.employees_fio_modifi = UserName;
            deletedComment.commentt_remove = comment;
            repository.Update(deletedComment);
            return RedirectToAction("PartialTableCommentts", new { serviceId = deletedComment.data_services_id });
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="commentId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCommentRecovery(Guid commentId)
        {
            data_services_commentt recoveryComment = repository.DataServicesComments.SingleOrDefault(w => w.id == commentId);
            recoveryComment.is_remove = false;
            repository.Update(recoveryComment);
            return RedirectToAction("PartialTableCommentts", new { serviceId = recoveryComment.data_services_id });
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ История изменений  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialTableChangeLogs(Guid serviceId, string search, int page = 1)
        {
            string dataServiceInfoId = repository.DataServices.SingleOrDefault(ds => ds.id == serviceId).data_services_info_id;
            ViewBag.ServiceId = serviceId;
            var dataChangeLogs = repository.DataChangeLogs.Where(dcv => dcv.data_services_info_id == dataServiceInfoId);
            dataChangeLogs = String.IsNullOrEmpty(search) ? dataChangeLogs :
                search.ToLower().Split().Aggregate(dataChangeLogs, (current, item) => current.Where(h => h.field_name_.ToLower().Contains(item) || h.table_name_.ToLower().Contains(item)));
            CaseDetailViewModel model = new CaseDetailViewModel
            {
                DataChangeLogList = dataChangeLogs.OrderByDescending(a => a.date_change).Skip((page - 1) * PageSize).Take(PageSize).ToList(),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = dataChangeLogs.Count()
                },
            };
            return PartialView("CaseDetails/ChangeLogs/PartialTableChangeLogs", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[ Печать  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialPrintStatement(Guid serviceId, string infoId)
        {
            ViewBag.InfoId = infoId;
            StatementModel model = new StatementModel
            {
                DataServiceCustomerList = repository.DataServicesCustomers.Where(w => w.data_services_info_id == infoId),
                StatementDocumentSelectList = repository.FuncStatementDocumentSelect(serviceId),
                StatementInfoGet = repository.FuncStatementInfoGet(infoId)
            };
            return PartialView("Print/Case/Statement/PartialPrintStatement", model);
        }

        public ActionResult PartialPrintStatementCancellation(Guid serviceId, string infoId)
        {
            ViewBag.InfoId = infoId;
            StatementModel model = new StatementModel
            {
                DataServiceCustomerList = repository.DataServicesCustomers.Where(w => w.data_services_info_id == infoId),
                StatementDocumentSelectList = repository.FuncStatementDocumentSelect(serviceId),
                StatementInfoGet = repository.FuncStatementInfoGet(infoId)
            };
            return PartialView("Print/Case/Statement/PartialPrintStatementCancellation", model);
        }

        #endregion
    }
}