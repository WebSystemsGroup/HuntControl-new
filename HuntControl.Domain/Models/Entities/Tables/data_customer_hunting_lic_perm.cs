namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic_perm")]
    public partial class data_customer_hunting_lic_perm
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "���������")]
        public Guid data_customer_hunting_lic_id { get; set; }

        [Display(Name = "���� �����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Required]
        [Display(Name = "��� �����")]
        public Guid spr_hunting_type_id { get; set; }

        [Required]
        [Display(Name = "������ �������")]
        public Guid spr_method_remove_id { get; set; }

        [Required]
        [Display(Name = "����� ������")]
        public string serial_form { get; set; }

        [Required]
        [Display(Name = "����� ������")]
        public string number_form { get; set; }

        [Required]
        [Display(Name = "���������� �����")]
        public string fio_given { get; set; }

        [Required]
        [Display(Name = "���� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? date_given { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [Required]
        [Display(Name = "����������")]
        public Guid? spr_hunting_farm_id { get; set; }

        [Display(Name = "�����")]
        public int? spr_season_id { get; set; }

        //[Required]
        //[Display(Name = "������ �����")]
        //public Guid spr_animal_group_type_id { get; set; }

        [Display(Name = "����������")]
        public decimal? tariff_ { get; set; }

        [Display(Name = "������������� ����")]
        public decimal? charge_ { get; set; }

        [Display(Name = "��������� ��������� ���������")]
        public Guid spr_employees_id { get; set; }

        [Display(Name = "��������� ����������")]
        [StringLength(30)]
        public string job_pos_name { get; set; }

        [Display(Name = "�����")]
        public Guid? spr_hunting_farm_season_id { get; set; }

        [Display(Name = "���� ������ ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime? date_start { get; set; }

        [Display(Name = "���� ��������� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime? date_stop { get; set; }

        public virtual data_customer_hunting_lic data_customer_hunting_lic { get; set; }

        public virtual spr_hunting_type spr_hunting_type { get; set; }

        public virtual spr_hunting_farm spr_hunting_farm { get; set; }

        public virtual spr_method_remove spr_method_remove { get; set; }

       // public virtual spr_animal_group_type spr_animal_group_type { get; set; }
        public virtual spr_season spr_season { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_back> data_customer_hunting_lic_perm_back { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_animal> data_customer_hunting_lic_perm_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_hunting> data_customer_hunting_lic_perm_hunting { get; set; }
    }
}
