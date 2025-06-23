namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingCustomerInfoGetResult
    {
        public string out_customer_name { get; set; }
        public string out_doc_birth_date { get; set; }
        public string out_phone_number1 { get; set; }
        public string out_phone_number2 { get; set; }
        public string out_legal_address { get; set; }
        public string out_customer_snils { get; set; }
        public string out_e_mail { get; set; }
        public string out_hunting_lic_serial { get; set; }
        public string out_hunting_lic_number { get; set; }
        public DateTime? out_hunting_lic_issue_date { get; set; }
        public int? out_violations_count { get; set; }
        public string out_actual_address { get; set; }
        public string out_doc_issue_body { get; set; }
    }
}
