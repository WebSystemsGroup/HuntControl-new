namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_employees_reminder")]
    public partial class data_employees_reminder
    {
        public Guid id { get; set; }

        [StringLength(70)]
        public string data_services_info_id { get; set; }

        [StringLength(70)]
        public string commentt { get; set; }

        public DateTime set_date { get; set; }

        public Guid spr_employees_id { get; set; }

        public DateTime date_finish { get; set; }

        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(30)]
        public string customer_tel1 { get; set; }

        [StringLength(30)]
        public string customer_tel2 { get; set; }

        [StringLength(70)]
        public string customer_email { get; set; }
        [StringLength(1500)]
        public string service_name { get; set; }

        public Guid data_customer_id { get; set; }

        public virtual data_customer data_customer { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
