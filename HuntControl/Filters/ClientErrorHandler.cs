using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Filters
{
    public class ClientErrorHandler : FilterAttribute, IExceptionFilter
    {
        public void OnException(ExceptionContext filterContext)
        {
            var response = filterContext.RequestContext.HttpContext.Response;
            response.StatusCode = (int)HttpStatusCode.BadRequest;
            response.Write(filterContext.Exception.Message + " " + filterContext.Exception.InnerException?.InnerException?.Message);
            response.ContentType = MediaTypeNames.Text.Plain;
            filterContext.ExceptionHandled = true;
            using (EFDbContext db = new EFDbContext())
            {
                spr_employees employee = db.spr_employees.SingleOrDefault(ss => ss.employees_login == filterContext.HttpContext.User.Identity.Name);
                Guid employeeId = employee?.id ?? Guid.Empty;
                string employeeName = employee?.employees_fio ?? "";
                data_system_errors message = new data_system_errors { error_message = filterContext.Exception.Message, error_inner_exception = filterContext.Exception.InnerException?.ToString(), employees_fio = employeeName, stack_trace = filterContext.Exception.StackTrace, spr_employees_id = employeeId };
                db.data_system_errors.Add(message);
                db.SaveChanges();
            }
        }
    }
}