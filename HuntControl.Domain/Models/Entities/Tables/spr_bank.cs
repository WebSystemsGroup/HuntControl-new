namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_bank")]
    public partial class spr_bank
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Наименование")]
        public string bank_name { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "БИК")]
        public string bank_bik { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Адрес")]
        public string address_full { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Кор.счёт")]
        public string bank_ks { get; set; }

        [Display(Name = "Дата")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(8000)]
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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_legal_person> spr_legal_person { get; set; }
    }
}
