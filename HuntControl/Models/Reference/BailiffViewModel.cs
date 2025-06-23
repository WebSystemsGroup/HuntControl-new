using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class BailiffViewModel
    {
        public IEnumerable<spr_bailiffs> SprBailiffList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}