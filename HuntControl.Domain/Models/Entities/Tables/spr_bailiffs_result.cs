using System.Data.Entity.ModelConfiguration.Conventions;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_bailiffs_result")]
    public partial class spr_bailiffs_result
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Наименование")]
        public string result_name { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_violations> data_customer_violations { get; set; }
    }
}
