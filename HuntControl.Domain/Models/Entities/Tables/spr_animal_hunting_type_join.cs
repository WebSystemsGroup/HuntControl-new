namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_animal_hunting_type_join")]
    public partial class spr_animal_hunting_type_join
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "��� �����")]
        public Guid spr_hunting_type_id { get; set; }

        [Display(Name = "��������")]
        public Guid spr_animal_id { get; set; }

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

        public virtual spr_hunting_type spr_hunting_type { get; set; }
        public virtual spr_animal spr_animal { get; set; }
    }
}
