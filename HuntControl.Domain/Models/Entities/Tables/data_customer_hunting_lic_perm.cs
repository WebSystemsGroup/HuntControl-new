namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic_perm")]
    public partial class data_customer_hunting_lic_perm
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Охотбилет")]
        public Guid data_customer_hunting_lic_id { get; set; }

        [Display(Name = "Дата фактическая")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [Required]
        [Display(Name = "Вид охоты")]
        public Guid spr_hunting_type_id { get; set; }

        [Required]
        [Display(Name = "Способ изъятия")]
        public Guid spr_method_remove_id { get; set; }

        [Required]
        [Display(Name = "Серия бланка")]
        public string serial_form { get; set; }

        [Required]
        [Display(Name = "Номер бланка")]
        public string number_form { get; set; }

        [Required]
        [Display(Name = "Разрешение выдал")]
        public string fio_given { get; set; }

        [Required]
        [Display(Name = "Дата выдачи")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? date_given { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [Required]
        [Display(Name = "Охотугодье")]
        public Guid? spr_hunting_farm_id { get; set; }

        [Display(Name = "Сезон")]
        public int? spr_season_id { get; set; }

        //[Required]
        //[Display(Name = "Группа видов")]
        //public Guid spr_animal_group_type_id { get; set; }

        [Display(Name = "Госпошлина")]
        public decimal? tariff_ { get; set; }

        [Display(Name = "Установленный сбор")]
        public decimal? charge_ { get; set; }

        [Display(Name = "Сотрудник принявший заявление")]
        public Guid spr_employees_id { get; set; }

        [Display(Name = "Должность сотрудника")]
        [StringLength(30)]
        public string job_pos_name { get; set; }

        [Display(Name = "Сезон")]
        public Guid? spr_hunting_farm_season_id { get; set; }

        [Display(Name = "Дата начала сезона")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime? date_start { get; set; }

        [Display(Name = "Дата окончания сезона")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}")]
        public DateTime? date_stop { get; set; }

        public virtual data_customer_hunting_lic data_customer_hunting_lic { get; set; }

        public virtual spr_hunting_type spr_hunting_type { get; set; }

        public virtual spr_hunting_farm spr_hunting_farm { get; set; }

        public virtual spr_method_remove spr_method_remove { get; set; }

       // public virtual spr_animal_group_type spr_animal_group_type { get; set; }
        public virtual spr_season spr_season { get; set; }



        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_back> data_customer_hunting_lic_perm_back { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_animal> data_customer_hunting_lic_perm_animal { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_hunting_lic_perm_hunting> data_customer_hunting_lic_perm_hunting { get; set; }
    }
}
