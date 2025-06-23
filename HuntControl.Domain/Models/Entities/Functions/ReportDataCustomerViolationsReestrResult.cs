namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportDataCustomerViolationsReestrResult
    {
        [Display(Name = "����� ����")]
        public string out_pr_number_case { get; set; }

        [Display(Name = "���� ����������� ��������� � ���")]
        public DateTime? out_pr_date_in_ogm { get; set; }

        [Display(Name = "� ���������")]
        public string out_pr_number_protocol { get; set; }

        [Display(Name = "���� ����������� ���������")]
        public DateTime? out_pr_date_create { get; set; }

        [Display(Name = "����� ����������� ���������")]
        public string out_pr_place_protocol { get; set; }

        [Display(Name = "��� ����������")]
        public string out_pr_customer_name { get; set; }

        [Display(Name = "����� ���������� ����������")]
        public string out_pr_customer_address { get; set; }

        [Display(Name = "���������� ������� ����������")]
        public string out_pr_customer_phone_number { get; set; }

        [Display(Name = "���� �������� ����������")]
        public DateTime? out_pr_birth_date { get; set; }

        [Display(Name = "������ ��������� �� ���� ��")]
        public string out_violations_name { get; set; }
        
        [Display(Name = "���� � ����� ����������� �����������")]
        public DateTime? out_def_date_sent { get; set; }

        [Display(Name = "���� ��������� ����������� � �������� �����������")]
        public DateTime? out_def_date_handing { get; set; }

        [Display(Name = "���� �������������")]
        public DateTime? out_res_date { get; set; }

        [Display(Name = "����� �������������")]
        public string out_res_number { get; set; }

        [Display(Name = "����� ������")]
        public Decimal? out_res_amount_fine { get; set; }

        [Display(Name = "���� ����������� �������������")]
        public DateTime? out_res_date_receiving_letter { get; set; }

        [Display(Name = "����� ������������ �����")]
        public string out_res_amount_harm { get; set; }

        [Display(Name = "���� ��������� ����������� � �������� �������������")]
        public DateTime? out_res_date_handing { get; set; }

        [Display(Name = "���� ���������� ������������� � �������� ����")]
        public DateTime? out_res_date_entry { get; set; }

        [Display(Name = "������ ������ ����������")]
        public string out_res_payment { get; set; }

        [Display(Name = "���� ����������� � ����")]
        public DateTime? out_bai_date_sent { get; set; }

        [Display(Name = "���� ����������� � ����� ������")]
        public DateTime? out_tr_date_sent { get; set; }

        [Display(Name = "�������� ������")]
        public string out_violations_part_text { get; set; }

        [Display(Name = "ID")]
        public Guid? out_data_customer_id { get; set; }
    }
}
