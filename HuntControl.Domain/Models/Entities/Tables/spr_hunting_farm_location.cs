namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_location")]
    public partial class spr_hunting_farm_location
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "Охотугодье")]
        public Guid spr_hunting_farm_id { get; set; }

        [Required]
        [Display(Name = "Широта")]
        public decimal latitude { get; set; }

        [Required]
        [Display(Name = "Долгота")]
        public decimal longitude { get; set; }

        [Required]
        [Display(Name = "Индекс (Порядок координат)")]
        public int index_ { get; set; }


        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
    }
}
