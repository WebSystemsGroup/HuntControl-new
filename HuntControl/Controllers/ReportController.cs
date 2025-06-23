using System;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web.Hosting;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.WebUI.Filters;
using OfficeOpenXml;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [Authorize]
    public partial class ReportController : Controller
    {
        public int PageSize = 7;

        #region Инициализация Repository
        private IRepository repository;
        private string UserName => Membership.GetUser(User.Identity.Name)?.UserName ?? " ";
        public ReportController(IRepository repo)
        {
            repository = repo;
        }
        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по реестру выданных охотничьих билетов по номеру ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ReportHuntingLicIssuedReestrByNumber()
        {
            return View("ReportHuntingLicIssuedReestrByNumber/ReportHuntingLicIssuedReestrByNumber");
        }

        public ActionResult PartialFilterReportHuntingLicIssuedReestrByNumber()
        {
            return PartialView("ReportHuntingLicIssuedReestrByNumber/PartialFilterReportHuntingLicIssuedReestrByNumber");
        }

        public ActionResult PartialTableReportHuntingLicIssuedReestrByNumber(int numberStart, int numberStop)
        {
            var model = repository.FuncReportHuntingLicIssuedNumberReestr(numberStart, numberStop);
            return PartialView("ReportHuntingLicIssuedReestrByNumber/PartialTableReportHuntingLicIssuedReestrByNumber", model);
        }

        public ActionResult PartialPrintReportHuntingLicIssuedReestrByNumber(int numberStart, int numberStop)
        { 
            var model = repository.FuncReportHuntingLicIssuedNumberReestr(numberStart, numberStop);

            return PartialView("Print/Report/PartialPrintHuntingLicIssuedReestr", model);
        }

        public void DownloadExcelReestrHuntingLicIssuedByNumber(int numberStart, int numberStop)
        {
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            var model = repository.FuncReportHuntingLicIssuedNumberReestr(numberStart, numberStop);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_hunt_lic_cancelled.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["B4"].Value = $"{numberStart} - {numberStop}";
            ws.Cells["H3"].Value = printEmployee + " " + DateTime.Now;

            int index = 6;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 5;
                ws.Cells["B" + index].Value = report.out_customer_name;
                ws.Cells["C" + index].Value = report.out_actual_address;
                ws.Cells["D" + index].Value = report.out_legal_address;
                ws.Cells["E" + index].Value = report.out_doc_birth_date;
                ws.Cells["F" + index].Value = report.out_doc_birth_place;
                ws.Cells["G" + index].Value = report.out_phone_number;
                ws.Cells["H" + index].Value = report.out_doc_serial;
                ws.Cells["I" + index].Value = report.out_doc_number;
                ws.Cells["J" + index].Value = report.out_serial_license;
                ws.Cells["K" + index].Value = report.out_number_license;
                ws.Cells["L" + index].Value = report.out_cancelled_date;
                ws.Cells["M" + index].Value = report.out_cancelled_ground;
                ws.InsertRow(++index, 1, 6);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=reestr_hunt_lic_cancelled" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по реестру аннулированных охотничьих билетов  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ReportHuntingLicCancelledReestr()
        {
            return View("ReportHuntingLicCancelledReestr/ReportHuntingLicCancelledReestr");
        }

        public ActionResult PartialFilterReportHuntingLicCancelledReestr()
        {
            return PartialView("ReportHuntingLicCancelledReestr/PartialFilterReportHuntingLicCancelledReestr");
        }

        public ActionResult PartialTableReportHuntingLicCancelledReestr(DateTime dateStart, DateTime dateStop)
        {
            var model = repository.FuncReportHuntingLicCancelledReestr(dateStart, dateStop);
            return PartialView("ReportHuntingLicCancelledReestr/PartialTableReportHuntingLicCancelledReestr", model);
        }

        public ActionResult PartialPrintReportHuntingLicCancelledReestr(DateTime dateStart, DateTime dateStop)
        {
            ViewBag.Period = dateStart.ToShortDateString() + " - " + dateStop.ToShortDateString();
            var model = repository.FuncReportHuntingLicCancelledReestr(dateStart, dateStop);

            return PartialView("Print/Report/PartialPrintHuntingLicCancelledReestr", model);
        }

        public void DownloadExcelReestrHuntingLicCancelledNumber(string dateStart, string dateStop)
        {
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            var model = repository.FuncReportHuntingLicCancelledReestr(DateTime.Parse(dateStart), DateTime.Parse(dateStop));

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_hunt_lic_cancelled.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["B4"].Value = $"{dateStart} - {dateStop}";
            ws.Cells["H3"].Value = printEmployee + " " + DateTime.Now;

            int index = 6;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 5;
                ws.Cells["B" + index].Value = report.out_customer_name;
                ws.Cells["C" + index].Value = report.out_actual_address;
                ws.Cells["D" + index].Value = report.out_legal_address;
                ws.Cells["E" + index].Value = report.out_doc_birth_date;
                ws.Cells["F" + index].Value = report.out_doc_birth_place;
                ws.Cells["G" + index].Value = report.out_phone_number;
                ws.Cells["H" + index].Value = report.out_doc_serial;
                ws.Cells["I" + index].Value = report.out_doc_number;
                ws.Cells["J" + index].Value = report.out_serial_license;
                ws.Cells["K" + index].Value = report.out_number_license;
                ws.Cells["L" + index].Value = report.out_cancelled_date;
                ws.Cells["M" + index].Value = report.out_cancelled_ground;
                ws.InsertRow(++index, 1, 6);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=reestr_hunt_lic_cancelled" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по реестру выданных охотничьих билетов  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportHuntingLicIssuedReestr()
        {
            return View("ReportHuntingLicIssuedReestr/ReportHuntingLicIssuedReestr");
        }

        public ActionResult PartialFilterReportHuntingLicIssuedReestr()
        {
            return PartialView("ReportHuntingLicIssuedReestr/PartialFilterReportHuntingLicIssuedReestr");
        }

        public ActionResult PartialTableReportHuntingLicIssuedReestr(DateTime dateStart, DateTime dateStop)
        {
            var model = repository.FuncReportHuntingLicIssuedReestr(dateStart, dateStop);
            return PartialView("ReportHuntingLicIssuedReestr/PartialTableReportHuntingLicIssuedReestr", model);
        }

        public ActionResult PartialPrintReportHuntingLicIssuedReestr(DateTime dateStart, DateTime dateStop)
        {
            ViewBag.Period = dateStart.ToShortDateString() + " - " + dateStop.ToShortDateString();
            var model = repository.FuncReportHuntingLicIssuedReestr(dateStart, dateStop);

            return PartialView("Print/Report/PartialPrintHuntingLicIssuedReestr", model);
        }

        public void DownloadExcelReestrHuntingLicIssued(string dateStart, string dateStop)
        {

            var model = repository.FuncReportHuntingLicIssuedReestr(DateTime.Parse(dateStart), DateTime.Parse(dateStop));

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_hunt_lic_issued_ex.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["J4"].Value = $"{dateStart} - {dateStop}";

            int index = 20;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 19;
                ws.Cells["B" + index].Value = report.out_customer_name;
                ws.Cells["C" + index].Value = report.out_doc_birth_date;
                ws.Cells["D" + index].Value = report.out_doc_birth_place;
                ws.Cells["E" + index].Value = report.out_actual_address + ", " + report.out_phone_number + ", " + report.out_e_mail;
                ws.Cells["F" + index].Value = report.out_doc_serial + " " + report.out_doc_number;
                ws.Cells["G" + index].Value = report.out_doc_issue_date;
                ws.Cells["H" + index].Value = report.out_doc_issue_body;
                ws.Cells["I" + index].Value = report.out_social_organization_info;
                ws.Cells["J" + index].Value = report.out_social_job_position;
                ws.Cells["K" + index].Value = report.out_social_pensioner;
                ws.Cells["L" + index].Value = report.out_social_incapable;
                ws.Cells["M" + index].Value = report.out_issue_date;
                ws.Cells["N" + index].Value = report.out_serial_license + " " + report.out_number_license;
                ws.Cells["O" + index].Value = report.out_reestr_date;
                ws.Cells["P" + index].Value = report.out_cancelled_date;
                ws.Cells["Q" + index].Value = report.out_cancelled_ground;
                ws.Cells["R" + index].Value = "-";
                ws.Cells["S" + index].Value = "-";
                ws.Cells["T" + index].Value = "-";
                ws.InsertRow(++index, 1, 20);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=reestr_hunt_lic_issued" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
                pck.Stream.Close();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Реестр по количеству услуг  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportReestrCountService()
        {
            return View("ReportReestrCountService/ReportReestrCountService");
        }

        public ActionResult PartialFilterReportReestrCountService()
        {
            ViewBag.SubServiceStatuses = new SelectList(repository.SprServicesSubStatuses.OrderBy(s => s.status_name), "id", "status_name");
            ViewBag.SubServiceWayGets = new SelectList(repository.SprServicesSubWayGets.OrderBy(s => s.name_way), "id", "name_way");
            return PartialView("ReportReestrCountService/PartialFilterReportReestrCountService");
        }

        public ActionResult PartialTableReportReestrCountService(DateTime dateStart, DateTime dateStop, int subServiceStatusId, Guid subServiceWayGetId)
        {
            var model = repository.FuncReportReestrCountService(dateStart, dateStop, subServiceStatusId, subServiceWayGetId);
            return PartialView("ReportReestrCountService/PartialTableReportReestrCountService", model);
        }

        public ActionResult PartialPrintReportReestrCountService(DateTime dateStart, DateTime dateStop, int subServiceStatusId, Guid subServiceWayGetId)
        {
            ViewBag.Status = repository.SprServicesSubStatuses.SingleOrDefault(s => s.id == subServiceStatusId)?.status_name ?? "Все";
            ViewBag.Period = dateStart.ToShortDateString() + " - " + dateStop.ToShortDateString();
            ViewBag.WayGet = repository.SprServicesSubWayGets.SingleOrDefault(s => s.id == subServiceWayGetId)?.name_way ?? "Все";
            ViewBag.PrintEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;

            var model = repository.FuncReportReestrCountService(dateStart, dateStop, subServiceStatusId, subServiceWayGetId);

            return PartialView("Print/Report/PartialPrintReestrCountService", model);
        }

        public void DownloadExcelReportReestrCountService(string dateStart, string dateStop, int subServiceStatusId, Guid subServiceWayGetId)
        {
            var status = repository.SprServicesSubStatuses.SingleOrDefault(s => s.id == subServiceStatusId)?.status_name ?? "Все";
            var way_get = repository.SprServicesSubWayGets.SingleOrDefault(s => s.id == subServiceWayGetId)?.name_way ?? "Все";
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;

            var model = repository.FuncReportReestrCountService(DateTime.Parse(dateStart), DateTime.Parse(dateStop), subServiceStatusId, subServiceWayGetId);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_count_service.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["C4"].Value = $"{dateStart} - {dateStop}";
            ws.Cells["C5"].Value = status;
            ws.Cells["C6"].Value = way_get;
            ws.Cells["F2"].Value = printEmployee + " " + DateTime.Now;

            int index = 8;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 7;
                ws.Cells["B" + index].Value = report.out_provider_name;
                ws.Cells["C" + index].Value = report.out_service_name;
                ws.Cells["D" + index].Value = report.out_service_count;
                ws.Cells["E" + index].Value = report.out_service_tariff;
                ws.Cells["F" + index].Value = report.out_service_charge;
                ws.Cells["G" + index].Value = report.out_service_tariff_sum;
                ws.Cells["H" + index].Value = report.out_service_charge_sum;
                ws.InsertRow(++index, 1, 9);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=reestr_count_service" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по реестру нарушений  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ReportDataCustomerViolationsReestr()
        {
            return View("ReportdataCustomerViolations/ReportDataCustomerViolationsReestr");
        }

        public ActionResult PartialFilterDataCustomerViolationsReestr()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }
            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.Departments = new SelectList(repository.SprEmployeesDepartments.OrderBy(s => s.department_name), "id", "department_name");
            ViewBag.Violations = new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article");
            return PartialView("ReportDataCustomerViolations/PartialFilterDataCustomerViolationsReestr");
        }

        public ActionResult PartialTableDataCustomerViolationsReestr(DateTime dateStart, DateTime dateStop, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            var model = repository.FuncReportReestrDataCustomerViolations(dateStart, dateStop, sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);
            return PartialView("ReportDataCustomerViolations/PartialTableDataCustomerViolationsReestr", model);
        }

        public ActionResult PartialPrintDataCustomerViolationsReestr(DateTime dateStart, DateTime dateStop, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            ViewBag.Period = dateStart.ToShortDateString() + " - " + dateStop.ToShortDateString();
            ViewBag.Violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            ViewBag.Department = sprEmployeesDepartmentId != null ? repository.SprEmployeesDepartments.Where(w => w.id == sprEmployeesDepartmentId).SingleOrDefault().department_name : "Все";
            ViewBag.Employee = sprEmployeesId != null ? repository.SprEmployees.Where(w => w.id == sprEmployeesId).SingleOrDefault().employees_fio : "Все";
            var model = repository.FuncReportReestrDataCustomerViolations(dateStart, dateStop, sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);
            return PartialView("Print/Report/PartialPrintDataCustomerViolationsReestr", model);
        }

        public void DownloadExcelReestrDataCustomerViolations(string dateStart, string dateStop, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            var violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            var employee = sprEmployeesId != null ? repository.SprEmployees.Where(w => w.id == sprEmployeesId).SingleOrDefault().employees_fio : "Все";
            var department = sprEmployeesDepartmentId != null ? repository.SprEmployeesDepartments.Where(w => w.id == sprEmployeesDepartmentId).SingleOrDefault().department_name : "Все";
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;

            var model = repository.FuncReportReestrDataCustomerViolations(DateTime.Parse(dateStart), DateTime.Parse(dateStop), sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_data_customer_violations.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["C3"].Value = $"{dateStart} - {dateStop}";
            ws.Cells["C4"].Value = violation;
            ws.Cells["C5"].Value = department;
            ws.Cells["C6"].Value = employee;
            ws.Cells["O2"].Value = printEmployee + " " + DateTime.Now;

            int index = 10;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = report.out_pr_number_case;
                ws.Cells["B" + index].Value = report.out_pr_date_in_ogm;
                ws.Cells["C" + index].Value = report.out_pr_number_protocol;
                ws.Cells["D" + index].Value = "-";
                ws.Cells["E" + index].Value = report.out_pr_date_create;
                ws.Cells["F" + index].Value = report.out_pr_place_protocol;
                ws.Cells["G" + index].Value = report.out_pr_customer_name;
                ws.Cells["H" + index].Value = report.out_pr_customer_address;
                ws.Cells["I" + index].Value = report.out_pr_customer_phone_number;
                ws.Cells["J" + index].Value = report.out_pr_birth_date;
                ws.Cells["K" + index].Value = report.out_violations_name;
                ws.Cells["L" + index].Value = report.out_def_date_sent;
                ws.Cells["M" + index].Value = report.out_def_date_handing;
                ws.Cells["N" + index].Value = report.out_res_date + " " + report.out_res_number;
                ws.Cells["O" + index].Value = report.out_res_amount_fine + report.out_res_amount_harm;
                ws.Cells["P" + index].Value = report.out_res_date_receiving_letter;
                ws.Cells["Q" + index].Value = report.out_res_date_handing;
                ws.Cells["R" + index].Value = report.out_res_date_entry;
                ws.Cells["S" + index].Value = report.out_res_payment;
                ws.Cells["T" + index].Value = report.out_bai_date_sent;
                ws.Cells["U" + index].Value = report.out_tr_date_sent;
                ws.InsertRow(++index, 1, 10);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=reestr_data_customer_violations" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по реестру разрешений без корешков  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportHuntingLicNotPermBackReestr()
        {
            return View("ReportHuntingLicNotPermBackReestr/ReportHuntingLicNotPermBackReestr");
        }

        public ActionResult PartialFilterHuntingLicNotPermBackReestr()
        {
            ViewBag.GroupType = new SelectList(repository.SprAnimalGroupTypes.OrderBy(w=>w.group_type_name), "id", "group_type_name"); 
            ViewBag.Animals = new SelectList(repository.SprAnimals.OrderBy(w=>w.animal_name), "id", "animal_name");
            ViewBag.HuntingFarms = new SelectList(repository.SprHuntingFarms.OrderBy(w=>w.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("ReportHuntingLicNotPermBackReestr/PartialFilterHuntingLicNotPermBackReestr");
        }

        public ActionResult PartialTableHuntingLicNotPermBackReestr(DateTime dateStart, DateTime dateStop, Guid? IdGroupType, Guid? IdAnimals, Guid? IdHuntingFarm)
        {
            var model = repository.FuncReportHuntingLicNotPermBackReestr(dateStart, dateStop, IdGroupType ?? Guid.Empty, IdAnimals ?? Guid.Empty, IdHuntingFarm ?? Guid.Empty);
            return PartialView("ReportHuntingLicNotPermBackReestr/PartialTableReportHuntingLicNotPermBackReestr", model);
        }

        public ActionResult PartialPrintHuntingLicNotPermBackReestr(DateTime dateStart, DateTime dateStop, Guid? IdGroupType, Guid? IdAnimals, Guid? IdHuntingFarm)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            ViewBag.Period = dateStart.ToShortDateString() + " - " + dateStop.ToShortDateString();
            var model = repository.FuncReportHuntingLicNotPermBackReestr(dateStart, dateStop, IdGroupType ?? Guid.Empty, IdAnimals ?? Guid.Empty, IdHuntingFarm ?? Guid.Empty);

            return PartialView("Print/Report/PartialPrintHuntingLicNotPermBackReestr", model);
        }

        public void DownloadExcelReestrHuntingLicNotPermBack(string dateStart, string dateStop, Guid? IdGroupType, Guid? IdAnimals, Guid? IdHuntingFarm)
        {
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            var model = repository.FuncReportHuntingLicNotPermBackReestr(DateTime.Parse(dateStart), DateTime.Parse(dateStop), IdGroupType ?? Guid.Empty, IdAnimals ?? Guid.Empty, IdHuntingFarm ?? Guid.Empty);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_hunting_lic_not_perm_back.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["B3"].Value = $"{dateStart} - {dateStop}";
            ws.Cells["D2"].Value = printEmployee + " " + DateTime.Now;
            int index = 7;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = report.out_customer_name;
                ws.Cells["B" + index].Value = report.out_actual_address + ", " + report.out_phone_number1 + " " + report.out_phone_number2;
                ws.Cells["C" + index].Value = report.out_hunting_farm_name + ", " + report.out_group_type_name;
                ws.Cells["D" + index].Value = report.out_serial_form + " " + report.out_number_form;
                ws.Cells["E" + index].Value = report.out_fio_given + ", " + DateTime.Parse(report.out_date_given.ToString()).ToShortDateString();
                ws.Cells["F" + index].Value = DateTime.Parse(report.out_date_stop.ToString()).ToShortDateString();
                ws.InsertRow(++index, 1, 7);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=reestr_hunting_lic_not_perm_back" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Реестр выданных разрешений на охоту  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportHuntingLicPerm()
        {
            return View("ReportHuntingLicPerm/ReportHuntingLicPerm");
        }

        public ActionResult PartialFilterHuntingLicPerm()
        {
            ViewBag.Animals = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            ViewBag.Seasons = new SelectList(repository.SprSeasons.OrderBy(s => s.season_name), "id", "season_name");
            ViewBag.HuntingFarm = new SelectList(repository.SprHuntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            return PartialView("ReportHuntingLicPerm/PartialFilterHuntingLicPerm");
        }

        public ActionResult PartialTableHuntingLicPerm(int? sprSeasonId, Guid? animalId, DateTime dateStart, DateTime dateStop, Guid? sprHuntingFarmId)
        {
            var model = repository.FuncReportHuntingLicPerm(sprSeasonId, animalId, dateStart, dateStop, sprHuntingFarmId);
            return PartialView("ReportHuntingLicPerm/PartialTableReportHuntingLicPerm", model);
        }

        public ActionResult PartialPrintHuntingLicPerm(int? sprSeasonId, Guid? animalId, DateTime dateStart, DateTime dateStop, Guid? sprHuntingFarmId)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name)?.employees_fio;
            ViewBag.Period = dateStart.ToShortDateString() + " - " + dateStop.ToShortDateString();
            ViewBag.HuntingFarm = sprHuntingFarmId != null ? repository.SprHuntingFarms.SingleOrDefault(w => w.id == sprHuntingFarmId)?.hunting_farm_name : "Все";
            var model = repository.FuncReportHuntingLicPerm(sprSeasonId, animalId, dateStart, dateStop, sprHuntingFarmId);

            return PartialView("Print/Report/PartialPrintHuntingLicPerm", model);
        }

        public void DownloadExcelHuntingLicPerm(int? sprSeasonId, Guid? animalId, string dateStart, string dateStop, Guid? sprHuntingFarmId)
        {
            var printEmployee = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name)?.employees_fio;
            var huntingFarm = sprHuntingFarmId != null ? repository.SprHuntingFarms.SingleOrDefault(w => w.id == sprHuntingFarmId)?.hunting_farm_name : "Все";
            var model = repository.FuncReportHuntingLicPerm(sprSeasonId, animalId, DateTime.Parse(dateStart), DateTime.Parse(dateStop), sprHuntingFarmId);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/reestr_hunting_lic_perm.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Реестр"];
            ws.Cells["B3"].Value = $"{dateStart} - {dateStop}";
            ws.Cells["B4"].Value = huntingFarm;
            ws.Cells["D2"].Value = printEmployee + " " + DateTime.Now;
            int index = 8;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = report.out_customer_name;
                ws.Cells["B" + index].Value = report.out_actual_address + ", " + report.out_phone_number1 + " " + report.out_phone_number2;
                ws.Cells["C" + index].Value = report.out_hunting_farm_name + ", " + report.out_season_name;
                ws.Cells["D" + index].Value = report.out_serial_form + " " + report.out_number_form;
                ws.Cells["E" + index].Value = report.out_fio_given + ", " + DateTime.Parse(report.out_date_given.ToString()).ToShortDateString();
                ws.Cells["F" + index].Value = DateTime.Parse(report.out_date_stop.ToString()).ToShortDateString();
                ws.InsertRow(++index, 1, 8);
            }

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=report_hunting_lic_perm" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по количеству нарушений по охотугодьям  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportCountViolationsHuntingFarm()
        {
            return View("ReportCountViolationsHuntingFarm/ReportCountViolationsHuntingFarm");
        }

        public ActionResult PartialFilterCountViolationsHuntingFarm()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }
            ViewBag.Departments = new SelectList(repository.SprEmployeesDepartments.OrderBy(s => s.department_name), "id", "department_name");
            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.Violations = new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article");
            return PartialView("ReportCountViolationsHuntingFarm/PartialFilterCountViolationsHuntingFarm");
        }

        public ActionResult PartialTableCountViolationsHuntingFarm(DateTime startDate, DateTime stopDate, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            var model = repository.FuncReportCountViolationsHuntingFarm(startDate, stopDate, sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);
            return PartialView("ReportCountViolationsHuntingFarm/PartialTableCountViolationsHuntingFarm", model);
        }

        public ActionResult PartialPrintCountViolationsHuntingFarm(DateTime startDate, DateTime stopDate, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            ViewBag.Period = startDate.ToShortDateString() + " - " + stopDate.ToShortDateString();
            ViewBag.Violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            ViewBag.Department = sprEmployeesDepartmentId != null ? repository.SprEmployeesDepartments.Where(w => w.id == sprEmployeesDepartmentId).SingleOrDefault().department_name : "Все";
            ViewBag.Employee = sprEmployeesId != null ? repository.SprEmployees.Where(w => w.id == sprEmployeesId).SingleOrDefault().employees_fio : "Все";
            var model = repository.FuncReportCountViolationsHuntingFarm(startDate, stopDate, sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);

            return PartialView("Print/Report/PartialPrintCountViolationsHuntingFarmResult", model);
        }

        public void DownloadExcelReportCountViolationsHuntingFarm(string startDate, string stopDate, Guid? sprEmployeesId, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            var violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            var department = sprEmployeesDepartmentId != null ? repository.SprEmployeesDepartments.Where(w => w.id == sprEmployeesDepartmentId).SingleOrDefault().department_name : "Все";
            var employee = sprEmployeesId != null ? repository.SprEmployees.Where(w => w.id == sprEmployeesId).SingleOrDefault().employees_fio : "Все";
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            var model = repository.FuncReportCountViolationsHuntingFarm(DateTime.Parse(startDate), DateTime.Parse(stopDate), sprEmployeesId, sprEmployeesDepartmentId, sprViolationsId);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/report_count_violations_hunting_farm.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Отчет"];
            ws.Cells["C3"].Value = $"{startDate} - {stopDate}";
            ws.Cells["C4"].Value = violation;
            ws.Cells["C5"].Value = department;
            ws.Cells["C6"].Value = employee;
            ws.Cells["G2"].Value = printEmployee + " " + DateTime.Now;

            int index = 10;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 9;
                ws.Cells["B" + index].Value = report.out_type_name;
                ws.Cells["C" + index].Value = report.out_hunting_farm_name;
                ws.Cells["D" + index].Value = report.out_un;
                ws.Cells["E" + index].Value = report.out_ps;
                ws.Cells["F" + index].Value = report.out_ov;
                ws.Cells["G" + index].Value = report.out_pv;
                ws.Cells["H" + index].Value = report.out_sho;
                ws.Cells["I" + index].Value = report.out_un20;
                ws.Cells["J" + index].Value = report.out_ps20;
                ws.Cells["K" + index].Value = report.out_np;
                ws.Cells["L" + index].Value = report.out_npp;
                ws.Cells["M" + index].Value = report.out_prk;
                ws.Cells["N" + index].Value = report.out_bs;
                ws.InsertRow(++index, 1, 10);
            }
            ws.Cells["A" + index].Value = "";
            ws.Cells["B" + index].Value = "Итого:";
            ws.Cells["C" + index].Value = "";
            ws.Cells["D" + index].Value = model.Sum(s => s.out_un);
            ws.Cells["E" + index].Value = model.Sum(s => s.out_ps);
            ws.Cells["F" + index].Value = model.Sum(s => s.out_ov);
            ws.Cells["G" + index].Value = model.Sum(s => s.out_pv);
            ws.Cells["H" + index].Value = model.Sum(s => s.out_sho);
            ws.Cells["I" + index].Value = model.Sum(s => s.out_un20);
            ws.Cells["J" + index].Value = model.Sum(s => s.out_ps20);
            ws.Cells["K" + index].Value = model.Sum(s => s.out_np);
            ws.Cells["L" + index].Value = model.Sum(s => s.out_npp);
            ws.Cells["M" + index].Value = model.Sum(s => s.out_prk);
            ws.Cells["N" + index].Value = model.Sum(s => s.out_bs);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=report_count_violations_hunting_farm" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по количеству нарушений по сотрудникам  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportCountViolationsEmployees()
        {
            return View("ReportCountViolationsEmployees/ReportCountViolationsEmployees");
        }

        public ActionResult PartialFilterCountViolationsEmployees()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }
            ViewBag.Departments = new SelectList(repository.SprEmployeesDepartments.OrderBy(s => s.department_name), "id", "department_name");
            ViewBag.Employees = new SelectList(employees.OrderBy(s => s.employees_fio), "id", "employees_fio");
            ViewBag.Violations = new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article");
            return PartialView("ReportCountViolationsEmployees/PartialFilterCountViolationsEmployees");
        }

        public ActionResult PartialTableCountViolationsEmployees(DateTime startDate, DateTime stopDate, Guid? sprViolationsId)
        {
            var model = repository.FuncReportCountViolationsEmployees(startDate, stopDate, sprViolationsId);
            return PartialView("ReportCountViolationsEmployees/PartialTableCountViolationsEmployees", model);
        }

        public ActionResult PartialPrintCountViolationsEmployees(DateTime startDate, DateTime stopDate, Guid? sprViolationsId)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            ViewBag.Period = startDate.ToShortDateString() + " - " + stopDate.ToShortDateString();
            ViewBag.Violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            var model = repository.FuncReportCountViolationsEmployees(startDate, stopDate, sprViolationsId);

            return PartialView("Print/Report/PartialPrintCountViolationsEmployeesResult", model);
        }

        public void DownloadExcelReportCountViolationsEmployees(string startDate, string stopDate, Guid? sprViolationsId)
        {
            var violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            var model = repository.FuncReportCountViolationsEmployees(DateTime.Parse(startDate), DateTime.Parse(stopDate), sprViolationsId);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/report_count_violations_employees.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Отчет"];
            ws.Cells["C3"].Value = $"{startDate} - {stopDate}";
            ws.Cells["C4"].Value = violation;
            ws.Cells["G2"].Value = printEmployee + " " + DateTime.Now;
            int index = 8;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 7;
                ws.Cells["B" + index].Value = report.out_employees_fio;
                ws.Cells["C" + index].Value = report.out_un;
                ws.Cells["D" + index].Value = report.out_ps;
                ws.Cells["E" + index].Value = report.out_ov;
                ws.Cells["F" + index].Value = report.out_pv;
                ws.Cells["G" + index].Value = report.out_sho;
                ws.Cells["H" + index].Value = report.out_un20;
                ws.Cells["I" + index].Value = report.out_ps20;
                ws.Cells["J" + index].Value = report.out_np;
                ws.Cells["K" + index].Value = report.out_npp;
                ws.Cells["L" + index].Value = report.out_prk;
                ws.Cells["M" + index].Value = report.out_bs;
                ws.InsertRow(++index, 1, 8);
            }
            ws.Cells["A" + index].Value = "";
            ws.Cells["B" + index].Value = "Итого:";
            ws.Cells["C" + index].Value = model.Sum(s => s.out_un);
            ws.Cells["D" + index].Value = model.Sum(s => s.out_ps);
            ws.Cells["E" + index].Value = model.Sum(s => s.out_ov);
            ws.Cells["F" + index].Value = model.Sum(s => s.out_pv);
            ws.Cells["G" + index].Value = model.Sum(s => s.out_sho);
            ws.Cells["H" + index].Value = model.Sum(s => s.out_un20);
            ws.Cells["I" + index].Value = model.Sum(s => s.out_ps20);
            ws.Cells["J" + index].Value = model.Sum(s => s.out_np);
            ws.Cells["K" + index].Value = model.Sum(s => s.out_npp);
            ws.Cells["L" + index].Value = model.Sum(s => s.out_prk);
            ws.Cells["M" + index].Value = model.Sum(s => s.out_bs);
            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=report_count_violations_employees" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Отчет по количеству нарушений по стаьям  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|


        public ActionResult ReportCountViolations()
        {
            return View("ReportCountViolations/ReportCountViolations");
        }

        public ActionResult PartialFilterCountViolations()
        {
            var employees = repository.SprEmployees.Where(e => e.is_remove != true);
            if (!User.IsInRole("superadmin") && !User.IsInRole("admin"))
            {
                employees = employees.Where(se => se.employees_login == User.Identity.Name);
            }
            ViewBag.Departments = new SelectList(repository.SprEmployeesDepartments.OrderBy(s => s.department_name), "id", "department_name");
            ViewBag.Violations = new SelectList(repository.SprViolations.OrderBy(s => s.violation_article), "id", "violation_article");
            return PartialView("ReportCountViolations/PartialFilterCountViolations");
        }

        public ActionResult PartialTableCountViolations(DateTime startDate, DateTime stopDate, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            var model = repository.FuncReportCountViolations(startDate, stopDate, sprEmployeesDepartmentId, sprViolationsId);
            return PartialView("ReportCountViolations/PartialTableCountViolations", model);
        }

        public ActionResult PartialPrintCountViolations(DateTime startDate, DateTime stopDate, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            ViewBag.Period = startDate.ToShortDateString() + " - " + stopDate.ToShortDateString();
            ViewBag.Violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            ViewBag.Department = sprEmployeesDepartmentId != null ? repository.SprEmployeesDepartments.Where(w => w.id == sprEmployeesDepartmentId).SingleOrDefault().department_name : "Все";
            var model = repository.FuncReportCountViolations(startDate, stopDate, sprEmployeesDepartmentId, sprViolationsId);

            return PartialView("Print/Report/PartialPrintCountViolationsResult", model);
        }

        public void DownloadExcelReportCountViolations(string startDate, string stopDate, Guid? sprEmployeesDepartmentId, Guid? sprViolationsId)
        {
            var violation = sprViolationsId != null ? repository.SprViolations.Where(w => w.id == sprViolationsId).SingleOrDefault().violation_article : "Все";
            var department = sprEmployeesDepartmentId != null ? repository.SprEmployeesDepartments.Where(w => w.id == sprEmployeesDepartmentId).SingleOrDefault().department_name : "Все";
            var printEmployee = repository.SprEmployees.Where(se => se.employees_login == User.Identity.Name).SingleOrDefault().employees_fio;
            var model = repository.FuncReportCountViolations(DateTime.Parse(startDate), DateTime.Parse(stopDate), sprEmployeesDepartmentId, sprViolationsId);

            ExcelPackage pck = new ExcelPackage();
            pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/report_count_violations.xlsx")).OpenRead());
            var ws = pck.Workbook.Worksheets["Отчет"];
            ws.Cells["C3"].Value = $"{startDate} - {stopDate}";
            ws.Cells["C4"].Value = violation;
            ws.Cells["C5"].Value = department;
            ws.Cells["G2"].Value = printEmployee + " " + DateTime.Now;

            int index = 9;
            foreach (var report in model)
            {
                ws.Cells["A" + index].Value = index - 8;
                ws.Cells["B" + index].Value = report.out_violations_name;
                ws.Cells["C" + index].Value = report.out_un;
                ws.Cells["D" + index].Value = report.out_ps;
                ws.Cells["E" + index].Value = report.out_ov;
                ws.Cells["F" + index].Value = report.out_pv;
                ws.Cells["G" + index].Value = report.out_sho;
                ws.Cells["H" + index].Value = report.out_un20;
                ws.Cells["I" + index].Value = report.out_ps20;
                ws.Cells["J" + index].Value = report.out_np;
                ws.Cells["K" + index].Value = report.out_npp;
                ws.Cells["L" + index].Value = report.out_prk;
                ws.Cells["M" + index].Value = report.out_bs;
                ws.InsertRow(++index, 1, 9);
            }
            ws.Cells["A" + index].Value = "";
            ws.Cells["B" + index].Value = "Итого:";
            ws.Cells["C" + index].Value = model.Sum(s => s.out_un);
            ws.Cells["D" + index].Value = model.Sum(s => s.out_ps);
            ws.Cells["E" + index].Value = model.Sum(s => s.out_ov);
            ws.Cells["F" + index].Value = model.Sum(s => s.out_pv);
            ws.Cells["G" + index].Value = model.Sum(s => s.out_sho);
            ws.Cells["H" + index].Value = model.Sum(s => s.out_un20);
            ws.Cells["I" + index].Value = model.Sum(s => s.out_ps20);
            ws.Cells["J" + index].Value = model.Sum(s => s.out_np);
            ws.Cells["K" + index].Value = model.Sum(s => s.out_npp);
            ws.Cells["L" + index].Value = model.Sum(s => s.out_prk);
            ws.Cells["M" + index].Value = model.Sum(s => s.out_bs);

            using (var memoryStream = new MemoryStream())
            {
                Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
                Response.AddHeader("content-disposition", "attachment;  filename=report_count_violations" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
                pck.SaveAs(memoryStream);
                memoryStream.WriteTo(Response.OutputStream);
                Response.Flush();
                Response.End();
            }
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Общий отчет по разрешению в разрезе групп  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ReportTotalHuntingGroup()
        {
            return View("ReportTotalHuntingGroup/ReportTotalHuntingGroup");
        }

        public ActionResult PartialFilterReportTotalHuntingGroup()
        {
            ViewBag.HuntingFarms = new SelectList(repository.SprHuntingFarms.OrderBy(s => s.hunting_farm_name), "id", "hunting_farm_name");
            ViewBag.HuntingFarmTypes = new SelectList(repository.SprHuntingFarmTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("ReportTotalHuntingGroup/PartialFilterReportTotalHuntingGroup");
        }

        public ActionResult PartialTableReportTotalHuntingGroup(Guid? huntingFarmId, Guid? huntingFarmTypeId, DateTime startDate, DateTime stopDate)
        {
            var model = repository.FuncReportTotalHuntingGroup(huntingFarmId, huntingFarmTypeId, startDate, stopDate);
            return PartialView("ReportTotalHuntingGroup/PartialTableReportTotalHuntingGroup", model);
        }

        public ActionResult PartialPrintReportTotalHuntingGroup(Guid? huntingFarmId, Guid? huntingFarmTypeId, DateTime startDate, DateTime stopDate)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name)?.employees_fio ?? "-";
            ViewBag.Period = startDate.ToShortDateString() + " - " + stopDate.ToShortDateString();
            ViewBag.HuntingFarmType = repository.SprHuntingFarmTypes.SingleOrDefault(hf => hf.id == huntingFarmTypeId)?.type_name ?? "-";
            ViewBag.HuntingFarm = repository.SprHuntingFarms.SingleOrDefault(hf => hf.id == huntingFarmId)?.hunting_farm_name ?? "-";
            var model = repository.FuncReportTotalHuntingGroup(huntingFarmId, huntingFarmTypeId, startDate, stopDate);
            return PartialView("Print/Report/PartialPrintReportTotalHuntingGroup", model);
        }

        public void DownloadExcelReportTotalHuntingGroup(Guid? huntingFarmId, Guid? huntingFarmTypeId, DateTime startDate, DateTime stopDate)
        {
            var model = repository.FuncReportTotalHuntingGroup(huntingFarmId, huntingFarmTypeId, startDate, stopDate);

            //ExcelPackage pck = new ExcelPackage();
            //pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/report_total_hunting_group.xlsx")).OpenRead());
            //var ws = pck.Workbook.Worksheets["Отчет"];
            //ws.Cells["C3"].Value = $"{startDate} - {stopDate}";
            //ws.Cells["C4"].Value = violation;
            //ws.Cells["C5"].Value = department;
            //ws.Cells["G2"].Value = printEmployee + " " + DateTime.Now;

            //int index = 9;
            //foreach (var report in model)
            //{
            //    ws.Cells["A" + index].Value = index - 2;
            //    ws.Cells["B" + index].Value = report.out_violations_name;
            //    ws.Cells["C" + index].Value = report.out_un;
            //    ws.Cells["D" + index].Value = report.out_ps;
            //    ws.Cells["E" + index].Value = report.out_ov;
            //    ws.Cells["F" + index].Value = report.out_pv;
            //    ws.Cells["G" + index].Value = report.out_sho;
            //    ws.Cells["H" + index].Value = report.out_un20;
            //    ws.Cells["I" + index].Value = report.out_ps20;
            //    ws.Cells["J" + index].Value = report.out_np;
            //    ws.Cells["K" + index].Value = report.out_npp;
            //    ws.Cells["L" + index].Value = report.out_prk;
            //    ws.Cells["M" + index].Value = report.out_bs;
            //    ws.InsertRow(++index, 1, 9);
            //}

            //using (var memoryStream = new MemoryStream())
            //{
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;  filename=report_count_violations" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
            //    pck.SaveAs(memoryStream);
            //    memoryStream.WriteTo(Response.OutputStream);
            //    Response.Flush();
            //    Response.End();
            //}
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Общий отчет по разрешению в разрезе охотоугодий  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public ActionResult ReportTotalHuntingFarm()
        {
            return View("ReportTotalHuntingFarm/ReportTotalHuntingFarm");
        }

        public ActionResult PartialFilterReportTotalHuntingFarm()
        {
            ViewBag.Animals = new SelectList(repository.SprAnimals.OrderBy(s => s.animal_name), "id", "animal_name");
            ViewBag.AnimalGroupTypes = new SelectList(repository.SprAnimalGroupTypes.OrderBy(s => s.group_type_name), "id", "group_type_name");
            ViewBag.HuntingFarmTypes = new SelectList(repository.SprHuntingFarmTypes.OrderBy(s => s.type_name), "id", "type_name");
            return PartialView("ReportTotalHuntingFarm/PartialFilterReportTotalHuntingFarm");
        }

        public ActionResult PartialTableReportTotalHuntingFarm(Guid? huntingFarmTypeId, Guid? animalGroupTypeId, Guid? animalId, DateTime startDate, DateTime stopDate)
        {
            var model = repository.FuncReportTotalHuntingFarm(huntingFarmTypeId, animalGroupTypeId, animalId, startDate, stopDate);
            return PartialView("ReportTotalHuntingFarm/PartialTableReportTotalHuntingFarm", model);
        }

        public ActionResult PartialPrintReportTotalHuntingFarm(Guid? huntingFarmTypeId, Guid? animalGroupTypeId, Guid? animalId, DateTime startDate, DateTime stopDate)
        {
            ViewBag.PrintEmployee = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name)?.employees_fio ?? "-";
            ViewBag.Period = startDate.ToShortDateString() + " - " + stopDate.ToShortDateString();
            ViewBag.HuntingFarmType = repository.SprHuntingFarmTypes.SingleOrDefault(hf => hf.id == huntingFarmTypeId)?.type_name ?? "-";
            ViewBag.Animal = repository.SprAnimals.SingleOrDefault(hf => hf.id == animalId)?.animal_name ?? "-";
            ViewBag.AnimalGroupType = repository.SprAnimalGroupTypes.SingleOrDefault(hf => hf.id == animalGroupTypeId)?.group_type_name ?? "-";
            var model = repository.FuncReportTotalHuntingFarm(huntingFarmTypeId, animalGroupTypeId, animalId, startDate, stopDate);
            return PartialView("Print/Report/PartialPrintReportTotalHuntingFarm", model);
        }

        public void DownloadExcelReportTotalHuntingFarm(Guid? huntingFarmTypeId, Guid? animalGroupTypeId, Guid? animalId, DateTime startDate, DateTime stopDate)
        {
            var model = repository.FuncReportTotalHuntingFarm(huntingFarmTypeId, animalGroupTypeId, animalId, startDate, stopDate);

            //ExcelPackage pck = new ExcelPackage();
            //pck.Load(new FileInfo(HostingEnvironment.MapPath("~/Content/excel/report/report_count_violations.xlsx")).OpenRead());
            //var ws = pck.Workbook.Worksheets["Отчет"];
            //ws.Cells["C3"].Value = $"{startDate} - {stopDate}";
            //ws.Cells["C4"].Value = violation;
            //ws.Cells["C5"].Value = department;
            //ws.Cells["G2"].Value = printEmployee + " " + DateTime.Now;

            //int index = 9;
            //foreach (var report in model)
            //{
            //    ws.Cells["A" + index].Value = index - 2;
            //    ws.Cells["B" + index].Value = report.out_violations_name;
            //    ws.Cells["C" + index].Value = report.out_un;
            //    ws.Cells["D" + index].Value = report.out_ps;
            //    ws.Cells["E" + index].Value = report.out_ov;
            //    ws.Cells["F" + index].Value = report.out_pv;
            //    ws.Cells["G" + index].Value = report.out_sho;
            //    ws.Cells["H" + index].Value = report.out_un20;
            //    ws.Cells["I" + index].Value = report.out_ps20;
            //    ws.Cells["J" + index].Value = report.out_np;
            //    ws.Cells["K" + index].Value = report.out_npp;
            //    ws.Cells["L" + index].Value = report.out_prk;
            //    ws.Cells["M" + index].Value = report.out_bs;
            //    ws.InsertRow(++index, 1, 9);
            //}

            //using (var memoryStream = new MemoryStream())
            //{
            //    Response.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            //    Response.AddHeader("content-disposition", "attachment;  filename=report_count_violations" + DateTime.Now.ToString("ddMMyyyyHHmmss") + ".xlsx");
            //    pck.SaveAs(memoryStream);
            //    memoryStream.WriteTo(Response.OutputStream);
            //    Response.Flush();
            //    Response.End();
            //}
        }

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Json  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        public JsonResult GetSprEmployeesFromDepartment(Guid? departmentId)
        {
            if (departmentId != null)
            {
                var result = repository.SprEmployees.Where(w => w.spr_employees_department_id == departmentId).Select(s => new { id = s.id, text = s.employees_fio });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
            else
            {
                var result = repository.SprEmployees.Select(s => new { id = s.id, text = s.employees_fio });
                return Json(result, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAnimalsByGroupType(Guid? animalGroupTypeId)
        {
            var result = repository.SprAnimals.Where(w => animalGroupTypeId == null || w.spr_animal_group_type_id == animalGroupTypeId).Select(s => new { id = s.id, text = s.animal_name });
            return Json(result, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAnimalsBySeason(int? sprSeasonId)
        {
            var result = repository.SprSeasonAnimals.Include(i=>i.spr_animal).Where(w => sprSeasonId == null || w.spr_season_id == sprSeasonId).Select(s => new { id = s.spr_animal.id, text = s.spr_animal.animal_name });
            return Json(result, JsonRequestBehavior.AllowGet);
        }
        #endregion
    }
}