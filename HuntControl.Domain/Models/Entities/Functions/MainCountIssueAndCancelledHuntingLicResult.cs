namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainCountIssueAndCancelledHuntingLicResult
    {
        public string out_month { get; set; }
        public int out_count_issue { get; set; }
        public int out_count_cancelled { get; set; }
    }
}
