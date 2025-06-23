using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class AnimalViewModel
    {

        public IEnumerable<spr_animal> AnimalList { get; set; }
        public IEnumerable<spr_animal_group> AnimalGroupList { get; set; }
        public IEnumerable<spr_animal_group_type> AnimalGroupTypeList { get; set; }
        public IEnumerable<spr_animal_method_account> AnimalAccountMethodList { get; set; }
        public IEnumerable<spr_method_remove> MethodRemoveList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}