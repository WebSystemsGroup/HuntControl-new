namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_smev_log")]
    public partial class data_services_smev_log
    {
        public Guid id { get; set; }

        public DateTime set_date { get; set; }

        public string log_text { get; set; }

        public short? log_type { get; set; }

        public Guid? data_services_smev_request_id { get; set; }

        public virtual data_services_smev_request data_services_smev_request { get; set; }
    }
}
