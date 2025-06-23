using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class CustomerAddModel
    {
        public data_customer data_customer { get; set; }
        public data_customer_hunting_lic data_customer_hunting_lic { get; set; }
    }

}