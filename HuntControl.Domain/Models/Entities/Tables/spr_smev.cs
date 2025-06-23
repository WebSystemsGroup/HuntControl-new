namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_smev")]
    public partial class spr_smev
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Наименование")]
        public string smev_name { get; set; }

        [StringLength(150)]
        [Display(Name = "Орган власти")]
        public string smev_provider { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Адрес сервиса")]
        public string provider_url { get; set; }

        [StringLength(30)]
        [Display(Name = "Код поставщика")]
        public string provider_code { get; set; }

        [StringLength(100)]
        [Display(Name = "Наименование поставщика")]
        public string provider_name { get; set; }

        [Display(Name = "Описание сервиса")]
        public string smev_description { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? set_date { get; set; }

        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(30)]
        [Display(Name = "Мнемоника")]
        public string smev_mnemo { get; set; }

        [Display(Name = "СМЭВ 3")]
        public bool is_smev3 { get; set; }

        [StringLength(8000)]
        public string employees_fio_modifi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_smev_request> spr_smev_request { get; set; }
    }
}
