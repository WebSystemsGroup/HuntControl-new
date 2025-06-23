namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_file_folder")]
    public partial class spr_services_sub_file_folder
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(50)]
        [Display(Name = "Папка")]
        public string folder_name { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        public Guid spr_services_sub_id { get; set; }

        [Display(Name = "Дата добавления")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_file> spr_services_sub_file { get; set; }
    }
}
