namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_animal_location")]
    public partial class spr_animal_location
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "Животное")]
        public Guid spr_animal_id { get; set; }

        [Required]
        [Display(Name = "Широта")]
        public decimal latitude { get; set; }

        [Required]
        [Display(Name = "Долгота")]
        public decimal longitude { get; set; }


        public virtual spr_animal spr_animal { get; set; }
    }
}
