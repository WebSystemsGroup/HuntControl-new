namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_hunting_farm_animal")]
    public partial class spr_hunting_farm_animal
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "����������")]
        public Guid spr_hunting_farm_id { get; set; }

        [Display(Name = "��������")]
        public Guid spr_animal_id { get; set; }

        [Required]
        [Display(Name = "������� ��������")]
        public decimal area_habitat { get; set; }

        [StringLength(255)]
        [Display(Name = "�����������")]
        public string commentt { get; set; }

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

        public virtual spr_hunting_farm spr_hunting_farm { get; set; }
        public virtual spr_animal spr_animal { get; set; }
    }
}
