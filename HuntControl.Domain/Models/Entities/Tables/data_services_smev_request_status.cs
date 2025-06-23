namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_smev_request_status")]
    public partial class data_services_smev_request_status
    {
        public Guid id { get; set; }

        public Guid data_services_smev_request_id { get; set; }

        [StringLength(70)]
        public string message_id { get; set; }

        [StringLength(70)]
        public string request_id_ref { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_request { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? time_request { get; set; }

        public virtual data_services_smev_request data_services_smev_request { get; set; }
    }
}
