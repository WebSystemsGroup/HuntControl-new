namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class EpguVisitTimeSelectResult
    {
        public string out_data_services_info_id { get; set; }
        public DateTime out_visit_time { get; set; }
        public string out_fio { get; set; }
        public string out_spr_services_sub_name { get; set; }

    }
}
