namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_animal_type_hunting_season")]
    public partial class spr_animal_type_hunting_season
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Тип животного")]
        public Guid spr_animal_type_id { get; set; }

        [Display(Name = "Наименование")]
        public string name_season { get; set; }

        [Display(Name = "День начала")]
        public int day_start { get; set; }

        [Display(Name = "Месяц начала")]
        public int month_start { get; set; }

        [Display(Name = "День окончания")]
        public int day_stop { get; set; }

        [Display(Name = "Месяц окончания")]
        public int month_stop { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Display(Name = "Дата")]
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

        public virtual spr_animal_type spr_animal_type { get; set; }
    }
}
