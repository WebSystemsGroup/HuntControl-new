namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportCountViolationsEmployees
    {
        [Display(Name = "Ñîòğóäíèê")]
        public string out_employees_fio { get; set; }

       
        [Display(Name = "ÓÍ")]
        public int out_un { get; set; }

        [Display(Name = "ÏÑ")]
        public int out_ps { get; set; }

        [Display(Name = "ÎÂ")]
        public int out_ov { get; set; }

        [Display(Name = "ÏÂ")]
        public int out_pv { get; set; }

        [Display(Name = "ØÎ")]
        public int out_sho { get; set; }

        [Display(Name = "ÓÍ20")]
        public int out_un20 { get; set; }

        [Display(Name = "ÏÑ20")]
        public int out_ps20 { get; set; }

        [Display(Name = "ÍÏ")]
        public int out_np { get; set; }

        [Display(Name = "ÍÏÏ")]
        public int out_npp { get; set; }

        [Display(Name = "ÏĞÊ")]
        public int out_prk { get; set; }

        [Display(Name = "ÁÑ")]
        public int out_bs { get; set; }
        
    }
}
