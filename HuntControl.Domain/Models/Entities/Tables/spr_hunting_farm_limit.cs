namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_limit")]
    public partial class spr_hunting_farm_limit
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_hunting_farm_season_animal_id { get; set; }

        [Display(Name = "Учетные данные")]
        public Guid spr_hunting_farm_accounting_id { get; set; }

        [Display(Name = "Норма на сезон")]
        public int limit_season { get; set; }

        [Display(Name = "Норма на день")]
        public int limit_day { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

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

        public virtual spr_hunting_farm_season_animal spr_hunting_farm_season_animal { get; set; }
        public virtual spr_hunting_farm_accounting spr_hunting_farm_accounting { get; set; }
    }
}
