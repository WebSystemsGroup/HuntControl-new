namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesRoutesStageSelectResult
    {
        [Display(Name = "Этап")]
        public string out_stage_name { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_start { get; set; }

        [Display(Name = "Время")]
        [DisplayFormat(DataFormatString = "{0:hh':'mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? out_time_start { get; set; }

        [Display(Name = "Дни")]
        public int? out_count_day_execution { get; set; }

        [Display(Name = "Дни")]
        public int? out_count_day_fact { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_finish_reg { get; set; }

        [Display(Name = "Дата")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_finish_fact { get; set; }

        [Display(Name = "Время")]
        [DisplayFormat(DataFormatString = "{0:hh':'mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? out_time_finish_fact { get; set; }

        [Display(Name = "Сотрудник")]
        public string out_employees_fio { get; set; }

        [Display(Name = "Сотрудник")]
        public string out_employees_fio_fact { get; set; }

        [Display(Name = "Тип расчета")]
        public string out_week_type_name { get; set; }

        [Display(Name = "Комментарии")]
        public string out_commentt { get; set; }

        [Display(Name = "Этап")]
        public Guid? out_data_services_routes_stage_id { get; set; }

        public Guid? out_id { get; set; }




    }
}
