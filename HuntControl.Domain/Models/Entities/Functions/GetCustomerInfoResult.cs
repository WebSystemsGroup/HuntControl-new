namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GetCustomerInfoResult
    {
        public int? out_spr_document_identity_id { get; set; }
        public DateTime? out_customer_doc_birth_date { get; set; }
        public string out_customer_doc_birth_place { get; set; }
        public DateTime? out_customer_doc_issue_date { get; set; }
        public string out_customer_doc_issue_body { get; set; }
        public string out_customer_doc_code { get; set; }
        public string out_customer_inn { get; set; }
        public string out_customer_tel1 { get; set; }
        public string out_customer_tel2 { get; set; }
        public string out_customer_email { get; set; }
        public string out_customer_address { get; set; }
        public string out_customer_address_actual { get; set; }
        public string out_customer_address_okato { get; set; }
        public string out_customer_code_region { get; set; }
        public string out_customer_snils { get; set; }
        public string out_customer_oktmo { get; set; }
        public string out_customer_fio { get; set; }
        public string out_customer_sex { get; set; }

    }
}
