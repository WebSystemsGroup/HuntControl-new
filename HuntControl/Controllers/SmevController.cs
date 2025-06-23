using System;
using System.Configuration;
using System.Linq;
using System.Net;
using System.Text;
using System.Web.Mvc;
using HeyRed.Mime;
using HuntControl.Domain.Abstract;
using HuntControl.Domain.Concrete;
using HuntControl.Domain.Models.Entities;
using HuntControl.WebUI.Filters;
using Ohotnik.Smev.Client;
using Ohotnik.Smev.Client.SmevRouter;
using WebGrease.Css.Extensions;

namespace HuntControl.WebUI.Controllers
{
    [ClientErrorHandler]
    [Authorize]
    public class SmevController : Controller
    {
        private IRepository repository;

        public SmevController(IRepository repo)
        {
            SmevClientSetup.Init(ConfigurationManager.AppSettings["Smev_serviceUrl"], ConfigurationManager.AppSettings["Smev_authCode"]);
            this.repository = repo;
        }

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Методы для работы с базой  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Сохранение запроса СМЭВ
        /// </summary>
        /// <param name="serviceId">Идентификатор Услуги</param>
        /// <param name="commentt">Комментарии</param>
        /// <param name="smevId">Идентификатор СМЭВ</param>
        /// <returns></returns>
        public Guid SubmitSmevRequestSave(Guid serviceId, string commentt, int smevId)
        {
            spr_employees employee = repository.SprEmployees.First(q => q.employees_login == User.Identity.Name);

            var model = new data_services_smev_request
            {
                data_services_info_id = repository.DataServices.SingleOrDefault(q => q.id == serviceId)?.data_services_info_id,
                data_services_id = serviceId,
                spr_smev_request_id = smevId,
                employees_fio = employee.employees_fio,
                spr_employees_id = employee.id,
                commentt = commentt
            };
            repository.Insert(model);
            return model.id;
        }

        /// <summary>
        /// Удаление запроса СМЭВ
        /// </summary>
        /// <param name="smevRequestId">Идентификатор СМЭВ запроса</param>
        public void SubmitSmevRequestDelete(Guid smevRequestId)
        {
            var smevRequest = repository.DataServicesSmevRequests.SingleOrDefault(d => d.id == smevRequestId);
            repository.Delete(smevRequest);
        }

        #endregion

        //#region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ПФР  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        ///// <summary>
        ///// функция получает СНИЛС
        ///// </summary>
        ///// <param name="fio"> ФИО</param>
        ///// <param name="gender">пол</param>
        ///// <param name="birthDate">дата рождения</param>
        ///// <returns>Снилс (строка)</returns>
        //[HttpPost]
        //public JsonResult SmevGetSnils(FioType fio, string gender, string birthDate)
        //{
        //    try
        //    {
        //        GetSnilsRequestData request = new GetSnilsRequestData
        //        {
        //            Fio = fio,
        //            BirthDate = DateTime.Parse(birthDate),
        //            Gender = gender == "Муж" ? GenderType.Male : GenderType.Female,
        //            CustomModeInfo = CustomModeSupport.GetSnilsCustomModeInfo()
        //        };
        //        GetSnilsResponseData response = SmevClient.GetSnils(request);
        //        if (response.ErrorDescription == null)
        //        {
        //            if (response.SnilsResponseItems.Any())
        //            {
        //                return Json(response.SnilsResponseItems.First().Snils, JsonRequestBehavior.AllowGet);
        //            }
        //            else
        //            {
        //                Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //                string errors = "Неоднозначный ответ";
        //                return Json(errors);
        //            }
        //        }
        //        else
        //        {
        //            Response.StatusCode = (int)HttpStatusCode.BadRequest;
        //            string errors = response.ErrorDescription;
        //            return Json(errors);
        //        }
        //    }
        //    catch
        //    {
        //        throw new System.Web.HttpException("Ошибка подключения к сервису СМЭВ");
        //    }

        //}

        //[HttpPost]
        //public JsonResult Smev_Snils(Guid dataServicesId, FioType fio, string gender, string birthDate)
        //{
        //    GetSnilsRequestData request = new GetSnilsRequestData
        //    {
        //        Fio = fio,
        //        BirthDate = DateTime.Parse(birthDate),
        //        Gender = gender == "Муж" ? GenderType.Male : GenderType.Female,
        //        DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{fio.FirstName} {fio.LastName} {fio.SecondName}", 1))
        //    };
        //    GetSnilsResponseData response = SmevClient.GetSnils(request);
        //    if (response.ResponseReports != null)
        //    {
        //        ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
        //        return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //    else
        //    {
        //        return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //}

        ///// <summary>
        ///// Запрос данныx по СНИЛСу
        ///// </summary>
        ///// <param name="snils">СНИЛС</param>
        ///// <returns></returns>
        //public JsonResult Smev_ReverseSnilsQuery(Guid dataServicesId, string snils)
        //{
        //    GetReverseSnilsRequestData request = new GetReverseSnilsRequestData
        //    {
        //        DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{snils}", 7)),
        //        Snils = snils
        //    };

        //    GetReverseSnilsResponseData response = SmevClient.GetReverseSnils(request);
        //    if (response.ResponseReports != null)
        //    {
        //        ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
        //        return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //    else
        //    {
        //        return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //}

        //#endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ФНС  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        /// <summary>
        /// функция получает ИНН
        /// </summary>
        /// <param name="fio">ФИО</param>
        /// <param name="documentType">тип документа</param>
        /// <param name="documentSeries">серия документа</param>
        /// <param name="documentNumber">номер документа</param>
        /// <param name="birthDate">дата рождения</param>
        /// <param name="documentDate">дата получения документа</param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult Smev_GetInn(FioType fio, string documentType, string documentSeries, string documentNumber, DateTime birthDate, DateTime documentDate)
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

            var response = SmevClient.RequestInnSingular(request);
            if (response.ErrorDescription == null)
            {
                if (response.Inn == null)
                {
                    Response.StatusCode = (int)HttpStatusCode.BadRequest;
                    return Json("Нет данных", JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(response.Inn, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                Response.StatusCode = (int)HttpStatusCode.BadRequest;
                string errors = response.ErrorDescription;
                return Json(errors);
            }
        }

        [HttpPost]
        public JsonResult Smev_Inn(Guid dataServicesId, FioType fio, string documentType, string documentSeries, string documentNumber, DateTime birthDate, DateTime documentDate)
        {
            GetInnSingularRequestData request = new GetInnSingularRequestData
            {
                Fio = fio,
                BirthDate = DateTime.Parse(birthDate.ToShortDateString()),
                DocumentType = documentType,
                DocumentSeriesNumber = $"{documentSeries} {documentNumber}",
                DocumentDate = DateTime.Parse(documentDate.ToShortDateString()),
                DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{fio.SecondName} {fio.FirstName} {fio.LastName}", 313)),
            };

            GetInnSingularResponseData response = SmevClient.RequestInnSingular(request);
            if (response.ResponseReports != null)
            {
                ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
                return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
            else
            {
                return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
        }

        /// <summary>
        /// Об ИНН физических лиц на основании полных паспортных данных по единичному запросу органов исполнительной власти
        /// </summary>
        /// <param name="dataServicesId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult Smev_RequestInnSingular(Guid dataServicesId, GetInnSingularRequestData request, string DocumentSerial, string DocumentNumber)
        {
            request.DocumentSeriesNumber = DocumentSerial + DocumentNumber;
            request.DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{request.Fio.SecondName} {request.Fio.FirstName} {request.Fio.LastName}", 319));
            GetInnSingularResponseData response = SmevClient.RequestInnSingular(request);
            if (response.ResponseReports != null)
            {
                ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
                return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
            else
            {
                return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
        }

        /// <summary>
        /// Проверка о соответствия паспортных данных и ИНН физического лица
        /// </summary>
        /// <param name="data_services_id"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult Smev_RequestPaspInn(Guid dataServicesId, GetPaspInnRequestData request)
        {
            request.DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{request.Fio.SecondName} {request.Fio.FirstName} {request.Fio.LastName} {request.Inn}", 320));
            GetPaspInnResponseData response = SmevClient.RequestPaspInn(request);
            if (response.ResponseReports != null)
            {
                ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
                return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
            else
            {
                return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
        }
        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  МВД  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        /// <summary>
        /// Сведения о наличии (отсутствии) судимости и (или) факта уголовного преследования либо о прекращении уголовного преследования, сведения о нахождении в розыске
        /// </summary>
        /// <param name="dataServicesId"></param>
        /// <param name="request"></param>
        /// <returns></returns>
        public JsonResult Smev_LbdSearch(Guid dataServicesId, IbdSearchRequestData request)
        {
            request.DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{request.Fio.SecondName} {request.Fio.FirstName} {request.Fio.LastName}", 1008));

            IbdSearchResponseData response = SmevClient.IbdSearch(request);
            if (response.ResponseReports != null)
            {
                ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
                return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }
            else
            {
                return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
            }

        }

        ///// <summary>
        ///// Запрос на предоставления сведений о наличии (отсутствии) судимости и (или) факта уголовного преследования, либо о прекращении уголовного преследования
        ///// </summary>
        ///// <param name="dataServicesId"></param>
        ///// <param name="exemplars"></param>
        ///// <param name="applicant"></param>
        ///// <param name="personal"></param>
        ///// <param name="addressee"></param>
        ///// <param name="previousNames"></param>
        ///// <param name="attachments"></param>
        ///// <returns></returns>
        //public JsonResult SmevGetGiacCriminal(Guid dataServicesId, int exemplars, GiacApplicantData applicant, GiacPersonalData personal, string addressee, string[] previousNames, string[] attachments)
        //{
        //    attachments = attachments?.Where(x => !string.IsNullOrEmpty(x)).ToArray();
        //    RequestAttachment[] _attach = new RequestAttachment[attachments.Length];
        //    FioType[] _fio = null;
        //    for (var i = 0; i <= attachments.Length - 1; i++)
        //    {
        //        var _t = attachments[i].Split('|');
        //        _attach[i] = new RequestAttachment
        //        {
        //            FileName = _t[0],
        //            IsFtpReference = true,
        //            AttachmentTypeCode = _t[1]
        //        };
        //    }
        //    if (previousNames != null)
        //    {
        //        _fio = new FioType[previousNames.Length];
        //        for (var i = 0; i <= previousNames.Length - 1; i++)
        //        {
        //            var _t = previousNames[i].Trim().Split(' ');
        //            if (_t.Length == 3)
        //            {
        //                _fio[i] = new FioType
        //                {
        //                    FirstName = _t[1],
        //                    LastName = _t[0],
        //                    SecondName = _t[2]
        //                };
        //            }
        //        }
        //    }

        //    GetGiacCriminalRequestData request = new GetGiacCriminalRequestData
        //    {
        //        Exemplars = exemplars,
        //        Applicant = applicant,
        //        Personal = personal,
        //        Addressee = addressee,
        //        Attachments = _attach,
        //        DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{personal.Fio.SecondName} {personal.Fio.FirstName} {personal.Fio.LastName}", 1002))
        //    };
        //    request.Personal.PreviousNames = _fio?.Where(x => x != null).ToArray();
        //    GetGiacCriminalResponseData response = SmevClient.RequestGiacCriminal(request);
        //    if (response.ResponseReports != null)
        //    {
        //        ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
        //        return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //    else
        //    {
        //        return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //}

        ///// <summary>
        ///// Передача подтверждения выдачи справки о наличии (отсутствии) судимости и (или) факта уголовного преследования, либо о прекращении уголовного преследования
        ///// </summary>
        ///// <param name="dataServicesId"></param>
        ///// <param name="mvdResponseNumber"></param>
        ///// <param name="date"></param>
        ///// <returns></returns>
        //public JsonResult SmevConfirmDeliveryGiacCriminal(Guid dataServicesId, string mvdResponseNumber, DateTime date)
        //{
        //    ConfirmDeliveryGiacCriminalRequestData request = new ConfirmDeliveryGiacCriminalRequestData
        //    {
        //        MvdResponseNumber = mvdResponseNumber,
        //        Date = DateTime.Parse(date.ToShortDateString()),
        //        DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"", 1003))
        //    };
        //    ConfirmDeliveryGiacCriminalResponseData response = SmevClient.ConfirmDeliveryGiacCriminal(request);
        //    if (response.ResponseReports != null)
        //    {
        //        ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
        //        return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //    else
        //    {
        //        return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //}

        ///// <summary>
        ///// Передача уведомления о невыдаче в 3-х месячный срок справки о наличии (отсутствии) судимости и (или) факта уголовного преследования, либо о прекращении уголовного преследования
        ///// </summary>
        ///// <param name="data_services_id"></param>
        ///// <returns></returns>
        //public JsonResult Smev_Notify3MonthsGiacCriminal(Guid dataServicesId, string mvdResponseNumber, DateTime date)
        //{
        //    Notify3MonthsGiacCriminalRequestData request = new Notify3MonthsGiacCriminalRequestData
        //    {
        //        MvdResponseNumber = mvdResponseNumber,
        //        Date = DateTime.Parse(date.ToShortDateString()),
        //        DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"", 1004))
        //    };
        //    Notify3MonthsGiacCriminalResponseData response = SmevClient.ConfirmDeliveryGiacCriminal(request);
        //    if (response.ResponseReports != null)
        //    {
        //        ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
        //        return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //    else
        //    {
        //        return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //}

        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ФССП  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|


        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ДОУ  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|


        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ПАРУС  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|


        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  РОСРЕЕСТР  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|


        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  Роспотребнадзор  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  Росимущество  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ЕСИА  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|


        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ФСС  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  МСП  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  ФК  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        ///// <summary>
        ///// Операция «Запрос на получение сведений о начислениях и статусах их квитирования с платежами, включая оплаченные»
        ///// </summary>
        ///// <param name="dataServicesId"></param>
        ///// <param name="request"></param>
        ///// <returns></returns>
        //[HttpPost]
        //public JsonResult Smev_GisGmpExport(Guid dataServicesId, GetGisGmpExportRequestData request)
        //{
        //    request.DataServicesRequestSmevId = Convert.ToString(SubmitSmevRequestSave(dataServicesId, $"{request.PayerId} {request.SupplierBillId} {request.PayerInnFl} {request.PayerSnils} {request.PayerInnUl} {request.PayerKpp} ", 1201));
        //    GetGisGmpExportResponseData response = SmevClient.RequestGisGmpExport(request);
        //    if (response.ResponseReports != null)
        //    {
        //        ResponseReport fullReport = response.ResponseReports.SingleOrDefault(r => r.ReportType == ResponseReportType.Full);
        //        return Json(new { _response = Convert.ToBase64String(fullReport.PdfDocument), errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //    else
        //    {
        //        return Json(new { _response = "", errorText = response.Fault != null ? response.Fault.ErrorText : null });
        //    }
        //}
        #endregion

        #region |-|-|-|-|-|-|-|-|-|-|-|-|-|-[  КЦР  ]-|-|-|-|-|-|-|-|-|-|-|-|-|-|

        /// <summary>
        /// Получение данных цифрового регламента
        /// </summary>
        /// <param name="crId">идентификатор цифрового регламента</param>        
        /// <returns></returns>
        public JsonResult RequestKcrGetDigitalRegulationsData(string[] crId, string[] serviceId, object[] data)
        {
            StringBuilder error = new StringBuilder();
            if (crId != null && crId.Length > 0)
            {
                for (int i = 0; i < crId.Length; i++)
                {
                    if (!string.IsNullOrWhiteSpace(crId[i]))
                    {
                        Guid? sprServiceId = null;
                        if (serviceId != null && Guid.TryParse(serviceId[i], out _))
                        {
                            sprServiceId = Guid.Parse(serviceId[i]);
                        }

                        string sprKcrId = crId[i];
                        if (repository.SprKcr.FirstOrDefault(s => s.id == sprKcrId) == null)
                        {
                            repository.Insert(new Spr_Kcr
                            {
                                id = crId[i],
                                spr_services_id = sprServiceId,
                            });
                        }                        

                        var response = SmevClient.RequestKcrGetDigitalRegulationsData(new KcrRequestData
                        {
                            KcrId = crId[i]
                        });

                        if (response.Fault != null)
                        {
                            error.AppendLine(response.Fault.ErrorText);
                        }
                    }
                }

                return Json(new { _response = "", errorText = string.IsNullOrWhiteSpace(error.ToString()) ? null : error.ToString() });
            }

            return null;
        }        

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Справочники  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult SmevGetDictionary(DictionaryType type)
        {
            var result = SmevClient.GetDictionary(type);
            return Json(result, JsonRequestBehavior.AllowGet);
        }


        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Бланки  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        #endregion

        #region |-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-[  Запрос ответа  ]-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|-=|=-|

        /// <summary>
        /// Запрос ответа
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public JsonResult SmevRequestResult(Guid id)
        {
            //Smev_ReadResponce(id);  // отмечаем ответ как прочитанный
            SmevRequestData request = new SmevRequestData { DataServicesRequestSmevId = Convert.ToString(id) }; // запрос
            SmevResponseData response = SmevClient.GetRequestResult(request);  // получает ответ
            ResponseReport fullReport = response?.ResponseReports?.SingleOrDefault(r => r.ReportType == ResponseReportType.Full); // файл полного ответа
            //AdditionalForm additional = response?.AdditionalForms.FirstOrDefault(); // файл краткого ответа
            ResponseReport intermediateReport = response?.ResponseReports?.SingleOrDefault(r => r.ReportType == ResponseReportType.IntermediateResponse); // файл промежуточного ответа
            ExtractedDocument attachmentsReport = response?.ExtractedResponseDocuments?.FirstOrDefault(r => r.MimeType == MimeTypesMap.GetMimeType("pdf")); // файл вложения
            string __response = null;
            //if (additional != null)
            //    __response = Convert.ToBase64String(additional.PdfDocument);
            //else 
            if (fullReport != null)
                __response = Convert.ToBase64String(fullReport.PdfDocument);
            else if (intermediateReport != null)
                __response = Convert.ToBase64String(intermediateReport.PdfDocument);
            return Json(new
            {
                _response = __response,
                _errorText = response?.Fault?.ErrorText,
                _attachmentsCount = response?.ExtractedResponseDocuments?.Length,
                _attachments = attachmentsReport?.FileContent != null ? Convert.ToBase64String(attachmentsReport?.FileContent) : null
            });
        }


        #endregion
    }
}