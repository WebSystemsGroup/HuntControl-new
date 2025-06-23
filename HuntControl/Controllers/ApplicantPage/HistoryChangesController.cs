using DocumentFormat.OpenXml.Wordprocessing;
using HuntControl.Domain.Abstract;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;
using System.Linq;
using System;
using System.Web.Mvc;
using System.Data.Entity;
using HuntControl.Domain.Concrete;
using System.Collections.Generic;

namespace HuntControl.WebUI.Controllers.ApplicantPage
{
    [ClientErrorHandler]
    [Authorize]
    public class HistoryChangesController : Controller
    {
        private readonly IRepository repository;
        public int PageSize = 7;
        public HistoryChangesController(IRepository repo)
        {
            repository = repo;
        }
        // GET: HistoryChanges
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Main(string search, int page = 1)
        {
            try
            {
                ViewBag.Serach = search;

                var dataChangeLogs = repository.DataChangeLogs.Where(w => w.data_customer_id != null).Join(repository.DataCustomers,
                p => p.data_customer_id,
                c => c.id,
                (p, c) => new data_history_change_log
                {
                    change = p,
                    applicantFio = c.customer_name
                });

                var ab = dataChangeLogs.Count();

                if(!String.IsNullOrEmpty(search))
                {
                    dataChangeLogs = search.ToLower().Split().Aggregate(dataChangeLogs, (current, item) => current.Where(h => h.applicantFio.ToLower().Contains(item)));
                }

                var ac = dataChangeLogs.Count();

                ApplicantPageViewModel model = new ApplicantPageViewModel
                {
                    DataHistoryChangeLogList = dataChangeLogs.OrderByDescending(a => a.change.date_change).Skip((page - 1) * PageSize).Take(PageSize),
                    PageInfo = new PageInfo
                    {
                        MaxPageList = 5,
                        CurrentPage = page,
                        ItemsPerPage = PageSize,
                        TotalItems = dataChangeLogs.Count()
                    },
                };
                return PartialView(model);
            }
            catch(Exception e)
            {
                return null;
            }
        }
    }
}