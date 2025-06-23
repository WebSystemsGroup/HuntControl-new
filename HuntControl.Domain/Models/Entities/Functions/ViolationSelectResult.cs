namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ViolationSelectResult
    {
        public Guid out_data_customer_id { get; set; }        
        public string out_customer_name { get; set; }
        public string out_violations_name { get; set; }
        public string out_number_case { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_in_ogm { get; set; }

        public string out_status_name { get; set; }
        public string out_status_commentt { get; set; }
    }
}
