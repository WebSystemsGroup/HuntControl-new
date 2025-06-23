namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportCountViolations
    {
        [Display(Name = "������")]
        public string out_violations_name { get; set; }

       
        [Display(Name = "��")]
        public int out_un { get; set; }

        [Display(Name = "��")]
        public int out_ps { get; set; }

        [Display(Name = "��")]
        public int out_ov { get; set; }

        [Display(Name = "��")]
        public int out_pv { get; set; }

        [Display(Name = "��")]
        public int out_sho { get; set; }

        [Display(Name = "��20")]
        public int out_un20 { get; set; }

        [Display(Name = "��20")]
        public int out_ps20 { get; set; }

        [Display(Name = "��")]
        public int out_np { get; set; }

        [Display(Name = "���")]
        public int out_npp { get; set; }

        [Display(Name = "���")]
        public int out_prk { get; set; }

        [Display(Name = "��")]
        public int out_bs { get; set; }

        [Display(Name = "��������")]
        public string out_violations_part_text { get; set; }

    }
}
