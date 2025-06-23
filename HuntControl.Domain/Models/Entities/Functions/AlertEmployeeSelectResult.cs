namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class AlertEmployeeSelectResult
    {
        public string out_data_services_info_id { get; set; }
        public string out_commentt { get; set; }
        public DateTime? out_date { get; set; }
        public string out_employee_fio { get; set; }
        public Guid? out_id { get; set; }
        public string out_customer_name { get; set; }
        public string out_customer_tel1 { get; set; }
        public string out_customer_tel2 { get; set; }
        public string out_customer_email { get; set; }
        public int out_spr_employee_alert_id { get; set; }
        public string out_request_name { get; set; }
        public string out_service_name { get; set; }
        public Guid? out_data_customer_id { get; set; }
        public string out_alert_name { get; set; }
    }
}
