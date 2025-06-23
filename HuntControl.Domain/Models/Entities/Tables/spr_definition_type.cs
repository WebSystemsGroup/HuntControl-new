namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_definition_type")]
    public partial class spr_definition_type
    {
        public int id { get; set; }

        [Required]
        [Display(Name = "Наименование")]
        public string definition_name { get; set; }
    }
}
