namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_employees_hunting_farm")]
    public partial class spr_employees_hunting_farm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_employees_id { get; set; }

        [Display(Name ="Охотогодье")]
        public Guid spr_hunting_farm_id { get; set; }

        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio_add { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        public bool? is_remove { get; set; }

        [StringLength(70)]
        public string employees_fio_remove { get; set; }

        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        public string commentt_remove { get; set; }

        [StringLength(20)]
        public string ip_address_add { get; set; }

        [StringLength(20)]
        public string ip_address_modify { get; set; }

        public virtual spr_employees spr_employees { get; set; }

        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
    }
}
