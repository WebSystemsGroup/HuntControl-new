namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_season_animal")]
    public partial class spr_hunting_farm_season_animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "Плотность обитания")]
        public decimal density_habitat { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Display(Name = "Сезон")]
        public Guid spr_hunting_farm_season_id { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [Display(Name = "Животное")]
        public Guid spr_animal_id { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Начало периода")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? date_start { get; set; }

        [Column(TypeName ="date")]
        [Display(Name = "Окончание периода")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? date_stop { get; set; }

        public virtual spr_hunting_farm_season spr_hunting_farm_season { get; set; }
        public virtual spr_animal spr_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_limit> spr_hunting_farm_limit { get; set; }
    }
}
