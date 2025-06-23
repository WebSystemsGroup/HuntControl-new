namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic_perm_back_animal")]
    public partial class data_customer_hunting_lic_perm_back_animal
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Разрешение")]
        public Guid data_customer_hunting_lic_perm_back_id { get; set; }

        [Display(Name = "Животное")]
        public Guid spr_animal_id { get; set; }

        [Display(Name = "Количество животных")]
        public int count_animal { get; set; }

        [Display(Name = "Дата фактическая")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual data_customer_hunting_lic_perm_back data_customer_hunting_lic_perm_back { get; set; }

        public virtual spr_animal spr_animal { get; set; }
    }
}
