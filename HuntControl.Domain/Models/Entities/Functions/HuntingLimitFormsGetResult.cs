namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingLimitFormsGetResult
    {
        public string out_serial_form { get; set; }
        public int out_number_form_start { get; set; }
        public int out_number_form_stop { get; set; }
        public int out_limit_form { get; set; }
        public int out_limit_form_fact { get; set; }
        public int out_limit_form_all { get; set; }
    }
}
