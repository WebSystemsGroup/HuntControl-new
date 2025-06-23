using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_season_forms")]
    public partial class spr_hunting_farm_season_forms
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Сезон")]
        public Guid spr_hunting_farm_season_id { get; set; }

        [Display(Name = "Серия")]
        public string serial_form { get; set; }

        [Display(Name = "Начальный номер")]
        public int number_form_start { get; set; }

        [Display(Name = "Конечный номер")]
        public int number_form_stop { get; set; }

        [Display(Name = "Выдал")]
        public string fio_issue { get; set; }

        [Display(Name = "Получил")]
        public string fio_got { get; set; }

        [Display(Name = "Количество бланков")]
        public int count_form { get; set; }

        [Required]
        [Display(Name = "Дата выдачи")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_issue { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата фактическая")]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_hunting_farm_season spr_hunting_farm_season { get; set; }
    }
}
