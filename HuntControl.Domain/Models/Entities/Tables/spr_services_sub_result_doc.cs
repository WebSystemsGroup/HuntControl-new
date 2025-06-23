namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_result_doc")]
    public partial class spr_services_sub_result_doc
    {
        [Display(Name = "Документ")]
        public Guid spr_documents_id { get; set; }

        [Display(Name = "Результат")]
        public bool document_result { get; set; }

        [Required]
        [Display(Name = "Способ получения")]
        public string document_method { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Срок хранения")]
        public string document_period_provider { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Подуслуга")]
        public Guid spr_services_sub_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_documents spr_documents { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }
    }
}
