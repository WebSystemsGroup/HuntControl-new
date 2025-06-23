namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services")]
    public partial class spr_services
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [StringLength(10)]
        [Display(Name = "���������")]
        public string service_mnemo { get; set; }

        [Required]
        [StringLength(1500)]
        [Display(Name = "������������")]
        public string service_name { get; set; }

        [Required]
        [StringLength(1500)]
        [Display(Name = "������� ������������")]
        public string service_name_small { get; set; }

        [StringLength(1000)]
        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [StringLength(1500)]
        [Display(Name = "���������")]
        public string service_regulations { get; set; }

        [StringLength(30)]
        [Display(Name = "ID ����")]
        public string frgu_services_id { get; set; }

        [Required]
        [Display(Name = "��� ������")]
        public Guid spr_services_type_id { get; set; }

        [Display(Name = "���� ����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(1500)]
        [Display(Name = "������������ ����")]
        public string frgu_services_name { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_type spr_services_type { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub> spr_services_sub { get; set; }
    }
}
