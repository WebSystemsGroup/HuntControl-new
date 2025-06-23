namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportHuntingLicIssuedReestrResult
    {
        [Display(Name = "���")]
        public string out_customer_name { get; set; }

        [Display(Name = "���� ��������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_doc_birth_date { get; set; }

        [Display(Name = "����� ��������")]
        public string out_doc_birth_place { get; set; }

        [Display(Name = "����� �����������")]
        public string out_legal_address { get; set; }

        [Display(Name = "�������")]
        public string out_phone_number { get; set; }

        [Display(Name = "��. �����")]
        public string out_e_mail { get; set; }

        [Display(Name = "���� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_doc_issue_date { get; set; }

        [Display(Name = "����� ����������")]
        public string out_actual_address { get; set; }

        [Display(Name = "�����")]
        public string out_serial_license { get; set; }

        [Display(Name = "�����")]
        public string out_number_license { get; set; }

        [Display(Name = "���� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_issue_date { get; set; }

        [Display(Name = "����� ���������")]
        public string out_doc_serial { get; set; }

        [Display(Name = "����� ���������")]
        public string out_doc_number { get; set; }

        [Display(Name = "��� �����")]
        public string out_doc_issue_body { get; set; }

        [Display(Name = "�����������")]
        public string out_social_organization_info { get; set; }

        [Display(Name = "���������")]
        public string out_social_job_position { get; set; }

        [Display(Name = "���������")]
        public string out_social_pensioner { get; set; }

        [Display(Name = "����������������")]
        public string out_social_incapable { get; set; }

        [Display(Name = "���� �������� � ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_reestr_date { get; set; }

        [Display(Name = "���� �������������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_cancelled_date { get; set; }

        [Display(Name = "��������� �������������")]
        public string out_cancelled_ground { get; set; }

        [Display(Name = "��� ����")]
        public Guid out_data_customer_id { get; set; }

    }
}
