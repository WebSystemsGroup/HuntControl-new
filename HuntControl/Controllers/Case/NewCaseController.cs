using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using System.Web.Security;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.WebUI.Models;
using Ohotnik.Smev;
using Ohotnik.Smev.Client;
using Ohotnik.Smev.Client.SmevRouter;

namespace HuntControl.WebUI.Controllers.Case
{
    public partial class CaseController : Controller
    {
        public int PageSize = 1;
        private string UserName => Membership.GetUser(User.Identity.Name)?.UserName ?? " ";

        #region Инициализация Repository
        private readonly IRepository repository;
        public CaseController(IRepository repo)
        {
            SmevClientSetup.Init(ConfigurationManager.AppSettings["Smev_serviceUrl"], ConfigurationManager.AppSettings["Smev_authCode"], 300);
            repository = repo;
        }
        #endregion

        public ActionResult NewCase()
        {
            return View("NewCase/NewCase");
        }
        public ActionResult PartialCustomerServices()
        {
            CaseViewModel model = new CaseViewModel
            {
                SprServicesSubTypeRecipientList = repository.SprServicesSubTypeRecipients,
                SprServicesSubSelectResultList = repository.FuncSprServicesSubSelect()
            };
            return PartialView("NewCase/PartialCustomerServices", model);
        }

        public ActionResult PartialCustomerRecipient(Guid sprServicesSubId)
        {
            ViewBag.IdentityDocuments = new SelectList(repository.SprDocumentIdentities.OrderBy(s => s.document_name), "id", "document_name");
            CaseViewModel model = new CaseViewModel
            {
                SprServicesSubCustomerTypeRecipientSelectResultList = repository.FuncSprServicesSubCustomerTypeRecipientSelect(sprServicesSubId),
                ServiceId = sprServicesSubId,
                Recipient = repository.FuncSprServicesSubCustomerTypeRecipientSelect(sprServicesSubId).FirstOrDefault().out_spr_services_sub_type_recipient_id
            };
            return PartialView("NewCase/PartialCustomerRecipient", model);
        }

        public ActionResult GetCustomerDataInfo(string customerDocSerial, string customerDocNumber)
        {
            var getCustomerInfoResultList = repository.FuncGetCustomerInfo(customerDocSerial, customerDocNumber);
            return Json(getCustomerInfoResultList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetCustomerInn(FioType fio, string documentType, string documentSeries, string documentNumber, DateTime birthDate, DateTime documentDate)
        {
            GetInnSingularRequestData request = new GetInnSingularRequestData
            {
                Fio = fio,
                BirthDate = DateTime.Parse(birthDate.ToShortDateString()),
                DocumentType = documentType,
                DocumentSeriesNumber = $"{documentSeries} {documentNumber}",
                DocumentDate = DateTime.Parse(documentDate.ToShortDateString()),
                CustomModeInfo = CustomModeSupport.GetInnSingularCustomModeInfo(),
                BirthPlace = null,
                DocumentIssuer = null,
                DocumentIssuerCode = null
            };

            var response = SmevClient.RequestInnSingularSync(request);
            if (response.ErrorDescription == null)
            {
                if (response.Inn == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Нет данных", JsonRequestBehavior.AllowGet);
                }
                return Json(response.Inn, JsonRequestBehavior.AllowGet);
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            string errors = response.ErrorDescription;
            return Json(errors);
        }

        public ActionResult GetCustomerSnils(FioType fio, string gender, string birthDate)
        {
            GetSnilsByAdditionalDataRequestData request = new GetSnilsByAdditionalDataRequestData
            {
                Fio = fio,
                BirthDate = DateTime.Parse(birthDate),
                Gender = gender == "Муж" ? GenderType.Male : GenderType.Female,
                CustomModeInfo = CustomModeSupport.GetSnilsCustomModeInfo()
            };
            string errors;
            var response = SmevClient.GetSnilsByAdditionalData(request);
            if (response.ErrorDescription == null)
            {
                if (response.Snils != null)
                {
                    return Json(response.Snils, JsonRequestBehavior.AllowGet);
                }
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                errors = "Неоднозначный ответ";
                return Json(errors);
            }
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            errors = response.ErrorDescription;
            return Json(errors);
        }

        public ActionResult SubmitDataServiceSave(data_services_customer customer, data_services_customer principal, Guid serviceSubId, Guid? tariffId2, bool? isPrincipal, int countService)
        {
            Guid tariffId =  new Guid("e817e0dc-4f43-46dc-904f-dbb9d7cb4e97");
            Random rand = new Random();
            var employee = repository.SprEmployees.SingleOrDefault(se => se.employees_login == User.Identity.Name);
            var tariff = repository.SprServicesSubTariffs.SingleOrDefault(sst => sst.id == tariffId);

            // Добавление услуги
            data_services dataService = new data_services
            {
                data_services_info_id = String.Format("{0}{3}{1}{2}", "MINPR", DateTime.Now.ToString("ddMMyyHHmmssffff"), rand.Next(1, 5), rand.Next(0, 9)),
                spr_services_sub_tr_id = customer.spr_services_sub_tr_id,
                spr_services_sub_status_id = 0,
                spr_services_sub_id = serviceSubId,
                spr_services_sub_way_get_id = Guid.Parse("6ba60d56-9abf-4493-9b15-1ddd49052784"),
                spr_services_sub_week_id = tariff.spr_services_sub_week_id,
                spr_services_sub_tariff_type_id = tariff.spr_services_sub_tariff_type_id,
                tariff_state = tariff.tariff_ * countService,
                charge_ = tariff.charge_ * countService,
                count_day_execution = tariff.count_day_execution,
                count_day_processing = tariff.count_day_processing,
                count_day_return = tariff.count_day_return,
                spr_employees_id = employee.id,
                employees_fio = employee.employees_fio,
                spr_employees_job_pos_id = employee.spr_employees_job_pos_id,
            };

            repository.SaveDataService(dataService);
            customer.spr_alert_id = 1;
            if (customer.spr_services_sub_tr_id == 1912196)
            {
                // Добавление заявителя
                customer.data_services_id = dataService.id;
                customer.data_services_info_id = dataService.data_services_info_id;
                customer.customer_type = 1;
                repository.SaveDataServiceCustomer(customer);

                if (isPrincipal ?? false)
                {
                    // Добавление доверителя
                    principal.data_services_id = dataService.id;
                    principal.data_services_info_id = dataService.data_services_info_id;
                    principal.customer_type = 3;
                    repository.SaveDataServiceCustomer(principal);
                }

            }
            else
            {
                // Добавление заявителя
                principal.data_services_id = dataService.id;
                principal.data_services_info_id = dataService.data_services_info_id;
                principal.customer_type = 1;
                repository.SaveDataServiceCustomer(principal);

                // Добавление доверителя
                customer.data_services_id = dataService.id;
                customer.data_services_info_id = dataService.data_services_info_id;
                customer.customer_type = 3;
                repository.SaveDataServiceCustomer(customer);
            }

            var responseData = new {
                id = dataService.id,
                data_services_info_id = dataService.data_services_info_id,
                employees_fio = dataService.employees_fio,
                employees_id = dataService.spr_employees_id
            };

            return Json(responseData, JsonRequestBehavior.AllowGet);
        }

    }
}