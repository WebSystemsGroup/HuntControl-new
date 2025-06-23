using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_season")]
    public partial class spr_hunting_farm_season
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Вид охотугодья")]
        public Guid spr_hunting_farm_id { get; set; }

        [Required]
        [Display(Name = "Начало периода")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_start { get; set; }

        [Required]
        [Display(Name = "Окончание периода")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_stop { get; set; }

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

        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        //[Required]
        //[Display(Name = "Группа видов")]
        //public Guid spr_animal_group_type_id { get; set; }

        [Required]
        [Display(Name = "Сезон охоты")]
        public int spr_season_id { get; set; }

        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
        //public virtual spr_animal_group_type spr_animal_group_type { get; set; }
        public virtual spr_season spr_season { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_season_animal> spr_hunting_farm_season_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_season_forms> spr_hunting_farm_season_forms { get; set; }
    }
}
