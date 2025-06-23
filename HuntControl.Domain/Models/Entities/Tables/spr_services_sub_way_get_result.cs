namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_way_get_result")]
    public partial class spr_services_sub_way_get_result
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public spr_services_sub_way_get_result()
        {
            spr_services_sub_way_get_result_join = new HashSet<spr_services_sub_way_get_result_join>();
        }

        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        public string name_way { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        public string set_employees_fio { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_way_get_result_join> spr_services_sub_way_get_result_join { get; set; }
    }
}
