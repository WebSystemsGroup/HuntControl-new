namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainGeneralInformationResult
    {
        public int out_count_hunting_lic_all { get; set; }
        public int out_count_hunting_lic_cancelled { get; set; }
        public int out_count_permission { get; set; }
        public int out_count_violation { get; set; }
    }
}
