namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_stop")]
    public partial class spr_services_sub_stop
    {
        public Guid id { get; set; }

        public Guid spr_services_sub_id { get; set; }

        [Required]
        [StringLength(1000)]
        public string stop_text { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        public DateTime set_date { get; set; }

        [StringLength(1000)]
        public string commentt { get; set; }

        public short count_day { get; set; }

        public short spr_services_sub_week_id { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }
    }
}
