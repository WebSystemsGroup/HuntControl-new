namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic_perm_hunting")]
    public partial class data_customer_hunting_lic_perm_hunting
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }
        
        public Guid data_customer_hunting_lic_perm_id { get; set; }
        
        [Required]
        [Display(Name = "Охотугодье")]
        public Guid? spr_hunting_farm_id { get; set; }
        
        public virtual data_customer_hunting_lic_perm data_customer_hunting_lic_perm { get; set; }
        
        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
        
    }
}
