namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerViolationsSelectResult
    {
        public Guid out_data_customer_violations_id { get; set; }
        public string out_hunting_farm_name { get; set; }
        public string out_violations_name { get; set; }
        public string out_number_case { get; set; }
        [Column(TypeName ="date")]
        public DateTime? out_date_in_ogm { get; set; }
        public string out_status_name { get; set; }
        public string out_status_commentt { get; set; }
        public int? out_count_file { get; set; }
    }
}
