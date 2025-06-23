namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_violations_part")]
    public partial class spr_violations_part
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Cтатья, связь с spr_violations_id")]
        public Guid spr_violations_id { get; set; }

        [Display(Name = "Текст ")]
        public string part_text { get; set; }

        [Display(Name = "Удалена запись или нет")]
        public bool is_remove { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата и время добавления записи")]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Кто добавил запись")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Кто редактировал запись")]
        public string employees_fio_modifi { get; set; }

        [StringLength(70)]
        [Display(Name = "Кто удалил запись")]
        public string employees_fio_remove { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата удаления записи")]
        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарий при удалении записи")]
        public string commentt_remove { get; set; }

        [Display(Name = "Часть")]
        public string part_ { get; set; }

        public spr_violations spr_violations { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_violations> data_customer_violations { get; set; }
    }
}
