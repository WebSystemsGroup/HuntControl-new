namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic")]
    public partial class data_customer_hunting_lic
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Заявитель")]
        public Guid data_customer_id { get; set; }

        [Required]
        [StringLength(10)]
        [Display(Name = "Серия")]
        public string serial_license { get; set; }

        [Required]
        [StringLength(20)]
        [Display(Name = "Номер")]
        public string number_license { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата выдачи")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? issue_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Уполномоченное лицо")]
        public string employees_authorized { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [Required]
        [Display(Name = "Дата фактическая")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [Display(Name = "Добавил")]
        public Guid spr_employees_id { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [Required]
        [Display(Name = "Кем выдан")]
        public string issue_body { get; set; }

        [Required]
        [Display(Name = "Дата внесения в охотхозяйственный реестр")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? reestr_date { get; set; }

        [Display(Name = "Дата аннулирования")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? cancelled_date { get; set; }

        [Display(Name = "Основание аннулирования")]
        public string cancelled_ground { get; set; }

        public virtual data_customer data_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm> data_customer_hunting_lic_perm { get; set; }
    }
}
