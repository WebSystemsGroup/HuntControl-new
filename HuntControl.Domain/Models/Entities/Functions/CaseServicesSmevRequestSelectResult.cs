namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesSmevRequestSelectResult
    {
        public int? out_spr_smev_request_id { get; set; }

        [Display(Name = "Наименование СМЭВ")]
        public string out_smev_name { get; set; }

        [Display(Name = "Наименование запроса")]
        public string out_request_name { get; set; }

        [Display(Name = "Тип запроса")]
        public string out_type_name { get; set; }
    }
}