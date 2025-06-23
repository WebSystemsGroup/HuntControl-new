namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_smev_request")]
    public partial class spr_smev_request
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        public Guid spr_smev_id { get; set; }

        [StringLength(350)]
        [Display(Name = "Наименование")]
        public string request_name { get; set; }

        [Display(Name = "Тип отсчета дней")]
        public short spr_services_sub_week_id { get; set; }

        [Display(Name = "Количество дней на выполнение запроса")]
        public short? count_day_execution { get; set; }

        public short spr_smev_type_request_id { get; set; }

        [Display(Name = "Активность")]
        public bool request_active { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        [Display(Name = "Дата добавления")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(255)]
        [Display(Name = "Путь к сервису")]
        public string path { get; set; }

        [StringLength(8000)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_services_sub_smev_request_join> spr_services_sub_smev_request_join { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_smev_request> data_services_smev_request { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }

        public virtual spr_smev spr_smev { get; set; }

        public virtual spr_smev_type_request spr_smev_type_request { get; set; }
    }
}
