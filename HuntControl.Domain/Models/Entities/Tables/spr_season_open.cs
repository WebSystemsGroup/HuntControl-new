namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_season_open")]
    public partial class spr_season_open
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "Сезон")]
        public int spr_season_id { get; set; }

        [Required]
        [Column(TypeName = "date")]
        [Display(Name = "Дата начала")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_start { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата окончания")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? date_stop { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Сотрудник")]
        public string employees_fio { get; set; }

        [Required]
        [Display(Name = "Дата создания")]
        public DateTime set_date { get; set; }

        [StringLength(1000)]
        [Display(Name = "Комментарий")]
        public string commentt { get; set; }

        [Display(Name = "Госпошлина")]
        public decimal? tariff_ { get; set; }

        [Display(Name = "Сбор")]
        public decimal? charge_ { get; set; }

        public virtual spr_season spr_season { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_season_open_animal> spr_season_open_animal { get; set; }
    }
}
