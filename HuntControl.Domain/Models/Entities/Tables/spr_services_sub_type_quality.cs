namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_type_quality")]
    public partial class spr_services_sub_type_quality
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public spr_services_sub_type_quality()
        {
            spr_services_sub_type_quality_join = new HashSet<spr_services_sub_type_quality_join>();
        }

        [Required]
        [StringLength(50)]
        public string type_name { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_type_quality_join> spr_services_sub_type_quality_join { get; set; }
    }
}
