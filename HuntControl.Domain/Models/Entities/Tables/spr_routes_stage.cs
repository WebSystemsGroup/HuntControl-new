namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_routes_stage")]
    public partial class spr_routes_stage
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public spr_routes_stage()
        {
            data_services_routes_stage = new HashSet<data_services_routes_stage>();
            spr_routes_stage_next = new HashSet<spr_routes_stage_next>();
            spr_routes_stage_next1 = new HashSet<spr_routes_stage_next>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(50)]
        public string stage_name { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        public DateTime set_date { get; set; }

        public short count_day_execution { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_routes_stage> data_services_routes_stage { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_routes_stage_next> spr_routes_stage_next { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_routes_stage_next> spr_routes_stage_next1 { get; set; }
    }
}
