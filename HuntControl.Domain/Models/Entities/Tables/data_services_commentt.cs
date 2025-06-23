namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_commentt")]
    public partial class data_services_commentt
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        public Guid data_services_id { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        [Required]
        public Guid spr_employees_id { get; set; }

        [Required]
        [StringLength(20000)]
        public string commentt { get; set; }
        
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime date_enter { get; set; }

        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Дата удаления")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }
        public int? epgu { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_commentt_recipient> data_services_commentt_recipient { get; set; }

        public virtual data_services data_services { get; set; }

        public virtual spr_employees spr_employees { get; set; }

    }
}
