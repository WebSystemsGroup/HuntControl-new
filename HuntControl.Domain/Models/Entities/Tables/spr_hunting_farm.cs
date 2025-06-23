using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using System.Linq;

    [Table("public.spr_hunting_farm")]
    public partial class spr_hunting_farm
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "������������")]
        public string hunting_farm_name { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "�������")]
        public decimal? hunting_farm_area { get; set; }

        [Display(Name = "��� ����������")]
        public Guid spr_hunting_farm_type_id { get; set; }

        [Display(Name = "��")]
        public Guid spr_legal_person_id { get; set; }

        [Display(Name = "�����������")]
        public string commentt { get; set; }
        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }

        [Display(Name = "�������� � �������������� ")]
        public string hunting_address { get; set; }

        [Display(Name = "��������")]
        public string hunting_farm_description { get; set; }


        public int spr_hunting_farm_location_count { get { return spr_hunting_farm_location?.ToList().Count() ?? 0; } }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_location> spr_hunting_farm_location { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_hunting> data_customer_hunting_lic_perm_hunting { get; set; }
        
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm> data_customer_hunting_lic_perm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_animal> spr_hunting_farm_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_season> spr_hunting_farm_season { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_accounting> spr_hunting_farm_accounting { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_employees> spr_employees { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_employees_hunting_farm> spr_employees_hunting_farm { get; set; }
        public virtual spr_hunting_farm_type spr_hunting_farm_type { get; set; }
        public virtual spr_legal_person spr_legal_person { get; set; }
    }
}
