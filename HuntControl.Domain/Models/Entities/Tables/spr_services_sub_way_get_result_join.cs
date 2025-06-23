namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_way_get_result_join")]
    public partial class spr_services_sub_way_get_result_join
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_sub_id { get; set; }

        [Display(Name = "Cпособ обращения")]
        public Guid spr_services_sub_way_get_result_id { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }

        public virtual spr_services_sub_way_get_result spr_services_sub_way_get_result { get; set; }
    }
}
