namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer")]
    public partial class data_customer
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(100)]
        public string customer_name { get; set; }

        [StringLength(10)]
        [Display(Name = "�����")]
        public string doc_serial { get; set; }

        [StringLength(20)]
        [Display(Name = "�����")]
        public string doc_number { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "���� ��������")]
        public DateTime? doc_birth_date { get; set; }

        [StringLength(255)]
        [Display(Name = "����� ��������")]
        public string doc_birth_place { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "���� ������")]
        public DateTime? doc_issue_date { get; set; }

        [StringLength(255)]
        [Display(Name = "��� �����")]
        public string doc_issue_body { get; set; }

        [StringLength(20)]
        [Display(Name = "��� �������������")]
        public string doc_code { get; set; }

        [StringLength(20)]
        [Display(Name = "�������")]
        public string phone_number1 { get; set; }

        [StringLength(20)]
        [Display(Name = "�������")]
        public string phone_number2 { get; set; }

        [StringLength(3)]
        [Display(Name = "���")]
        public string customer_sex { get; set; }

        [StringLength(20)]
        [Display(Name = "�����")]
        public string customer_snils { get; set; }

        [StringLength(30)]
        [Display(Name = "E-mail")]
        public string e_mail { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "���� �����������")]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "�����")]
        public string legal_address { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "����� ����������")]
        public string actual_address { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [Display(Name = "������������ �����������")]
        public string social_organization_info { get; set; }

        [Display(Name = "���������")]
        public string social_job_position { get; set; }

        [Display(Name = "���������")]
        public bool? social_pensioner { get; set; }

        [Display(Name = "����������������")]
        public bool? social_incapable { get; set; }

        [Display(Name = "������������ �����������")]
        public string file_name { get; set; }

        [Display(Name = "����������")]
        public string file_ext { get; set; }

        [Display(Name = "���")]
        public string customer_inn { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic> data_customer_hunting_lic { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_violations> data_customer_violations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_payment> data_customer_hunting_lic_perm_payment { get; set; }
    }
}
