using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class ApplicantPageViewModel
    {
        public IEnumerable<DataCustomerInfoGet> dataCustomerInfoGetsList { get; set; }
        public IEnumerable<CustomerSelectResult> CustomerSelectList { get; set; }
        public IEnumerable<CustomerViolationsSelectResult> ViolationList { get; set; }
        public IEnumerable<data_customer> CustomerList { get; set; }
        public IEnumerable<data_customer_hunting_lic> HuntingLicList { get; set; }
        public IEnumerable<data_customer_hunting_lic_perm> HuntingLicPermList { get; set; }
        public IEnumerable<data_customer_hunting_lic_perm_payment> HuntingLicPermPaymentList { get; set; }
        public IEnumerable<data_customer_hunting_lic_perm_back> HuntingLicPermBackList { get; set; }
        public IEnumerable<data_change_log> DataChangeLogList { get; set; }
        public IEnumerable<data_history_change_log> DataHistoryChangeLogList { get; set; }
        public IEnumerable<data_customer_violations_file> ViolationFileList { get; set; }
        public IEnumerable<spr_season> SprSeasonList { get; set; }
        public PageInfo PageInfo { get; set; }
        public string Search { get; set; }
    }

    public class AnimalLimitModel
    {
        public Guid SprAnimalId { get; set; }
        public int LimitDay { get; set; }
        public int LimitSeason { get; set; }
        public int AnimalSex { get; set; }
        public int AnimalAge { get; set; }
    }

    public class data_history_change_log 
    {
        public string applicantFio { get; set; }
        public data_change_log change { get; set; }
    }
}