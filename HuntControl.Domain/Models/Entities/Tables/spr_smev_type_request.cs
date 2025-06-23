namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_smev_type_request")]
    public partial class spr_smev_type_request
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public short id { get; set; }

        [Required]
        [StringLength(30)]
        public string type_name { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_smev_request> spr_smev_request { get; set; }
    }
}
