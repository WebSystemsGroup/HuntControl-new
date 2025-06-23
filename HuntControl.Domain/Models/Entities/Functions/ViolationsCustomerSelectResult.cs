namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ViolationsCustomerSelectResult
    {
        public Guid out_data_customer_id { get; set; }        
        public string out_customer_name { get; set; }
        public string out_actual_address { get; set; }
        public int out_count { get; set; }
    }
}
