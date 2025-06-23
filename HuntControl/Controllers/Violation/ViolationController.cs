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
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Filters;
using HuntControl.WebUI.Models;

namespace HuntControl.WebUI.Controllers.Violation
{
    [ClientErrorHandler]
    [Authorize]

    public partial class ViolationController : Controller
    {
        public int PageSize = 7;
        private string UserName => Membership.GetUser(User.Identity.Name)?.UserName ?? " ";

        #region Инициализация Repository
        private IRepository repository;
        public ViolationController(IRepository repo)
        {            
            repository = repo;
        }
        #endregion

        public ActionResult Main()
        {
            ViolationViewModel model = new ViolationViewModel
            {
                PageInfo = new PageInfo()
            };
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }

            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.ViolationsStatuses = new SelectList(repository.SprViolationsStatus.Select(s=> new {id=s.id, status_name=s.status_name+" ("+s.commentt.ToLower()+")" }).OrderBy(s => s.status_name), "id", "status_name");
            ViewBag.ViolationsDocuments = new SelectList(repository.SprViolationsDocument.OrderBy(s => s.document_name), "id", "document_name");
            ViewBag.Violations = new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article");
            return View(model);
        }

        // GET: Violation
        public ActionResult Violations()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }

            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");            
            ViewBag.ViolationsStatuses = new SelectList(repository.SprViolationsStatus.OrderBy(s => s.status_name), "id", "status_name");
            ViewBag.ViolationsDocuments = new SelectList(repository.SprViolationsDocument.OrderBy(s => s.document_name), "id", "document_name");

            return View();
        }

        [HttpPost]
        public ActionResult IndividualList(Guid? employeeId1, DateTime dateStart, DateTime dateStop, int? statusId, int? documentId, Guid? sprViolationId, int page = 1)
        {
            var violations = repository.FuncViolationsCustomerSelect(employeeId1, dateStart, dateStop, statusId, documentId, sprViolationId);
            ViewBag.EmployeeId = employeeId1;
            ViewBag.DateStart = dateStart;
            ViewBag.DateStop = dateStop;
            ViewBag.StatusId = statusId;
            ViewBag.DocumentId = documentId;
            ViewBag.SprViolationId = sprViolationId;

            ViolationViewModel model = new ViolationViewModel
            {
                ViolationsCustomerSelectResultList = violations.OrderBy(a => a.out_customer_name),//.Skip((page - 1) * PageSize).Take(PageSize),
                PageInfo = new PageInfo
                {
                    MaxPageList = 5,
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = violations.Count()
                },
            };
            return PartialView("IndividualList", model);
        }

        public ActionResult PartialIndividualPage(Guid customerId)
        {
            ViewBag.CustomerId = customerId;
            ViewBag.CustomerName = repository.DataCustomers.SingleOrDefault(dc => dc.id == customerId).customer_name;
            var customerInfo = repository.FuncHuntingCustomerInfoGetDto(customerId);
            return PartialView(customerInfo);
        }
    }
}