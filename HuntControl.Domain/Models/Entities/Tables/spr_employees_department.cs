namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_employees_department")]
    public partial class spr_employees_department
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "������������")]
        public string department_name { get; set; }

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

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_employees> spr_employees { get; set; }
    }
}
