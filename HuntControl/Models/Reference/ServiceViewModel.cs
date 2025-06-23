using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class ServiceViewModel
    {
        public IEnumerable<spr_services> ServiceList { get; set; }
        public IEnumerable<spr_services_sub> SubServiceList { get; set; }
        public IEnumerable<spr_services_sub_active> SubServiceActiveList { get; set; }
        public IEnumerable<spr_services_sub_file_folder> SubServiceFolderList { get; set; }
        public IEnumerable<spr_services_sub_file> SubServiceFileList { get; set; }
        public IEnumerable<spr_services_sub_way_get_join> SubServiceWayGetList { get; set; }
        public IEnumerable<spr_services_sub_way_get_result_join> SubServiceWayGetResultList { get; set; }
        public IEnumerable<spr_services_sub_result_doc> SubServiceResultDocList { get; set; }
        public IEnumerable<spr_services_sub_customer> SubServiceCustomerList { get; set; }
        public IEnumerable<spr_services_sub_document> SubServiceDocumentList { get; set; }
        public IEnumerable<spr_services_sub_failure> SubServiceFailureList { get; set; }
        public IEnumerable<spr_services_sub_failure_doc> SubServiceFailureDocList { get; set; }
        public IEnumerable<spr_services_sub_tariff> CustomerTariffList { get; set; }
        public IEnumerable<spr_services_sub_document_customer> CustomerDocumentList { get; set; }
        public IEnumerable<spr_services_sub_smev_request_join> ServicesSubSmevRequestList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}