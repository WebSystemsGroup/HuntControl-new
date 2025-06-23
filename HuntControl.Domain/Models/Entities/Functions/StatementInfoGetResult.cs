namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StatementInfoGetResult
    {
        public string out_type_recipient_name { get; set; }
        public string out_employees_fio { get; set; }
        public string out_customer_tel1 { get; set; }
        public string out_customer_tel2 { get; set; }
        public string out_customer_name { get; set; }
        public string out_service_name { get; set; }
        public int? out_count_day { get; set; }
        public DateTime? out_date_finish_total { get; set; }
        public string out_customer_email { get; set; }
        public decimal? out_tariff_state { get; set; }
        public string out_name_way { get; set; }
        public string out_alert_name { get; set; }
        public DateTime? out_date_enter { get; set; }
        public string out_service_provider_name { get; set; }
        public string out_customer_address { get; set; }
        public string out_type_week_name { get; set; }
        public string out_document_serial { get; set; }
        public string out_document_number { get; set; }
        public decimal? out_charge_ { get; set; }
        public DateTime? out_document_birth_date { get; set; }
        public DateTime? out_document_issue_date { get; set; }
        public string out_document_issue_body { get; set; }
        public string out_employees_job_pos_name { get; set; }
        public string out_document_birth_place { get; set; }
        public string out_customer_address_actual { get; set; }

    }
}
