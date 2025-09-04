namespace HuntControl.Domain.Concrete
{
    using System;

    public partial class FormUngulateInfoResult
    {
        public string out_customer_name { get; set; }
        public string out_hunting_lic_serial { get; set; }
        public string out_hunting_lic_number { get; set; }
        public DateTime? out_hunting_lic_issue_date { get; set; }
        public string out_hunting_type_name { get; set; }
        public DateTime? out_date_start { get; set; }
        public DateTime? out_date_stop { get; set; }
        public string out_hunting_farm_name { get; set; }
        public DateTime? out_date_given { get; set; }
        public string out_fio_given { get; set; }
        public string out_animal_sex { get; set; }
        public string out_animal_age { get; set; }
        public string out_animal_name { get; set; }
        public string out_organization_name { get; set; }
        public string out_region_name { get; set; }
        public string out_transport_name { get; set; }
        public DateTime? out_date_start_1 { get; set; }
        public DateTime? out_date_stop_1 { get; set; }
        public DateTime? out_date_start_2 { get; set; }
        public DateTime? out_date_stop_2 { get; set; }
    }
}
