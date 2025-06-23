using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class EmployeeViewModel
    {
        public IEnumerable<spr_employees> SprEmployees { get; set; }
        public IEnumerable<spr_employees_role_join> SprEmployeeRoleJoins { get; set; }
        public IEnumerable<spr_employees_department> SprEmployeesDepartmentList { get; set; }
        public IEnumerable<spr_employees_job_pos> SprEmployeesJobPosList { get; set; }
        public IEnumerable<spr_employees_hunting_farm> SprEmployeesHuntingFarmList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}