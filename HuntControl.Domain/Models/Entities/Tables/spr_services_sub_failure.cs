namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_failure")]
    public partial class spr_services_sub_failure
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_sub_id { get; set; }

        [Required]
        [StringLength(5000)]
        [Display(Name = "Текст отказа")]
        public string failure_text { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [Display(Name = "Дата добавления")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [StringLength(1000)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Required]
        [StringLength(5000)]
        [Display(Name = "Нормативно правовые акты")]
        public string legal_act { get; set; }
        
        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }
    }
}
