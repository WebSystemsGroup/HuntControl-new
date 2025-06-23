namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesDocumentSelectResult
    {
        public Guid? out_id { get; set; }

        [Display(Name = "������������")]
        public string out_document_name { get; set; }

        [Display(Name = "���")]
        public int? out_document_type { get; set; }

        [Display(Name = "����������")]
        public int? out_document_count { get; set; }

        [Display(Name = "����������")]
        public int? out_document_needs { get; set; }

        [Display(Name = "���������� ������")]
        public int? out_file_count { get; set; }

        [Display(Name = "���")]
        public short? out_type { get; set; }

        [Display(Name = "����� ����")]
        public string out_data_services_info_id { get; set; }

        [Display(Name = "��� ���������")]
        public string out_customer_fio { get; set; }
    }
}
