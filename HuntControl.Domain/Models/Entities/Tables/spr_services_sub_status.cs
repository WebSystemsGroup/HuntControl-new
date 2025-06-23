namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_status")]
    public partial class spr_services_sub_status
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short id { get; set; }

        [Required]
        [StringLength(30)]
        public string status_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services> data_services { get; set; }
    }
}
