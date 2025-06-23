namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_customer")]
    public partial class spr_services_sub_customer
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid spr_services_sub_id { get; set; }

        [Display(Name = "Получатель")]
        public int spr_services_sub_type_recipient_id { get; set; }

        [StringLength(5000)]
        [Display(Name = "Перечень представителей")]
        public string representative_list { get; set; }

        [StringLength(3000)]
        [Display(Name = "Документ подтверждающий право представителя")]
        public string representative_document { get; set; }

        [StringLength(5000)]
        [Display(Name = "Требование к документу")]
        public string representative_specification { get; set; }

        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Display(Name = "Подача заявления представителем")]
        public bool? representative { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }

        public virtual spr_services_sub_type_recipient spr_services_sub_type_recipient { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_document_customer> spr_services_sub_document_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_tariff> spr_services_sub_tariff { get; set; }
    }
}
