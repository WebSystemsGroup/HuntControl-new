namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_season")]
    public partial class spr_season
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(30)]
        [Display(Name ="Наименование")]
        public string season_name { get; set; }

        [Display(Name ="Госпошлина")]
        public decimal? tariff_ { get; set; }

        [Display(Name ="Сбор")]
        public decimal? charge_ { get; set; }

        [StringLength(70)]
        public string employees_fio_modify { get; set; }

        public DateTime? date_modify { get; set; }

        [StringLength(255)]
        public string commentt_modify { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_season_animal> spr_season_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm_season> spr_hunting_farm_season { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm> data_customer_hunting_lic_perm { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_season_open> spr_season_open { get; set; }
    }
}
