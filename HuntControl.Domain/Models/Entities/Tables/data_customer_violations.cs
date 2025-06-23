namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_violations")]
    public partial class data_customer_violations
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_customer_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "���� ����������")]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ����")]
        public string pr_number_case { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ����������� � ���")]
        public DateTime? pr_date_in_ogm { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ���������")]
        public string pr_number_protocol { get; set; }

        [Display(Name = "���� ���������� ���������")]
        [Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy hh':'mm}", ApplyFormatInEditMode = true)]
        public DateTime? pr_date_create { get; set; }

        [Display(Name = "����� ���������� ���������")]
        [Column(TypeName = "time")]
        [DisplayFormat(DataFormatString = "{0:hh':'mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? pr_time_create { get; set; }

        [Display(Name = "����������")]
        public Guid? pr_spr_hunting_farm_id { get; set; }

        [StringLength(255)]
        [Display(Name = "�������� � ��������� ������� ���������")]
        public string pr_no_legal_products { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������������(����������� ������)")]
        public DateTime? pr_date_receiving { get; set; }

        [StringLength(10)]
        [Display(Name = "�����")]
        public string pr_gun_permission_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ��������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? pr_gun_permission_date_stop { get; set; }

        [StringLength(70)]
        [Display(Name = "��� ����������� ���������")]
        public string pr_name_create { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ����������� �����������")]
        public DateTime? def_date_sent { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ��������� �����������")]
        public DateTime? def_date_definition { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ��������� ����������� � ��������")]
        public DateTime? def_date_handing { get; set; }
                

        [Display(Name = "��� �����������")]
        public int? def_spr_definition_type_id { get; set; }
        
        [Display(Name = "���� � ����� ������������")]
        public DateTime? pl_date { get; set; }

        [StringLength(255)]
        [Display(Name = "����� ������������")]
        public string pl_place { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �����������")]
        public DateTime? tr_date_sent { get; set; }

        [StringLength(255)]
        [Display(Name = "������������ ������ ������")]
        public string tr_name_organization { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �����������")]
        public DateTime? dis_date { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������������")]
        public DateTime? dis_date_receiving { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �������� �����")]
        public DateTime? dis_date_receiving_copy { get; set; }

        [StringLength(10)]
        [Display(Name = "����� �������������")]
        public string dis_number { get; set; }

        [StringLength(5000)]
        [Display(Name = "��������� �����������")]
        public string dis_basis_discontinued { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �������������")]
        public DateTime? res_date { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ��������� ����������� � ��������")]
        public DateTime? res_date_handing { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ��������� �����������")]
        public DateTime? res_date_receiving { get; set; }

        [Display(Name = "����� ������")]
        public decimal? res_amount_fine { get; set; }

        [Display(Name = "����� ������������ �����")]
        public decimal? res_amount_harm { get; set; }

        [Display(Name = "��������� ����������")]
        public string res_head_managing { get; set; }

        [Display(Name = "�������� ��� ���")]
        public bool? res_payment { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ������������� ")]
        public string res_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ���������� � �������� ����")]
        public DateTime? res_date_entry { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �������� ����� �������������")]
        public DateTime? res_date_receiving_copy { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �����������")]
        public DateTime? bai_date_sent { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ������")]
        public string bai_number { get; set; }

        [StringLength(255)]
        [Display(Name = "������������")]
        public string bai_name_bailiffs { get; set; }

        [StringLength(255)]
        [Display(Name = "�����")]
        public string bai_address { get; set; }

        [StringLength(70)]
        [Display(Name = "���������")]
        public string bai_head { get; set; }

        [StringLength(70)]
        [Display(Name = "��������� ���")]
        public string bai_head_protection_nature { get; set; }

        [StringLength(1500)]
        [Display(Name = "����������")]
        public string bai_attached { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ���������")]
        public string pr20_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ���������")]
        public DateTime? pr20_date { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������������ ����������")]
        public DateTime? pr20_date_receipt { get; set; }

        [Display(Name = "����")]
        public Guid? bai_spr_bailiffs_id { get; set; }

        [Display(Name = "����� ������")]
        public Guid? tr_spr_organization_id { get; set; }

        [StringLength(70)]
        [Display(Name = "��������� ���")]
        public string tr_head_protection_nature { get; set; }

        [StringLength(70)]
        [Display(Name = "��������� ���")]
        public string pr20_head_protection_nature { get; set; }

        [StringLength(5000)]
        [Display(Name = "�����")]
        public string tr_text { get; set; }

        [StringLength(10)]
        [Display(Name = "�����")]
        public string tr_number { get; set; }

        [Display(Name = "����� �����������")]
        public string def_nomer { get; set; }              

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "C������������, ������, �����������")]
        public string pr_resistance { get; set; }

        [StringLength(1500)]
        [Display(Name = "���������� ���. ����")]
        public string pr_explanation { get; set; }

        [StringLength(5000)]
        [Display(Name = "������� ��������������")]
        public string pr_description { get; set; }

        [StringLength(20)]
        [Display(Name = "�������� ���������")]
        public string pr_marital_status { get; set; }

        [StringLength(100)]
        [Display(Name = "�� ���������")]
        public string pr_dependent { get; set; }

        [StringLength(100)]
        [Display(Name = "����� ���������� � ����� ")]
        public string pr_motor_transport { get; set; }

        [StringLength(500)]
        [Display(Name = "�������� ������, �����, �����")]
        public string pr_article { get; set; }

        [StringLength(30)]
        [Display(Name = "������ ������")]
        public string pr_gun_caliber { get; set; }

        [StringLength(1500)]
        [Display(Name = "� ��������� �����������")]
        public string pr_attached { get; set; }

        [Display(Name = "����� ������")]
        public string pr_place_work { get; set; }

        [StringLength(255)]
        [Display(Name = "��������� 1")]
        public string pr_witnesses1 { get; set; }

        [StringLength(255)]
        [Display(Name = "��������� 2")]
        public string pr_witnesses2 { get; set; }

        [StringLength(255)]
        [Display(Name = "�����������")]
        public string pr_citizenship { get; set; }

        [StringLength(255)]
        [Display(Name = "�������� �������������� ��������")]
        public string pr_document { get; set; }

        [StringLength(10)]
        [Display(Name = "�����")]
        public string pr_hunting_lic_serial { get; set; }

        [StringLength(20)]
        [Display(Name = "�����")]
        public string pr_hunting_lic_number { get; set; }

        [StringLength(255)]
        [Display(Name = "��� �����")]
        public string pr_hunting_lic_issue_body { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������ ����. ������")]
        public DateTime? pr_hunting_lic_issue_date { get; set; }

        [StringLength(100)]
        [Display(Name = "������������ ����������")]
        public string pr_hunting_farm_name { get; set; }

        [Display(Name = "C����� ���������")]
        public Guid? pr_spr_violations_part_id { get; set; }

        [Display(Name = "���������")]
        public string pr_job_pos_name { get; set; }

        [StringLength(100)]
        [Display(Name = "��� ����������")]
        public string pr_customer_name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ��������")]
        public DateTime? pr_birth_date { get; set; }

        [StringLength(255)]
        [Display(Name = "����� ��������")]
        public string pr_birth_place { get; set; }

        [StringLength(255)]
        [Display(Name = "����� ����������")]
        public string pr_customer_address { get; set; }

        [StringLength(100)]
        [Display(Name = "����� ��������")]
        public string pr_customer_phone_number { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ���������")]
        public string pr_doc_serial { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ���������")]
        public string pr_doc_number { get; set; }
        
        [Column(TypeName = "date")]
        [Display(Name = "���� ������")]
        public DateTime? pr_doc_issue_date { get; set; }

        [StringLength(255)]
        [Display(Name = "��� �����")]
        public string pr_doc_issue_body { get; set; }

        [StringLength(20)]
        [Display(Name = "����� ������ ����������")]
        public string pr_gun_number { get; set; }

        [StringLength(70)]
        [Display(Name = "������ �������")]
        public string pr_gun { get; set; }

        [StringLength(255)]
        [Display(Name = "��� ������")]
        public string pr_gun_permission_issued { get; set; }

        [StringLength(255)]
        [Display(Name = "����� ����������� ���������")]
        public string pr_place_protocol { get; set; }

        [Required]
        [Display(Name = "���� � ����� ���������� ��������������")]
        public DateTime pr_date_law_violation { get; set; }

        [Display(Name = "���� ����� �����������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy HH':'mm}", ApplyFormatInEditMode = true)]
        public DateTime? pr_date_examination { get; set; }

        [StringLength(20)]
        [Display(Name = "����� ��������� ������")]
        public string pr_number_letter { get; set; }

        [StringLength(255)]
        [Display(Name = "����� �����������")]
        public string pr20_place { get; set; }

        [StringLength(255)]
        [Display(Name = "���������")]
        public string pr20_job_pos_name { get; set; }

        [StringLength(20)]
        [Display(Name = "��� ��� ��")]
        public string pr20_inn { get; set; }

        [StringLength(255)]
        [Display(Name = "����� �����������")]
        public string pr20_customer_address_legal { get; set; }

        [StringLength(255)]
        [Display(Name = "�������� �������������� ��������")]
        public string pr20_document { get; set; }

        [StringLength(1500)]
        [Display(Name = "���������� � ��������� ����")]
        public string pr20_explanation { get; set; }

        [StringLength(1500)]
        [Display(Name = "� ��������� �����������")]
        public string pr20_attached { get; set; }

        [StringLength(100)]
        [Display(Name = "��� ����������� ���������")]
        public string pr20_name_create { get; set; }

        [StringLength(20)]
        [Display(Name = "����� ��������� ������")]
        public string res_number_letter { get; set; }

        [StringLength(500)]
        [Display(Name = "��������� ������������")]
        public string res_details_trust { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �������� ��������� ������")]
        public DateTime? res_date_receiving_letter { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������ ������")]
        public DateTime? res_payment_date { get; set; }


        [Column(TypeName = "date")]
        [Display(Name = "���� �������� ������")]
        public DateTime? pr_date_receiving_letter { get; set; }

        [StringLength(70)]
        [Display(Name = "��������� ����������")]
        public string def_head_managing { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �����������")]
        public DateTime? al20_date { get; set; }

        [StringLength(10)]
        [Display(Name = "����� �����������")]
        public string al20_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �����������")]
        public DateTime? al20_date_invitations { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������������, ����������� ������")]
        public DateTime? al20_date_receiving { get; set; }

        [Display(Name = "������������")]
        public Guid? tr_spr_employees_id { get; set; }

        [Display(Name = "��� ����������� ���������")]
        public Guid? pr_spr_employees_id_create { get; set; }

        [Display(Name = "�������������")]
        public Guid? pr_spr_employees_id { get; set; }

        [Display(Name = "�������������")]
        public Guid? al_spr_employees_id { get; set; }

        [Display(Name = "�������������")]
        public Guid? def_spr_employees_id { get; set; }

        [Display(Name = "�������������")]
        public Guid? res_spr_employees_id { get; set; }

        [Display(Name = "�������������")]
        public Guid? al20_spr_employees_id { get; set; }

        [Display(Name = "������������")]
        public Guid? pr20_spr_employees_id { get; set; }

        [Display(Name = "�������������")]
        public Guid? bai_spr_employees_id { get; set; }

        [Display(Name = "�������������")]
        public Guid? dis_spr_employees_id { get; set; }

        [StringLength(255)]
        [Display(Name = "����� ������������")]
        public string pr_address_consideration { get; set; }

        [Column(TypeName ="date")]
        [Display(Name = "���� �����������")]
        public DateTime? al_date { get; set; }

        [StringLength(10)]
        [Display(Name = "����� �����������")]
        public string al_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� �����������")]
        public DateTime? al_date_invitations { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������������, ����������� ������")]
        public DateTime? al_date_receiving { get; set; }
        
        [Display(Name = "��� �������� ���������")]
        public int? al_who_identified { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ������")]
        public string bai_answer_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������ �� ���������")]
        public DateTime? bai_answer_date { get; set; }
                
        [Display(Name = "���������")]
        public int? bai_spr_bailiffs_result_id { get; set; }

        [StringLength(10)]
        [Display(Name = "����� ������ �� �����������")]
        public string tr_answer_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������ �� �����������")]
        public DateTime? tr_answer_date { get; set; }

        [Display(Name = "���������")]
        public int? tr_spr_organization_result_id { get; set; }

        [StringLength(255)]
        [Display(Name = "������� � ��������� ������")]
        public string res_payment_mark { get; set; }
                
        [Display(Name = "����� ������")]
        public Decimal? tr_payment { get; set; }

        [Display(Name = "������� � ��������� ���������")]
        public int? pr_copy { get; set; }


        public data_customer data_customer { get; set; }        
        public spr_organization spr_organization { get; set; }
        public spr_bailiffs spr_bailiffs { get; set; }
        public spr_violations_part spr_violations_part { get; set; }
        public spr_bailiffs_result spr_bailiffs_result { get; set; }
        public spr_organization_result spr_organization_result { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_violations_file> data_customer_violations_file { get; set; }

    }
}
