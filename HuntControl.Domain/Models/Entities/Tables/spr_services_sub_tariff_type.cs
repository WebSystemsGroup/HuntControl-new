namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_tariff_type")]
    public partial class spr_services_sub_tariff_type
    {
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        public string type_name { get; set; }

        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services> data_services { get; set; }
    }
}
