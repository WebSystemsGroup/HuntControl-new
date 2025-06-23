using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class CaseDetailViewModel
    {
        public IEnumerable<CaseServicesRoutesStageSelectResult> CaseServicesRoutesStageSelectResultList { get; set; }
        public IEnumerable<CaseServicesSmevSelectResult> FuncSmevList { get; set; }
        public IEnumerable<data_services_routes_stage> DataServicesRoutesStages { get; set; }
        public IEnumerable<data_services_customer> DataServicesCustomers { get; set; }
        public IEnumerable<spr_services_sub_file_folder> SprServicesSubFileFolderList { get; set; }
        public IEnumerable<spr_services_sub_file> SprServicesSubFileList { get; set; }
        public IEnumerable<data_change_log> DataChangeLogList { get; set; }
        public IEnumerable<data_services_commentt> DataServicesCommentsList { get; set; }
        public IEnumerable<data_services> DataServiceList { get; set; }
        public IEnumerable<data_services_commentt_recipient> DataServicesCommentsRecipientsList { get; set; }
        public Guid DataServiceId { get; set; }
        public Guid EmployeeId { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}