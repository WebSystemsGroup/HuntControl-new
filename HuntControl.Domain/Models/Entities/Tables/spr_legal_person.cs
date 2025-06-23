using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_legal_person")]
    public partial class spr_legal_person
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(100)]
        [Display(Name = "Наименование")]
        public string legal_name { get; set; }

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
        [StringLength(300)]
        [Display(Name = "Юридический адрес")]
        public string legal_address { get; set; }

        [Required]
        [StringLength(300)]
        [Display(Name = "Фактический адрес")]
        public string actual_address { get; set; }

        [StringLength(15)]
        [Display(Name = "ИНН")]
        public string inn { get; set; }

        [StringLength(15)]
        [Display(Name = "КПП")]
        public string kpp { get; set; }

        [StringLength(15)]
        [Display(Name = "ОКВЭД")]
        public string okved { get; set; }

        [StringLength(20)]
        [Display(Name = "ОГРН")]
        public string ogrn { get; set; }

        [StringLength(70)]
        [Display(Name = "Руководитель")]
        public string head_fio { get; set; }

        [StringLength(20)]
        [Display(Name = "Основной тел.")]
        public string phone_number1 { get; set; }

        [StringLength(20)]
        [Display(Name = "Доп. тел.")]
        public string phone_number2 { get; set; }

        [StringLength(30)]
        [Display(Name = "E-mail")]
        public string e_mail { get; set; }

        [Display(Name = "Банк")]
        public Guid? spr_bank_id { get; set; }

        [StringLength(30)]
        [Display(Name = "Р/с")]
        public string bank_account { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата заключения договора")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? date_contract { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [Display(Name = "Дата внесения в ЕГРЮЛ")]
        public DateTime? egrul_date { get; set; }

        [Display(Name = "Тип лица")]
        public int? spr_services_sub_type_recipient_id { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<spr_hunting_farm> spr_hunting_farm { get; set; }

        public virtual spr_bank spr_bank { get; set; }
        public virtual spr_services_sub_type_recipient spr_services_sub_type_recipient { get; set; }
    }
}
