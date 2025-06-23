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
    public class EPGUController : Controller
    {
        public int PageSize = 7;

        #region Инициализация Repository

        private IRepository repository;
        public EPGUController(IRepository repo)
        {
            SmevClientSetup.Init(ConfigurationManager.AppSettings["Smev_serviceUrl"], ConfigurationManager.AppSettings["Smev_authCode"]);
            repository = repo;
        }

        #endregion

        public ActionResult PartialListEPGUCustomers()
        {
            var customer = repository.FuncEpguVisitTimeSelect().ToArray();
            return PartialView(customer);
        }
    }
}