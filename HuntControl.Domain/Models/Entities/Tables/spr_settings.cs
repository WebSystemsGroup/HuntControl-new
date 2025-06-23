namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_settings")]
    public partial class spr_settings
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [Required]
        [StringLength(70)]
        public string param_name { get; set; }

        [Required]
        [StringLength(255)]
        public string param_value { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }
    }
}
