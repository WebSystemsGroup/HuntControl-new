namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseArchiveServices
    {
        public string out_data_services_info_id { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_enter { get; set; }
        public string out_customer_name { get; set; }
        public string out_service_name { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_finish_total { get; set; }
        public int? out_count_day_total { get; set; }
        public int? out_count_day { get; set; }
        public string out_employees_fio { get; set; }
        public string out_employees_fio_execution { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]

        public DateTime? out_date_finish_fact { get; set; }
        public bool out_call { get; set; }
        public bool out_message { get; set; }
        public bool out_commentt { get; set; }
        public string out_status_name { get; set; }
        public string out_name_way { get; set; }
        public string out_type_week_name { get; set; }
        public string out_stage_name { get; set; }

        string out_customer_address { get; set; }
        string out_customer_tel { get; set; }

        Guid out_spr_services_sub_way_get_id { get; set; }
        bool out_file { get; set; }
        bool out_overdue_stages { get; set; }
        short out_smev { get; set; }

    }
}
