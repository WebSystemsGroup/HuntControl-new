namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_employees_alert")]
    public partial class data_employees_alert
    {
        public Guid id { get; set; }

        [StringLength(70)]
        public string data_services_info_id { get; set; }

        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(1500)]
        public string service_name { get; set; }

        [StringLength(350)]
        public string request_name { get; set; }

        [StringLength(70)]
        public string commentt { get; set; }

        public DateTime set_date { get; set; }

        [StringLength(30)]
        public string customer_tel1 { get; set; }

        [StringLength(30)]
        public string customer_tel2 { get; set; }

        [StringLength(70)]
        public string customer_email { get; set; }

        public Guid? data_services_id { get; set; }

        public int spr_employee_alert_id { get; set; }

        public Guid spr_employees_id { get; set; }

        public Guid? data_services_commentt_id { get; set; }

        public virtual data_services data_services { get; set; }

        public virtual spr_employee_alert spr_employee_alert { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
