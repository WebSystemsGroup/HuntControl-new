namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_tariff")]
    public partial class spr_services_sub_tariff
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_sub_customer_id { get; set; }

        [Display(Name = "��� ������� ����")]
        public short spr_services_sub_week_id { get; set; }

        [Display(Name = "��� ������")]
        public short spr_services_sub_tariff_type_id { get; set; }

        [Required]
        [Display(Name = "��� �� ���������")]
        public short count_day_processing { get; set; }

        [Required]
        [Display(Name = "��� �� ����������")]
        public short count_day_execution { get; set; }

        [Required]
        [Display(Name = "��� �� �������")]
        public short count_day_return { get; set; }

        [Required]
        [Display(Name = "�����")]
        public decimal tariff_ { get; set; }

        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [Display(Name = "���� ����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Display(Name = "�������")]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [Display(Name = "����")]
        public decimal? charge_ { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }
        public virtual spr_services_sub_customer spr_services_sub_customer { get; set; }
    }
}
