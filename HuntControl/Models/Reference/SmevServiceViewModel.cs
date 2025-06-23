using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class SmevServiceViewModel
    {
        public IEnumerable<spr_smev> SmevServiceList { get; set; }
        public IEnumerable<spr_smev_request> SmevServiceRequestList { get; set; }
        public IEnumerable<spr_smev_type_request> SmevServiceRequestTypeList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}