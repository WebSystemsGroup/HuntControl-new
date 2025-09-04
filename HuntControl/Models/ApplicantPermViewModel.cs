using HuntControl.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuntControl.WebUI.Models
{
    public class ApplicantPermViewModel
    {
        public IEnumerable<DataCustomerHuntingLicPermSelect> dataCustomerInfoGetsList { get; set; }
        public PageInfo PageInfo { get; set; }
        public string Search { get; set; }
    }
}