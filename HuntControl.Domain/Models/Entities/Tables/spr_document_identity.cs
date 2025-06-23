namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_document_identity")]
    public partial class spr_document_identity
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string document_name { get; set; }

        [Required]
        [Display(Name = "Краткое наименование")]
        public string document_name_small { get; set; }

        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Display(Name = "Дата фактическая")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }
    }
}
