using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;
using Newtonsoft.Json;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [Authorize]
    public class HomeController : Controller
    {
        public int PageSize = 7;

        #region Инициализация Repository
        private readonly IRepository repository;
        
        public HomeController(IRepository repo)
        {
            repository = repo;
        }
        #endregion
        
        public ActionResult Index(int? year)
        {
            ViewBag.Year = year ?? DateTime.Now.Year;
            MainGeneralInformationResult generalInformation = repository.FuncMainGeneralInformationSelect();
            StatisticsViewModel model = new StatisticsViewModel()
            {
                MainGeneralInformationList = generalInformation
            };
            return View(model);
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Статистика  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        
        public ActionResult HuntigLicChart(int year)
        {
            IEnumerable<MainCountIssueAndCancelledHuntingLicResult> issueAndCancelled = repository.FuncMainCountIssueAndCancelledHuntingLicSelect(year);
            StatisticsViewModel model = new StatisticsViewModel()
            {
                MainCountIssueAndCancelledHuntingLicList = issueAndCancelled
            };
            ViewBag.Months = JsonConvert.SerializeObject(model.MainCountIssueAndCancelledHuntingLicList.Select(s => s.out_month).ToArray());
            return PartialView(model);
        }
        public ActionResult MainHunticLicCharts(int year)
        {
            IEnumerable<MainCountIssueGroupTypeResult> issueGroupType = repository.FuncMainCountIssueGroupTypeSelect(year).OrderByDescending(s=>s.out_count);
            IEnumerable<MainCountHuntingFarmResult> huntigFarm = repository.FuncMainCountHuntingFarmSelect(year).OrderByDescending(s=>s.out_count).Take(10);
            StatisticsViewModel model = new StatisticsViewModel()
            {

                MainCountHuntingFarmList = huntigFarm,
                MainCountIssueGroupTypeList = issueGroupType
            };
            return PartialView(model);
        }
        public ActionResult HunticLicForGroupChart(int year)
        {
            IEnumerable<MainCountIssueGroupTypeResult> issueGroupType = repository.FuncMainCountIssueGroupTypeSelect(year);
            StatisticsViewModel model = new StatisticsViewModel()
            {
                MainCountIssueGroupTypeList = issueGroupType
            };
            return PartialView(model);
        }

        public ActionResult HunticLicForHunticFarmChart(int year)
        {
            IEnumerable<MainCountHuntingFarmResult> huntigFarm = repository.FuncMainCountHuntingFarmSelect(year);
            StatisticsViewModel model = new StatisticsViewModel()
            {
                MainCountHuntingFarmList = huntigFarm
            };
            return PartialView(model);
        }

        public ActionResult EServiceChart(int year)
        {
            IEnumerable<MainCountEpguAndMfcResult> epguAndMfc = repository.FuncMainCountEpguAndMfcSelect(year);
            StatisticsViewModel model = new StatisticsViewModel()
            {
                MainCountEpguAndMfcList = epguAndMfc
            };
            return PartialView(model);
        }
        public ActionResult ViolationChart(int year)
        {
            IEnumerable<MainCountViolationsResult> violations = repository.FuncMainCountViolationsSelect(year);
            StatisticsViewModel model = new StatisticsViewModel()
            {
                MainCountViolationsList = violations
            };
            return PartialView(model);
        }
        
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Карта  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult Map()
        {
            return View();
        }

        public enum SearchType
        {
            SearchCustomer = 1,
            SearchServiceCustomer = 2
        }

        public ActionResult Search(SearchType searchType, string searchText = "")
        {
            var searchTextArray = searchText.ToUpper().Split();
            if (searchTextArray.Length > 0)
            {
                object result = null;
                switch (searchType)
                {
                    case SearchType.SearchCustomer:
                        result = searchTextArray.Aggregate(repository.DataCustomers, (current, searchTextItem) => current.Where(r => r.actual_address.ToUpper().Contains(searchTextItem) || r.customer_name.ToUpper().Contains(searchTextItem))).Select(x=> new {x.actual_address, x.id, x.phone_number1, x.customer_name }).ToList();
                        break;
                    case SearchType.SearchServiceCustomer:
                        result = searchTextArray.Aggregate(repository.DataServicesCustomers, (current, searchTextItem) => current.Where(r => r.customer_address.ToUpper().Contains(searchTextItem) || r.customer_fio.ToUpper().Contains(searchTextItem) || r.data_services_info_id.ToUpper().Contains(searchTextItem))).Select(s => new { s.data_services.spr_services_sub_name, s.data_services_info_id, s.customer_fio, s.set_date }).ToList();
                        break;
                }
                return Json(result, JsonRequestBehavior.AllowGet);
            }

            return Json(null, JsonRequestBehavior.AllowGet);
        }

        public ActionResult PartialListEmployeeAlerts()
        {
            var employeeId = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name).id;
            var alerts = repository.FuncAlertEmployeeSelect(employeeId);

            return PartialView(alerts);
        }

        public ActionResult SubmitEmployeeAlertDelete(Guid alertId, int alertTypeId)
        {
            object deleteModel;
            if (alertTypeId == 4)
            {
                deleteModel = repository.DataEmployeeReminders.SingleOrDefault(der => der.id == alertId);
            }
            else
            {
                deleteModel = repository.DataEmployeeAlerts.SingleOrDefault(dea => dea.id == alertId);
            }
            repository.Delete(deleteModel);

            return Json(true, JsonRequestBehavior.AllowGet);
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Карта  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ChangePassword(string login)
        {
            login = User.Identity.Name;
            return PartialView("Users/ChangePassword", new ChangePasswordModel { Login = login });
        }

        #endregion
    }
}