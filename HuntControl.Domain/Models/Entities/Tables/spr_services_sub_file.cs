namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_file")]
    public partial class spr_services_sub_file
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Папка")]
        public Guid spr_services_sub_file_folder_id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [Display(Name = "Файл")]
        public Guid spr_standards_file_id { get; set; }
        

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub_file_folder spr_services_sub_file_folder { get; set; }

        public virtual spr_standards_file spr_standards_file { get; set; }
    }
}
