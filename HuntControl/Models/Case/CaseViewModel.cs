using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class CaseViewModel
    {
        public IEnumerable<CaseSelectResult> CaseSelectResultList { get; set; }
        //public IEnumerable<CaseArchiveServices> CaseArchiveServicesList { get; set; }
        public IEnumerable<spr_services_sub_type_recipient> SprServicesSubTypeRecipientList { get; set; }
        public IEnumerable<spr_services_sub> SprServicesSubList { get; set; }
        public IEnumerable<GetCustomerInfoResult> GetCustomerInfoResultList { get; set; }
        public IEnumerable<SprServicesSubSelectResult> SprServicesSubSelectResultList { get; set; }
        public IEnumerable<SprServicesSubCustomerTypeRecipientSelect> SprServicesSubCustomerTypeRecipientSelectResultList { get; set; }
        public IEnumerable<SprServicesSubTariffSelectResult> SprServicesSubTariffSelectResultList { get; set; }
        public int Recipient { get; set; }
        public Guid ServiceId { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}