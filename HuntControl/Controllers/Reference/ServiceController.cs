using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    public partial class ReferenceController
    {

        public ActionResult Services()
        {
            return View("Services/Main");
        }



        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Услуги  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Добавление услуги
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddService()
        {
            ViewBag.ServiceTypes = new SelectList(repository.SprServicesTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/Services/PartialModalAddService", new spr_services { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " "});
        }

        /// <summary>
        /// Изменение данных услуги
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditService(Guid serviceId)
        {
            ViewBag.ServiceTypes = new SelectList(repository.SprServicesTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/Services/PartialModalEditService", repository.SprServices.SingleOrDefault(s => s.id == serviceId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет услугу
        /// </summary>
        /// <param name="service">объект услуги</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceSave(spr_services service)
        {
            if (ModelState.IsValid)
            {
                if (service.id == Guid.Empty)
                {
                    repository.Insert(service);
                }
                else
                {
                    service.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
                    repository.Update(service);
                }
                return RedirectToAction("PartialTableServices");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="serviceId">id услуги</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitServiceDelete(Guid serviceId)
        {
            spr_services deleteService = repository.SprServices.SingleOrDefault(sp => sp.id == serviceId);
            repository.Delete(deleteService);
            return RedirectToAction("PartialTableServices");
        }

        public ActionResult PartialTableServices(int page = 1)
        {
            var services = repository.SprServices.Include(s => s.spr_services_type);
            ServiceViewModel model = new ServiceViewModel
            {
                ServiceList = services.OrderBy(s => s.service_name_small).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = services.Count()
                },
            };
            return PartialView("Services/Services/PartialTableServices", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Подуслуги  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        /// <summary>
        /// Добавление услуги
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubService(Guid serviceId)
        {
            ViewBag.ServiceTypes = new SelectList(repository.SprServicesTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/SubServices/PartialModalAddSubService", new spr_services_sub { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_services_id = serviceId });
        }

        /// <summary>
        /// Изменение данных услуги
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSubService(Guid subServiceId)
        {
            return PartialView("Services/SubServices/PartialModalEditSubService", repository.SprServicesSubs.SingleOrDefault(s => s.id == subServiceId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет подуслугу
        /// </summary>
        /// <param name="subService">объект подуслуги</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceSave(spr_services_sub subService)
        {
            if (ModelState.IsValid)
            {
                if (subService.id == Guid.Empty)
                {
                    repository.Insert(subService);
                }
                else
                {
                    subService.employees_fio_modifi = UserName;
                    repository.Update(subService);
                }
                return RedirectToAction("PartialTableSubServices", new { serviceId = subService.spr_services_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceId">id подуслуги</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceDelete(Guid subServiceId)
        {
            spr_services_sub deleteSubService = repository.SprServicesSubs.SingleOrDefault(sss => sss.id == subServiceId);
            repository.Delete(deleteSubService);
            return RedirectToAction("PartialTableSubServices", new { serviceId = deleteSubService.spr_services_id });
        }

        public ActionResult PartialTableSubServices(Guid serviceId, int page = 1)
        {
            ViewBag.ServiceId = serviceId;
            var subServices = repository.SprServicesSubs.Where(s => s.spr_services_id == serviceId);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceList = subServices.OrderBy(s => s.service_sub_name_small).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServices.Count()
                },
            };
            return PartialView("Services/SubServices/PartialTableSubServices", model);
        }

        #endregion


        /////////////////////////////////////////////////////////////////// Дополнительно \\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\\

        public ActionResult PartialAdditionally(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            ViewBag.SubServiceName = repository.SprServicesSubs.SingleOrDefault(s => s.id == subServiceId)?.service_sub_name;

            return PartialView("Services/Additionally/PartialAdditionally");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Заявители  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceCustomer(Guid subServiceId)
        {
            ViewBag.TypeRecipients = new SelectList(repository.SprServicesSubTypeRecipients.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/Additionally/Customers/PartialModalAddSubServiceCustomer", new spr_services_sub_customer { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_services_sub_id = subServiceId });
        }

        /// <summary>
        /// Изменение данных заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSubServiceCustomer(Guid subServiceCustomerId)
        {
            ViewBag.TypeRecipients = new SelectList(repository.SprServicesSubTypeRecipients.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/Additionally/Customers/PartialModalEditSubServiceCustomer", repository.SprServicesSubCustomers.SingleOrDefault(ssc => ssc.id == subServiceCustomerId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет заявителя
        /// </summary>
        /// <param name="subServiceCustomer">объект заявителя</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceCustomerSave(spr_services_sub_customer subServiceCustomer)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceCustomer(subServiceCustomer);
                return RedirectToAction("PartialTableSubServiceCustomers", new { subServiceId = subServiceCustomer.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceCustomerId">id заявителя</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceCustomerDelete(Guid subServiceCustomerId)
        {
            spr_services_sub_customer deletedSubServiceCustomer = repository.DeleteSubServiceCustomer(subServiceCustomerId);
            return RedirectToAction("PartialTableSubServiceCustomers", new { subServiceId = deletedSubServiceCustomer.spr_services_sub_id });
        }


        public ActionResult PartialTableSubServiceCustomers(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var customers = repository.SprServicesSubCustomers.Where(ssc => ssc.spr_services_sub_id == subServiceId).Include(ssc => ssc.spr_services_sub_type_recipient);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceCustomerList = customers.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = customers.Count()
                },
            };
            return PartialView("Services/Additionally/Customers/PartialTableSubServiceCustomers", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Файлы и папки  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult PartialFiles(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            return PartialView("Services/Additionally/Files/PartialFiles");
        }

        /// <summary>
        /// Добавление папки
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceFolder(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            return PartialView("Services/Additionally/Files/Folders/PartialModalAddSubServiceFolder", new spr_services_sub_file_folder { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет папку
        /// </summary>
        /// <param name="subServiceFolder">объект папки</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceFolderSave(spr_services_sub_file_folder subServiceFolder)
        {
            if (ModelState.IsValid)
            {
                if (subServiceFolder.id == Guid.Empty)
                {
                    repository.Insert(subServiceFolder);
                }
                else
                {
                    subServiceFolder.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
                    repository.Update(subServiceFolder);
                }
                return RedirectToAction("PartialTableSubServiceFolders", new { subServiceId = subServiceFolder.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceFolderId">id папки</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceFolderDelete(Guid subServiceFolderId)
        {
            spr_services_sub_file_folder deletedSubServiceFolder = repository.SprServicesSubFileFolders.SingleOrDefault(ff => ff.id == subServiceFolderId);
            repository.Delete(deletedSubServiceFolder);
            return RedirectToAction("PartialTableSubServiceFolders", new { subServiceId = deletedSubServiceFolder.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceFolders(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceFolders = repository.SprServicesSubFileFolders.Where(ssff => ssff.spr_services_sub_id == subServiceId);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceFolderList = subServiceFolders.OrderByDescending(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceFolders.Count()
                },
            };
            return PartialView("Services/Additionally/Files/Folders/PartialTableSubServiceFolders", model);
        }

        public ActionResult PartialTableSubServiceFiles(Guid subServiceFolderId, int page = 1)
        {
            ViewBag.SubServiceFolderId = subServiceFolderId;
            var subServiceFiles = repository.SprServicesSubFiles.Where(ssf => ssf.spr_services_sub_file_folder_id == subServiceFolderId);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceFileList = subServiceFiles.OrderByDescending(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceFiles.Count()
                },
            };
            return PartialView("Services/Additionally/Files/Files/PartialTableSubServiceFiles", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Активность услуги  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление активность услуги
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceActivity(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            return PartialView("Services/Additionally/Activity/PartialModalAddSubServiceActivity", new spr_services_sub_active { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет активность услуги
        /// </summary>
        /// <param name="subServiceActivity">объект активности</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceActivitySave(spr_services_sub_active subServiceActivity)
        {
            if (ModelState.IsValid)
            {
                repository.Insert(subServiceActivity);
                return RedirectToAction("PartialTableSubServiceActivities", new { subServiceId = subServiceActivity.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceActivityId">id активности</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceActivityDelete(Guid subServiceActivityId)
        {
            spr_services_sub_active deleteSubServiceActive = repository.SprServicesSubActives.SingleOrDefault(sssa => sssa.id == subServiceActivityId);
            repository.Delete(deleteSubServiceActive);
            return RedirectToAction("PartialTableSubServiceActivities", new { subServiceId = deleteSubServiceActive.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceActivities(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceActivities = repository.SprServicesSubActives.Where(ssa => ssa.spr_services_sub_id == subServiceId);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceActiveList = subServiceActivities.OrderByDescending(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceActivities.Count()
                },
            };
            return PartialView("Services/Additionally/Activity/PartialTableSubServiceActivities", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Документы к услуге  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// документы к услуге
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceDocument(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            ViewBag.Documents = new SelectList(repository.SprDocuments.OrderBy(s => s.document_name), "id", "document_name");
            return PartialView("Services/Additionally/Documents/PartialModalAddSubServiceDocument", new spr_services_sub_document { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// документы к услуге
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSubServiceDocument(Guid subServiceDocumentId)
        {
            ViewBag.Documents = new SelectList(repository.SprDocuments.OrderBy(s => s.document_name), "id", "document_name");
            var model = repository.SprServicesSubDocuments.SingleOrDefault(sst => sst.id == subServiceDocumentId);
            model.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
            return PartialView("Services/Additionally/Documents/PartialModalEditSubServiceDocument", model);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет документ
        /// </summary>
        /// <param name="subServiceDocument">объект документа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceDocumentSave(spr_services_sub_document subServiceDocument)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceDocument(subServiceDocument);
                return RedirectToAction("PartialTableSubServiceDocuments", new { subServiceId = subServiceDocument.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceDocumentId">id документа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceDocumentDelete(Guid subServiceDocumentId)
        {
            spr_services_sub_document deletedSubServiceDocument = repository.DeleteSubServiceDocument(subServiceDocumentId);
            return RedirectToAction("PartialTableSubServiceDocuments", new { subServiceId = deletedSubServiceDocument.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceDocuments(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceDocuments = repository.SprServicesSubDocuments.Where(ssd => ssd.spr_services_sub_id == subServiceId).Include(ssd => ssd.spr_documents);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceDocumentList = subServiceDocuments.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceDocuments.Count()
                },
            };
            return PartialView("Services/Additionally/Documents/PartialTableSubServiceDocuments", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Результаты документов к услуге  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// результаты документов к услуге
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceResultDoc(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            ViewBag.Documents = new SelectList(repository.SprDocuments.OrderBy(s => s.document_name), "id", "document_name");
            return PartialView("Services/Additionally/Results/PartialModalAddSubServiceResultDoc", new spr_services_sub_result_doc { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// результаты документов к услуге
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSubServiceResultDoc(Guid subServiceResultDocId)
        {
            ViewBag.Documents = new SelectList(repository.SprDocuments.OrderBy(s => s.document_name), "id", "document_name");
            var model = repository.SprServicesSubResultDocs.SingleOrDefault(sst => sst.id == subServiceResultDocId);
            model.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
            return PartialView("Services/Additionally/Results/PartialModalEditSubServiceResultDoc", model);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет документ
        /// </summary>
        /// <param name="subServiceDocument">объект документа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceResultDocSave(spr_services_sub_result_doc subServiceResultDoc)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceResultDoc(subServiceResultDoc);
                return RedirectToAction("PartialTableSubServiceResultDocs", new { subServiceId = subServiceResultDoc.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceResultDocId">id документа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceResultDocDelete(Guid subServiceResultDocId)
        {
            spr_services_sub_result_doc deletedSubServiceResultDoc = repository.DeleteSubServiceResultDoc(subServiceResultDocId);
            return RedirectToAction("PartialTableSubServiceResultDocs", new { subServiceId = deletedSubServiceResultDoc.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceResultDocs(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceResultDocs = repository.SprServicesSubResultDocs.Where(ssd => ssd.spr_services_sub_id == subServiceId).Include(ssd => ssd.spr_documents);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceResultDocList = subServiceResultDocs.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceResultDocs.Count()
                },
            };
            return PartialView("Services/Additionally/Results/PartialTableSubServiceResultDocs", model);
        }


        #endregion


        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Основание отказа приема документов  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление основания отказа приема документов
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceFailureDoc(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            return PartialView("Services/Additionally/FailureDocs/PartialModalAddSubServiceFailureDoc", new spr_services_sub_failure_doc { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение основания отказа приема документов
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSubServiceFailureDoc(Guid subServiceFailureDocId)
        {
            var model = repository.SprServicesSubFailureDocs.SingleOrDefault(sst => sst.id == subServiceFailureDocId);
            model.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
            return PartialView("Services/Additionally/FailureDocs/PartialModalEditSubServiceFailureDoc", model);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет основание отказа
        /// </summary>
        /// <param name="subServicesFailureDoc">объект отказа приема документов</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceFailureDocSave(spr_services_sub_failure_doc subServicesFailureDoc)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceFailureDoc(subServicesFailureDoc);
                return RedirectToAction("PartialTableSubServiceFailureDocs", new { subServiceId = subServicesFailureDoc.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceFailureDocId">id  отказа приема документов</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceFailureDocDelete(Guid subServiceFailureDocId)
        {
            spr_services_sub_failure_doc deletedSubServiceFailureDoc = repository.DeleteSubServiceFailureDoc(subServiceFailureDocId);
            return RedirectToAction("PartialTableSubServiceFailureDocs", new { subServiceId = deletedSubServiceFailureDoc.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceFailureDocs(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceFailureDocs = repository.SprServicesSubFailureDocs.Where(ssd => ssd.spr_services_sub_id == subServiceId);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceFailureDocList = subServiceFailureDocs.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceFailureDocs.Count()
                },
            };
            return PartialView("Services/Additionally/FailureDocs/PartialTableSubServiceFailureDocs", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Основание отказа предоставления услуги  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление основании отказа
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceFailure(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            return PartialView("Services/Additionally/Failures/PartialModalAddSubServiceFailure", new spr_services_sub_failure { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение основании отказа
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSubServiceFailure(Guid subServiceFailureId)
        {
            var model = repository.SprServicesSubFailures.SingleOrDefault(sst => sst.id == subServiceFailureId);
            model.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
            return PartialView("Services/Additionally/Failures/PartialModalEditSubServiceFailure", model);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет основание
        /// </summary>
        /// <param name="subServiceFailure">объект основании отказа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceFailureSave(spr_services_sub_failure subServiceFailure)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceFailure(subServiceFailure);
                return RedirectToAction("PartialTableSubServiceFailures", new { subServiceId = subServiceFailure.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceFailureId">id основании</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceFailureDelete(Guid subServiceFailureId)
        {
            spr_services_sub_failure deletedSubServiceFailure = repository.DeleteSubServiceFailure(subServiceFailureId);
            return RedirectToAction("PartialTableSubServiceFailures", new { subServiceId = deletedSubServiceFailure.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceFailures(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceFailures = repository.SprServicesSubFailures.Where(ssd => ssd.spr_services_sub_id == subServiceId);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceFailureList = subServiceFailures.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceFailures.Count()
                },
            };
            return PartialView("Services/Additionally/Failures/PartialTableSubServiceFailures", model);
        }


        #endregion


        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Способы обращения за услугой  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление способа обращения за услугой
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceWayGet(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            ViewBag.WayGets = new SelectList(repository.SprServicesSubWayGets.OrderBy(s => s.name_way), "id", "name_way");
            return PartialView("Services/Additionally/WayGets/PartialModalAddSubServiceWayGet", new spr_services_sub_way_get_join { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет способ обращения
        /// </summary>
        /// <param name="subServiceWayGet">объект способа обращения за услугой</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceWayGetSave(spr_services_sub_way_get_join subServiceWayGet)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceWayGet(subServiceWayGet);
                return RedirectToAction("PartialTableSubServiceWayGets", new { subServiceId = subServiceWayGet.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceWayGetId">id способа обращения за услугой</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceWayGetDelete(Guid subServiceWayGetId)
        {
            spr_services_sub_way_get_join deletedSubServiceWayGet = repository.DeleteSubServiceWayGet(subServiceWayGetId);
            return RedirectToAction("PartialTableSubServiceWayGets", new { subServiceId = deletedSubServiceWayGet.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceWayGets(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceWayGets = repository.SprServicesSubWayGetJoins.Where(ssd => ssd.spr_services_sub_id == subServiceId).Include(i => i.spr_services_sub_way_get);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceWayGetList = subServiceWayGets.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceWayGets.Count()
                },
            };
            return PartialView("Services/Additionally/WayGets/PartialTableSubServiceWayGets", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Способы обращения за результатом услуги  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление способа обращения за результатом услуги 
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceWayGetResult(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            ViewBag.WayGetResults = new SelectList(repository.SprServicesSubWayGetResults.OrderBy(s => s.name_way), "id", "name_way");
            return PartialView("Services/Additionally/WayGetResults/PartialModalAddSubServiceWayGetResult", new spr_services_sub_way_get_result_join { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет способ обращения
        /// </summary>
        /// <param name="subServiceWayGetResult">объект способа обращения за результатом услуги </param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceWayGetResultSave(spr_services_sub_way_get_result_join subServiceWayGetResult)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceWayGetResult(subServiceWayGetResult);
                return RedirectToAction("PartialTableSubServiceWayGetResults", new { subServiceId = subServiceWayGetResult.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceWayGetResultId">id способа обращения за результатом услуги </param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceWayGetResultDelete(Guid subServiceWayGetResultId)
        {
            spr_services_sub_way_get_result_join deletedSubServiceWayGetResult = repository.DeleteSubServiceWayGetResult(subServiceWayGetResultId);
            return RedirectToAction("PartialTableSubServiceWayGetResults", new { subServiceId = deletedSubServiceWayGetResult.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceWayGetResults(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceWayGetResults = repository.SprServicesSubWayGetResultJoins.Where(ssd => ssd.spr_services_sub_id == subServiceId).Include(i => i.spr_services_sub_way_get_result);
            ServiceViewModel model = new ServiceViewModel
            {
                SubServiceWayGetResultList = subServiceWayGetResults.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceWayGetResults.Count()
                },
            };
            return PartialView("Services/Additionally/WayGetResults/PartialTableSubServiceWayGetResults", model);
        }


        #endregion

        /// <summary>
        /// Тарифы и документы заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalSettingSubServiceCustomer(Guid subServiceCustomerId)
        {
            ViewBag.SubServiceCustomerId = subServiceCustomerId;
            return PartialView("Services/Additionally/Customers/PartialModalSettingSubServiceCustomer");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Тарифы заявителя  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Тарифы и документы заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddCustomerTariff(Guid subServiceCustomerId)
        {
            ViewBag.SubServiceCustomerId = subServiceCustomerId;
            ViewBag.TariffTypes = new SelectList(repository.SprServicesSubTariffTypes.OrderBy(s => s.type_name), "id", "type_name");
            ViewBag.SubServiceWeeks = new SelectList(repository.SprServicesSubWeeks.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/Additionally/Customers/Tariffs/PartialAddCustomerTariff", new spr_services_sub_tariff { spr_services_sub_customer_id = subServiceCustomerId });
        }

        /// <summary>
        /// Тарифы и документы заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialEditCustomerTariff(Guid customerTariffId)
        {
            ViewBag.TariffTypes = new SelectList(repository.SprServicesSubTariffTypes.OrderBy(s => s.type_name), "id", "type_name");
            ViewBag.SubServiceWeeks = new SelectList(repository.SprServicesSubWeeks.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("Services/Additionally/Customers/Tariffs/PartialEditCustomerTariff", repository.SprServicesSubTariffs.SingleOrDefault(sst => sst.id == customerTariffId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет тариф
        /// </summary>
        /// <param name="customerTariff">объект тарифа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCustomerTariffSave(spr_services_sub_tariff customerTariff)
        {
            if (ModelState.IsValid)
            {
                if (customerTariff.id == Guid.Empty)
                {
                    repository.Insert(customerTariff);
                }
                else
                {
                    customerTariff.employees_fio_modifi = UserName;
                    repository.Update(customerTariff);
                }
                return RedirectToAction("PartialTableCustomerTariffs", new { subServiceCustomerId = customerTariff.spr_services_sub_customer_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Восстанавливает запись по указанному id
        /// </summary>
        /// <param name="customerTariffId">id</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCustomerTariffRecovery(Guid customerTariffId)
        {
            spr_services_sub_tariff recoveryCustomerTariff = repository.SprServicesSubTariffs.SingleOrDefault(w => w.id == customerTariffId);
            recoveryCustomerTariff.is_remove = false;
            repository.Update(recoveryCustomerTariff);
            return RedirectToAction("PartialTableCustomerTariffs", new { subServiceCustomerId = recoveryCustomerTariff.spr_services_sub_customer_id });
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="customerTariffId">id</param>
        /// <returns>частичное представление таблицы </returns>
        [HttpPost]
        public ActionResult SubmitCustomerTariffDelete(Guid customerTariffId, string comment)
        {
            spr_services_sub_tariff deletedCustomerTariff = repository.SprServicesSubTariffs.SingleOrDefault(w => w.id == customerTariffId);
            deletedCustomerTariff.is_remove = true;
            deletedCustomerTariff.date_remove = DateTime.Now;
            deletedCustomerTariff.employees_fio_modifi = UserName;
            deletedCustomerTariff.commentt_remove = comment;
            repository.Update(deletedCustomerTariff);
            return RedirectToAction("PartialTableCustomerTariffs", new { subServiceCustomerId = deletedCustomerTariff.spr_services_sub_customer_id });
        }

        public ActionResult PartialTableCustomerTariffs(Guid subServiceCustomerId, bool isRemove = false, int page = 1)
        {
            ViewBag.IsRemove = isRemove;
            ViewBag.SubServiceCustomerId = subServiceCustomerId;
            var customerTariffs = repository.SprServicesSubTariffs.Where(sst => sst.spr_services_sub_customer_id == subServiceCustomerId);
            customerTariffs = !isRemove ? customerTariffs.Where(o => o.is_remove != true) : customerTariffs;

            ServiceViewModel model = new ServiceViewModel
            {
                CustomerTariffList = customerTariffs.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = customerTariffs.Count()
                },
            };
            return PartialView("Services/Additionally/Customers/Tariffs/PartialTableCustomerTariffs", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Документы заявителя  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// документы заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialAddCustomerDocument(Guid subServiceCustomerId)
        {
            ViewBag.SubServiceCustomerId = subServiceCustomerId;
            ViewBag.Documents = new SelectList(repository.SprDocuments.OrderBy(s=>s.document_name), "id", "document_name");
            return PartialView("Services/Additionally/Customers/Documents/PartialAddCustomerDocument", new spr_services_sub_document_customer { spr_services_sub_customer_id = subServiceCustomerId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// документы заявителя
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialEditCustomerDocument(Guid customerDocumentId)
        {
            ViewBag.Documents = new SelectList(repository.SprDocuments.OrderBy(s => s.document_name), "id", "document_name");
            var model = repository.SprServicesSubDocumentCustomers.SingleOrDefault(sst => sst.id == customerDocumentId);
            model.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
            return PartialView("Services/Additionally/Customers/Documents/PartialEditCustomerDocument", model);
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет документ
        /// </summary>
        /// <param name="customerDocument">объект документа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCustomerDocumentSave(spr_services_sub_document_customer customerDocument)
        {
            if (ModelState.IsValid)
            {
                repository.SaveSubServiceCustomerDocument(customerDocument);
                return RedirectToAction("PartialTableCustomerDocuments", new { subServiceCustomerId = customerDocument.spr_services_sub_customer_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="customerDocumentId">id документа</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitCustomerDocumentDelete(Guid customerDocumentId)
        {
            spr_services_sub_document_customer deletedCustomerDocument = repository.DeleteSubServiceCustomerDocument(customerDocumentId);
            return RedirectToAction("PartialTableCustomerDocuments", new { subServiceCustomerId = deletedCustomerDocument.spr_services_sub_customer_id });
        }

        public ActionResult PartialTableCustomerDocuments(Guid subServiceCustomerId, int page = 1)
        {
            ViewBag.SubServiceCustomerId = subServiceCustomerId;
            var customerDocuments = repository.SprServicesSubDocumentCustomers.Where(ssdc => ssdc.spr_services_sub_customer_id == subServiceCustomerId).Include(i => i.spr_documents);
            ServiceViewModel model = new ServiceViewModel
            {
                CustomerDocumentList = customerDocuments.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = customerDocuments.Count()
                },
            };
            return PartialView("Services/Additionally/Customers/Documents/PartialTableCustomerDocuments", model);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  СМЭВ запросы  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// СМЭВ запросы к услуге
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSubServiceSmevRequest(Guid subServiceId)
        {
            ViewBag.SubServiceId = subServiceId;
            ViewBag.SmevRequests = new SelectList(repository.SprSmevRequests.OrderBy(s => s.request_name), "id", "request_name");
            return PartialView("Services/Additionally/Smev/PartialModalAddSubServiceSmevRequest", new spr_services_sub_smev_request_join { spr_services_sub_id = subServiceId, employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет СМЭВ запросов
        /// </summary>
        /// <param name="subServiceSmevRequest">объект СМЭВ запроса</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceSmevRequestSave(spr_services_sub_smev_request_join subServiceSmevRequest)
        {
            if (ModelState.IsValid)
            {
                if (subServiceSmevRequest.id == Guid.Empty)
                {
                    repository.Insert(subServiceSmevRequest);
                }
                else
                {
                    subServiceSmevRequest.employees_fio_modifi = Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
                    repository.Update(subServiceSmevRequest);
                }
                return RedirectToAction("PartialTableSubServiceSmevRequests", new { subServiceId = subServiceSmevRequest.spr_services_sub_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="subServiceSmevRequestId">id СМЭВ запроса</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSubServiceSmevRequestDelete(Guid subServiceSmevRequestId)
        {
            spr_services_sub_smev_request_join deletedSubServiceSmevRequest = repository.SprServicesSubSmevRequests.SingleOrDefault(ssr => ssr.id == subServiceSmevRequestId);
            repository.Delete(deletedSubServiceSmevRequest);
            return RedirectToAction("PartialTableSubServiceSmevRequests", new { subServiceId = deletedSubServiceSmevRequest.spr_services_sub_id });
        }

        public ActionResult PartialTableSubServiceSmevRequests(Guid subServiceId, int page = 1)
        {
            ViewBag.SubServiceId = subServiceId;
            var subServiceSmevRequests = repository.SprServicesSubSmevRequests.Where(sssr => sssr.spr_services_sub_id == subServiceId).Include(ssd => ssd.spr_smev_request);
            ServiceViewModel model = new ServiceViewModel
            {
                ServicesSubSmevRequestList = subServiceSmevRequests.OrderBy(s => s.set_date).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = subServiceSmevRequests.Count()
                },
            };
            return PartialView("Services/Additionally/Smev/PartialTableSubServiceSmevRequests", model);
        }


        #endregion

    }
}