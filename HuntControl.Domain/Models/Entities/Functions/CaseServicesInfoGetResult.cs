namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesInfoGetResult
    {
        [Display(Name = "������")]
        public Guid? out_data_services_id { get; set; }

        [Display(Name = "���")]
        public string out_type_recipient_name { get; set; }

        [Display(Name = "������")]
        public string out_employees_fio { get; set; }

        [Display(Name = "�����������")]
        public string out_employees_fio_execution { get; set; }

        [Display(Name = "�������")]
        public string out_customer_tel1 { get; set; }

        [Display(Name = "�������")]
        public string out_customer_tel2 { get; set; }

        [Display(Name = "���������")]
        public string out_customer_name { get; set; }

        [Display(Name = "������")]
        public string out_service_name { get; set; }

        [Display(Name = "���������� ����")]
        public int? out_count_day { get; set; }

        [Display(Name = "����� ����")]
        public int? out_count_day_total { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_finish_total { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_finish_fact { get; set; }

        [Display(Name = "E-mail")]
        public string out_customer_email { get; set; }

        [Display(Name = "������")]
        public string out_status_name { get; set; }

        [Display(Name = "�����")]
        public decimal? out_tariff_state { get; set; }

        public string out_name_way { get; set; }

        public string out_alert_name { get; set; }

        [Display(Name = "����")]
        public DateTime? out_date_enter { get; set; }

        [Display(Name = "���������")]
        public string out_service_provider_name { get; set; }

        [Display(Name = "�����")]
        public string out_customer_address { get; set; }

        public string out_type_week_name { get; set; }

        public string out_stage_name { get; set; }
        [Display(Name = "�����")]
        public string out_doc_serial { get; set; }
        [Display(Name = "�����")]
        public string out_doc_number { get; set; }
        public Guid? out_data_customer_id { get; set; }
        public Guid? out_data_services_customer_id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_visit_time { get; set; }
    }
}