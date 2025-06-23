namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class CaseServicesDocumentFileSelectResult
    {
        public Guid? out_id { get; set; }

        [Display(Name = "����")]
        public DateTime out_date_enter { get; set; }

        [Display(Name = "������������")]
        public string out_file_name { get; set; }

        [Display(Name = "����������")]
        public string out_file_ext { get; set; }

        [Display(Name = "������")]
        public int? out_file_size { get; set; }

        [Display(Name = "���������")]
        public string out_employees_fio { get; set; }

        [Display(Name = "���������")]
        public Guid? out_spr_employees_id { get; set; }

        [Display(Name = "����� ����")]
        public string out_data_services_info_id { get; set; }

        [Display(Name = "��� ���������")]
        public string out_customer_fio { get; set; }
    }
}
