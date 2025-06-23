using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    public partial class ReferenceController
    {
        public ActionResult SmevServices()
        {
            return View("SmevServices/Main");
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Сервисы СМЭВ  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление Сервиса СМЭВ
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSmevService()
        {
            return PartialView("SmevServices/SmevServices/PartialModalAddSmevService", new spr_smev { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " " });
        }

        /// <summary>
        /// Изменение данных Сервиса СМЭВ
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSmevService(Guid smevServiceId)
        {
            return PartialView("SmevServices/SmevServices/PartialModalEditSmevService", repository.SprSmevServices.SingleOrDefault(a => a.id == smevServiceId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет Сервис СМЭВ
        /// </summary>
        /// <param name="smevService">объект Сервиса СМЭВ</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSmevServiceSave(spr_smev smevService)
        {
            if (ModelState.IsValid)
            {
                if (smevService.id == Guid.Empty)
                {
                    repository.Insert(smevService);
                }
                else
                {
                    repository.Update(smevService);
                }
                return RedirectToAction("PartialTableSmevServices");
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="smevServiceId">id Сервиса СМЭВ</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSmevServiceDelete(Guid smevServiceId)
        {
            spr_smev smev = repository.SprSmevServices.SingleOrDefault(ss => ss.id == smevServiceId);
            repository.Delete(smev);
            return RedirectToAction("PartialTableSmevServices");
        }

        public ActionResult PartialTableSmevServices(int page = 1)
        {
            var smevServices = repository.SprSmevServices;
            SmevServiceViewModel model = new SmevServiceViewModel
            {
                SmevServiceList = smevServices.OrderBy(a => a.smev_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = smevServices.Count()
                },
            };
            return PartialView("SmevServices/SmevServices/PartialTableSmevServices", model);
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Запросы СМЭВ  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Добавление запроса СМЭВ
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalAddSmevServiceRequest(Guid smevServiceId)
        {
            ViewBag.ServiceSubWeeks = new SelectList(repository.SprServicesSubWeeks.OrderBy(s => s.type_name), "id", "type_name");
            ViewBag.SmevTypeRequests = new SelectList(repository.SprSmevRequestTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("SmevServices/SmevServiceRequests/PartialModalAddSmevServiceRequest", new spr_smev_request { employees_fio = Membership.GetUser(User.Identity.Name)?.UserName ?? " ", spr_smev_id = smevServiceId });
        }

        /// <summary>
        /// Изменение данных запроса СМЭВ
        /// </summary>
        /// <returns>частичное представление модального окна</returns>
        [HttpPost]
        public ActionResult PartialModalEditSmevServiceRequest(int smevServiceRequestId)
        {
            ViewBag.ServiceSubWeeks = new SelectList(repository.SprServicesSubWeeks.OrderBy(s => s.type_name), "id", "type_name");
            ViewBag.SmevTypeRequests = new SelectList(repository.SprSmevRequestTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("SmevServices/SmevServiceRequests/PartialModalEditSmevServiceRequest", repository.SprSmevRequests.SingleOrDefault(a => a.id == smevServiceRequestId));
        }

        /// <summary>
        /// Сохраняет изменнения или добавляет запрос СМЭВ
        /// </summary>
        /// <param name="smevServiceRequest">объект запроса СМЭВ</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSmevServiceRequestSave(spr_smev_request smevServiceRequest)
        {
            if (ModelState.IsValid)
            {
                if (smevServiceRequest.id == 0)
                {
                    repository.Insert(smevServiceRequest);
                }
                else
                {
                    repository.Update(smevServiceRequest);
                }
                return RedirectToAction("PartialTableSmevServiceRequests", new { smevServiceId = smevServiceRequest.spr_smev_id });
            }
            throw new Exception("Ошибка валидации!");
        }

        /// <summary>
        /// Удаляет запись по указанному id
        /// </summary>
        /// <param name="smevServiceRequestId">id запроса СМЭВ</param>
        /// <returns>частичное представление таблицы</returns>
        [HttpPost]
        public ActionResult SubmitSmevServiceRequestDelete(int smevServiceRequestId)
        {
            spr_smev_request smevRequest = repository.SprSmevRequests.SingleOrDefault(ss => ss.id == smevServiceRequestId);
            repository.Delete(smevRequest);
            return RedirectToAction("PartialTableSmevServiceRequests", new { smevServiceId = smevRequest.spr_smev_id });
        }

        public ActionResult PartialTableSmevServiceRequests(Guid smevServiceId, int page = 1)
        {
            ViewBag.SmevServiceId = smevServiceId;

            var steps = repository.SprSmevServices.Where(w => w.id == smevServiceId).SingleOrDefault().smev_name;
            Dictionary<string, string> steps_list = new Dictionary<string, string>();
            steps_list.Add("ion-arrow-right-b", steps);
            ViewBag.StepValues = steps_list;

            var smevServiceRequests = repository.SprSmevRequests.Where(ssr => ssr.spr_smev_id == smevServiceId);
            SmevServiceViewModel model = new SmevServiceViewModel
            {
                SmevServiceRequestList = smevServiceRequests.OrderBy(a => a.request_name).Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = smevServiceRequests.Count()
                },
            };
            return PartialView("SmevServices/SmevServiceRequests/PartialTableSmevServiceRequests", model);
        }

        

        #endregion
    }
}