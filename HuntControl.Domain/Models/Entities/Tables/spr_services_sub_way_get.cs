namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_way_get")]
    public partial class spr_services_sub_way_get
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public spr_services_sub_way_get()
        {
            spr_services_sub_way_get_join = new HashSet<spr_services_sub_way_get_join>();
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
        public string employees_fio { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }
        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_way_get_join> spr_services_sub_way_get_join { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services> data_services { get; set; }
    }
}
