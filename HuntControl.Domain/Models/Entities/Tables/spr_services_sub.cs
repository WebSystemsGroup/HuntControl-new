namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub")]
    public partial class spr_services_sub
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_id { get; set; }

        [StringLength(10)]
        [Display(Name = "���������")]
        public string service_sub_mnemo { get; set; }

        [Required]
        [StringLength(1500)]
        [Display(Name = "������������")]
        public string service_sub_name { get; set; }

        [Required]
        [StringLength(1500)]
        [Display(Name = "������� ������������")]
        public string service_sub_name_small { get; set; }

        [StringLength(1000)]
        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [StringLength(30)]
        [Display(Name = "������������� �� ����")]
        public string frgu_target_id { get; set; }

        [Display(Name = "�������� ���������")]
        public string service_sub_description { get; set; }

        [StringLength(30)]
        [Display(Name = "id ����� �� ����")]
        public string epgu_id_form { get; set; }

        [StringLength(1500)]
        [Display(Name = "��������� ���")]
        public string legal_act { get; set; }

        [Display(Name = "���� ����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(1500)]
        [Display(Name = "�������� �� ����")]
        public string frgu_target_name { get; set; }

        [Display(Name = "�������� � �������")]
        public bool? report_select { get; set; }

        [Display(Name = "������� ������ � ��� ����")]
        public bool? ias_mkgu { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "������� �����")]
        public bool? is_payment { get; set; }

        [Display(Name = "��������� ���, ��������� ��� �������� �����(���. �������)")]
        public string payment_legal_act { get; set; }

        [Display(Name = "��� ��� �������� �����")]
        public string payment_kbk { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [StringLength(30)]
        [Display(Name = "ID ��������� �� ����")]
        public string frgu_services_sub_id { get; set; }

        

        public virtual spr_services spr_services { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_customer> spr_services_sub_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_document> spr_services_sub_document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_failure_doc> spr_services_sub_failure_doc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_failure> spr_services_sub_failure { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_file_folder> spr_services_sub_file_folder { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_result_doc> spr_services_sub_result_doc { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_smev_request_join> spr_services_sub_smev_request_join { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_stop> spr_services_sub_stop { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_type_quality_join> spr_services_sub_type_quality_join { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_way_get_join> spr_services_sub_way_get_join { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_way_get_result_join> spr_services_sub_way_get_result_join { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_active> spr_services_sub_active { get; set; }
    }
}
