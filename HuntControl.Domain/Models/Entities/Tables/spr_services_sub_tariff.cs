namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_tariff")]
    public partial class spr_services_sub_tariff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_sub_customer_id { get; set; }

        [Display(Name = "Тип отсчета дней")]
        public short spr_services_sub_week_id { get; set; }

        [Display(Name = "Тип тарифа")]
        public short spr_services_sub_tariff_type_id { get; set; }

        [Required]
        [Display(Name = "Дни на обработку")]
        public short count_day_processing { get; set; }

        [Required]
        [Display(Name = "Дни на исполнение")]
        public short count_day_execution { get; set; }

        [Required]
        [Display(Name = "Дни на возврат")]
        public short count_day_return { get; set; }

        [Required]
        [Display(Name = "Сумма")]
        public decimal tariff_ { get; set; }

        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Display(Name = "Дата добавления")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Display(Name = "Добавил")]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [Display(Name = "Сбор")]
        public decimal? charge_ { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }
        public virtual spr_services_sub_customer spr_services_sub_customer { get; set; }
    }
}
