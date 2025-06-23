namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_customer_call")]
    public partial class data_services_customer_call
    {
        public Guid id { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        public Guid spr_employees_id { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [Required]
        [StringLength(100)]
        public string customer_name { get; set; }

        public DateTime date_call { get; set; }

        [Required]
        [StringLength(30)]
        public string customer_tel { get; set; }

        public Guid data_services_id { get; set; }

        [Required]
        [StringLength(10)]
        public string sound_format { get; set; }

        [Required]
        [StringLength(10)]
        public string time_talk { get; set; }

        public bool? save_ftp { get; set; }

        public virtual data_services data_services { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
