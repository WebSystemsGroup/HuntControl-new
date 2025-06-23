namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainCountEpguAndMfcResult
    {
        public string out_month { get; set; }
        public int out_count_mfc { get; set; }
        public int out_count_epgu { get; set; }
        public int out_count_personally { get; set; }
    }
}
