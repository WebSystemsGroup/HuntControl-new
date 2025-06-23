namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic_perm_animal")]
    public partial class data_customer_hunting_lic_perm_animal
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "����������")]
        public Guid data_customer_hunting_lic_perm_id { get; set; }

        [Display(Name = "��������")]
        public Guid spr_animal_id { get; set; }

        [Display(Name = "����� �� ����")]
        public int limit_day { get; set; }

        [Display(Name = "����� �� �����")]
        public int limit_season { get; set; }

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

        [Display(Name = "��� ���������")]
        public int animal_sex { get; set; }

        [Display(Name = "������� ���������")]
        public int animal_age { get; set; }

        [Display(Name = "���� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_start { get; set; }

        [Display(Name = "���� ������")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_stop { get; set; }

        [Display(Name = "����� �����")]
        public Guid spr_hunting_farm_season_id { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }


        public virtual data_customer_hunting_lic_perm data_customer_hunting_lic_perm { get; set; }

        public virtual spr_animal spr_animal { get; set; }
    }
}
