namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesRoutesStageNextSelectResult
    {
        [Display(Name = "����")]
        public string out_stage_name { get; set; }

        [Display(Name = "����")]
        public int? out_spr_routes_stage_id { get; set; }
    }
}
