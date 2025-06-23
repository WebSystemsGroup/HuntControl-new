namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_routes_stage")]
    public partial class data_services_routes_stage
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_services_id { get; set; }

        [Display(Name = "Этап")]
        public int spr_routes_stage_id { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Номер дела")]
        public string data_services_info_id { get; set; }

        [Display(Name = "Тип расчета")]
        public short spr_services_sub_week_id { get; set; }

        [Display(Name = "Сотрудник")]
        public Guid spr_employees_id { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Сотрудник")]
        public string employees_fio { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime date_start { get; set; }

        [Column(TypeName = "time")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public TimeSpan time_start { get; set; }

        [Display(Name = "Дни")]
        public short count_day_execution { get; set; }

        [Display(Name = "Дни")]
        public short? count_day_fact { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_finish_reg { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_finish_fact { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? time_finish_fact { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio_fact { get; set; }

        [Display(Name = "Добавил")]
        public Guid spr_employees_id_fact { get; set; }

        public virtual data_services data_services { get; set; }

        public virtual spr_employees spr_employees { get; set; }
        public virtual spr_employees spr_employees_fact { get; set; }

        public virtual spr_routes_stage spr_routes_stage { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }
    }
}
