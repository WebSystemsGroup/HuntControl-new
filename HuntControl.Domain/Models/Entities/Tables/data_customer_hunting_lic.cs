namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic")]
    public partial class data_customer_hunting_lic
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "���������")]
        public Guid data_customer_id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "�����")]
        public string serial_license { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "�����")]
        public string number_license { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "���� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? issue_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������������� ����")]
        public string employees_authorized { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Required]
        [Display(Name = "���� �����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [Display(Name = "�������")]
        public Guid spr_employees_id { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [Required]
        [Display(Name = "��� �����")]
        public string issue_body { get; set; }

        [Required]
        [Display(Name = "���� �������� � ����������������� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? reestr_date { get; set; }

        [Display(Name = "���� �������������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? cancelled_date { get; set; }

        [Display(Name = "��������� �������������")]
        public string cancelled_ground { get; set; }

        public virtual data_customer data_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm> data_customer_hunting_lic_perm { get; set; }
    }
}
