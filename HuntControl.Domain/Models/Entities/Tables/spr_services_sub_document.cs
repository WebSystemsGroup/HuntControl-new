namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_document")]
    public partial class spr_services_sub_document
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_sub_id { get; set; }

        [Display(Name = "Документ")]
        public Guid spr_documents_id { get; set; }

        [Display(Name = "Обязательный")]
        public short document_needs { get; set; }

        [Display(Name = "Тип")]
        public short document_type { get; set; }

        [Display(Name = "Количество копий")]
        public short document_count { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(8000)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_documents spr_documents { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }
    }
}
