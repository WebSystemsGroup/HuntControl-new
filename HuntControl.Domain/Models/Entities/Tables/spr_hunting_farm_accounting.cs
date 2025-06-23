namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_accounting")]
    public partial class spr_hunting_farm_accounting
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "���-��")]
        public int count_animal { get; set; }

        [Required]
        [Display(Name = "������ �����")]
        public Guid spr_animal_method_account_id { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [Display(Name = "����������")]
        public Guid spr_hunting_farm_id { get; set; }

        [Required]
        [Display(Name = "��������")]
        public Guid spr_animal_id { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [Required]
        [Display(Name = "��� ���������")]
        public int animal_sex { get; set; }

        [Required]
        [Display(Name = "������� ���������")]
        public int animal_age { get; set; }

        [Required]
        [Display(Name = "���")]
        public int? year_ { get; set; }

        public virtual spr_animal spr_animal { get; set; }
        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
        public virtual spr_animal_method_account spr_animal_method_account { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_limit> spr_hunting_farm_limit { get; set; }
    }
}
