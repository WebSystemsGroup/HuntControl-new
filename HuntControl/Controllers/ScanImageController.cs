using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Filters;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    public class ScanImageController : Controller
    {
        public int PageSize = 7;

        #region Инициализация Repository
        private IRepository repository;
        public ScanImageController(IRepository repo)
        {
            repository = repo;
        }
        #endregion

        [HttpGet]
        public ActionResult GetFtpModel()
        {
            var ftpModel =
                new
                {
                    ftpServer = repository.SprSettings.SingleOrDefault(ss => ss.param_name == "ftp_server")?.param_value,
                    ftpFolder = repository.SprSettings.SingleOrDefault(ss => ss.param_name == "ftp_folder")?.param_value,
                    ftpLogin = repository.SprSettings.SingleOrDefault(ss => ss.param_name == "ftp_user")?.param_value,
                    ftpPass = CRPassword.Encrypt(repository.SprSettings.SingleOrDefault(ss => ss.param_name == "ftp_password")?.param_value),
                };
            return Json(ftpModel, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult SaveScanImage(data_services_file serviceFile)
        {
            var employees = repository.SprEmployees.First(se => se.employees_login == User.Identity.Name);

            serviceFile.employees_fio = employees.employees_fio;
            serviceFile.spr_employees_id = employees.id;
            serviceFile.file_ext = ".jpg";
            repository.Insert(serviceFile);
            serviceFile.spr_employees = null;
            return Json(serviceFile, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public ActionResult DeleteScanImage(Guid dataServicesFileId)
        {
            var serviceFile = repository.DataServicesFiles.SingleOrDefault(dsf => dsf.id == dataServicesFileId);
            repository.Delete(serviceFile);
            return Json("Файл успешно удален!", JsonRequestBehavior.AllowGet);
        }
    }
}