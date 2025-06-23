using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class ViolationViewModel
    {
        public IEnumerable<ViolationSelectResult> ViolationSelectResultList { get; set; }
        public IEnumerable<ViolationsCustomerSelectResult> ViolationsCustomerSelectResultList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}