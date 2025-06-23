using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HuntControl.Domain.Abstract;
using HuntControl.WebUI.Filters;
using Ohotnik.Smev;
using Ohotnik.Smev.Client;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [Authorize]
    public class SystemController : Controller
    {
        public int PageSize = 7;

        #region Инициализация Repository
        private IRepository repository;
        public SystemController(IRepository repo)
        {
            SmevClientSetup.Init(ConfigurationManager.AppSettings["Smev_serviceUrl"], ConfigurationManager.AppSettings["Smev_authCode"]);
            repository = repo;
        }
        #endregion

        public ActionResult Settings()
        {
            var model = repository.SprSettings;
            return View(model);
        }

        public ActionResult SubmitSettingSave(Dictionary<string, string> setting)
        {
            foreach (var item in setting)
            {
                var settingModel = repository.SprSettings.SingleOrDefault(ss => ss.param_name == item.Key);
                settingModel.param_value = item.Value;
                repository.Update(settingModel);
            }
            return Json("Запись успешна сохранена.");
        }

        public ActionResult ChangeLogs(string search, int page = 1)
        {
            return View("ChangeLogs/Main");
        }

        public ActionResult PartialTableChangeLogs(string search, int page = 1)
        {
            ViewBag.Serach = search;
            var dataChangeLogs = repository.DataChangeLogs;
            dataChangeLogs = String.IsNullOrEmpty(search) ? dataChangeLogs :
                search.ToLower().Split().Aggregate(dataChangeLogs, (current, item) => current.Where(h => h.field_name_.ToLower().Contains(item) || h.table_name_.ToLower().Contains(item)));

            ReferenceViewModel model = new ReferenceViewModel
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
        public ActionResult Errors ()
        {
            var model = repository.DataSystemErrors.OrderByDescending(od=>od.error_date);
            return View("Errors", model);
        }
    }
}