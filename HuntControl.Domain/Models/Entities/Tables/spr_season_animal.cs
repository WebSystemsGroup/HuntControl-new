namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_season_animal")]
    public partial class spr_season_animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public int spr_season_id { get; set; }

        public Guid spr_animal_id { get; set; }

        [Display(Name ="Норма в день")]
        public int? norm_day { get; set; }

        [Display(Name ="Норма в сезон")]
        public int? norm_season { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio_add { get; set; }

        public bool is_remove { get; set; }

        public DateTime date_add { get; set; }

        public virtual spr_animal spr_animal { get; set; }

        public virtual spr_season spr_season { get; set; }
    }
}
