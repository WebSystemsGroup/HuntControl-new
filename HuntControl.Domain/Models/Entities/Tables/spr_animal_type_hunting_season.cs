namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_animal_type_hunting_season")]
    public partial class spr_animal_type_hunting_season
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "��� ���������")]
        public Guid spr_animal_type_id { get; set; }

        [Display(Name = "������������")]
        public string name_season { get; set; }

        [Display(Name = "���� ������")]
        public int day_start { get; set; }

        [Display(Name = "����� ������")]
        public int month_start { get; set; }

        [Display(Name = "���� ���������")]
        public int day_stop { get; set; }

        [Display(Name = "����� ���������")]
        public int month_stop { get; set; }

        [StringLength(255)]
        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [Display(Name = "����")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
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

        public virtual spr_animal_type spr_animal_type { get; set; }
    }
}
