namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_standards_file")]
    public partial class spr_standards_file
    {
        public Guid id { get; set; }

        [Required]
        [StringLength(255)]
        public string file_name { get; set; }

        [Required]
        [StringLength(10)]
        public string file_ext { get; set; }

        public int file_size { get; set; }

        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(8000)]
        public string commentt { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_file> spr_services_sub_file { get; set; }
    }
}
