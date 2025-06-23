using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class OrganizationViewModel
    {
        public IEnumerable<spr_organization> SprOrganizationList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}