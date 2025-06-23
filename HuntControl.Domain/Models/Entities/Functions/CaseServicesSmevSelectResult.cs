namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesSmevSelectResult
    {
        public Guid? out_id { get; set; }

        [Display(Name = "Наименование")]
        public string out_request_name { get; set; }

        [Display(Name = "Комментарии")]
        public string out_commentt { get; set; }

        [Display(Name = "Дата запроса")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_request { get; set; }

        [Display(Name = "Время запроса")]
        public TimeSpan? out_time_request { get; set; }

        [Display(Name = "Дата ответа")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_response { get; set; }

        [Display(Name = "Время ответа")]
        public TimeSpan? out_time_response { get; set; }

        [Display(Name = "Сотрудник")]
        public string out_employees_fio { get; set; }

        [Display(Name = "Статус")]
        public string out_status_name { get; set; }

        [Display(Name = "Количество дней")]
        public int? out_count_day_execution { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_response_reg { get; set; }
    }
}