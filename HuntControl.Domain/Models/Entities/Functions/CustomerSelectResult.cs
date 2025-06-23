namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerSelectResult
    {
        public data_customer_hunting_lic customer { get; set; }
        public Guid? out_id { get; set; }
        public string out_customer_name { get; set; }
        public string out_phone_number1 { get; set; }
        public int? out_violations_count { get; set; }
        public string out_actual_address { get; set; }
        public int? out_hunting_license_status { get; set; }
        public string out_email { get; set; }
        public bool? out_license { get; set; }

    }
}
