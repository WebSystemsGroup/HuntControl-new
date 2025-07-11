namespace HuntControl.Domain.Concrete
{
    using System;

    public partial class FormFurInfoResult
    {
        public string out_customer_name { get; set; }
        public string out_hunting_lic_serial { get; set; }
        public string out_hunting_lic_number { get; set; }
        public DateTime? out_hunting_lic_issue_date { get; set; }
        public string out_hunting_farm_name { get; set; }
        public DateTime? out_date_given { get; set; }
        public string out_fio_given { get; set; }
        public string out_organization_name { get; set; }
        public string out_region_name { get; set; }
    }
}
