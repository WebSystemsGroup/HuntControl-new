namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_taxation")]
    public partial class spr_taxation
    {

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        [StringLength(30)]
        public string inn { get; set; }

        [StringLength(30)]
        public string kbk { get; set; }

        [StringLength(30)]
        public string oktmo { get; set; }

        [StringLength(255)]
        public string tax_name { get; set; }

        [StringLength(30)]
        public string kpp { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_payment> data_customer_hunting_lic_perm_payment { get; set; }
    }
}
