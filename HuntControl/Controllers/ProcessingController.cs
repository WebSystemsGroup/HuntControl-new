using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using HeyRed.Mime;
using Ohotnik.Smev;
using Ohotnik.Smev.Client;
using Ohotnik.Smev.Client.SmevRouter;


namespace HuntControl.WebUI.Controllers
{
    public class ProcessingController : Controller
    {
        public ProcessingController ()
        {
            SmevClientSetup.Init(ConfigurationManager.AppSettings["Smev_serviceUrl"], ConfigurationManager.AppSettings["Smev_authCode"], 3000);
        }
        public ActionResult ErrorProcessing()
        {
            return View("ErrorProcessing");
        }

        public int GetErrorsNumber() => SmevClient.RequestGetNewAppealsCount();

        /// <summary>
        /// функция получает Все жалобы
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public JsonResult RequestGetAllAppeals()
        {
            FgisDoAppealType[] response = SmevClient.RequestGetAllAppeals();
            return Json(response, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// функция получает документы жалобы
        /// </summary> 
        /// <returns></returns>
        [HttpGet]
        public FileResult RequestGetFile(FgisDoGetFileRequestData requestData)
        {
            byte[] response = SmevClient.RequestGetFile(requestData);
            return File(response, "application/zip", "doc.zip");
        }
        /// <summary>
        /// Добавление файла
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public JsonResult RequestAddFileToAttr(FgisDoAddFileToAttrRequestData requestData)
        {
            requestData.CustomModeInfo = CustomModeSupport.GetFgisDoCustomModeInfo();
            FgisDoAddFileToAttrResponseData response = SmevClient.RequestAddFileToAttr(requestData);
            if (response.Fault == null)
            {
                return Json("Успешно", JsonRequestBehavior.AllowGet);
            }
            else return Json(response, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Смена этапа
        /// </summary> 
        /// <returns></returns>
        [HttpPost]
        public JsonResult RequestEdit(FgisDoEditRequestData requestData)
        {
            requestData.CustomModeInfo = CustomModeSupport.GetFgisDoCustomModeInfo();
            FgisDoEditResponseData response = SmevClient.RequestEdit(requestData);
            if(response.Fault == null)
            {
                return Json("Успешно", JsonRequestBehavior.AllowGet);
            }
            else return Json(response, JsonRequestBehavior.AllowGet);
        }
    } 
}