namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CustomerHuntingLicenseSelectResult
    {
        public Guid out_data_customer_hunting_lic { get; set; }
        public string out_serial_number_license { get; set; }
    }
}
