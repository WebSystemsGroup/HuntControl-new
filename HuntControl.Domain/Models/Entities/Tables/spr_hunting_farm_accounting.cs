namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_accounting")]
    public partial class spr_hunting_farm_accounting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "Кол-во")]
        public int count_animal { get; set; }

        [Required]
        [Display(Name = "Способ учёта")]
        public Guid spr_animal_method_account_id { get; set; }

        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [Display(Name = "Охотугодье")]
        public Guid spr_hunting_farm_id { get; set; }

        [Required]
        [Display(Name = "Животное")]
        public Guid spr_animal_id { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [Required]
        [Display(Name = "Пол животного")]
        public int animal_sex { get; set; }

        [Required]
        [Display(Name = "Возраст животного")]
        public int animal_age { get; set; }

        [Required]
        [Display(Name = "Год")]
        public int? year_ { get; set; }

        public virtual spr_animal spr_animal { get; set; }
        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
        public virtual spr_animal_method_account spr_animal_method_account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_limit> spr_hunting_farm_limit { get; set; }
    }
}
