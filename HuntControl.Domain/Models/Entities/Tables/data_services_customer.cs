namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_customer")]
    public partial class data_services_customer
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_services_id { get; set; }

        public int? spr_document_identity_id { get; set; }

        [StringLength(10)]
        [Display(Name = "Серия")]
        public string document_serial { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер")]
        public string document_number { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "День рождения")]
        public DateTime? document_birth_date { get; set; }

        [StringLength(255)]
        [Display(Name = "Место рождения")]
        public string document_birth_place { get; set; }

        [Column(TypeName = "date")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "Дата выдачи")]
        public DateTime? document_issue_date { get; set; }

        [StringLength(255)]
        [Display(Name = "Кем выдан")]
        public string document_issue_body { get; set; }

        [StringLength(30)]
        [Display(Name = "Код подразделения")]
        public string document_code { get; set; }

        [StringLength(30)]
        [Display(Name = "ИНН")]
        public string customer_inn { get; set; }

        [StringLength(30)]
        [Display(Name = "Телефон")]
        public string customer_tel1 { get; set; }

        [StringLength(30)]
        [Display(Name = "Телефон")]
        public string customer_tel2 { get; set; }

        [StringLength(70)]
        [Display(Name = "E-mail")]
        public string customer_email { get; set; }

        [StringLength(500)]
        [Display(Name = "Адрес")]
        public string customer_address { get; set; }

        [StringLength(500)]
        [Display(Name = "Адрес проживания")]
        public string customer_address_actual { get; set; }

        [StringLength(30)]
        public string customer_address_okato { get; set; }

        [StringLength(30)]
        public string customer_oktmo { get; set; }

        [StringLength(3)]
        public string customer_code_region { get; set; }

        [StringLength(20)]
        public string customer_kpp_legal { get; set; }

        [StringLength(20)]
        public string customer_ogrn_legal { get; set; }

        [Display(Name = "Тип")]
        public int spr_services_sub_tr_id { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        [StringLength(6)]
        [Display(Name = "Пол")]
        public string customer_sex { get; set; }

        [StringLength(20)]
        [Display(Name = "СНИЛС")]
        public string customer_snils { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? set_date { get; set; }

        [StringLength(70)]
        [Display(Name = "Сотрудник")]
        public string employees_fio { get; set; }

        [StringLength(225)]
        public string customer_name_legal { get; set; }

        [StringLength(30)]
        public string customer_inn_legal { get; set; }

        [StringLength(255)]
        [Display(Name = "ФИО")]
        public string customer_fio { get; set; }

        public int? spr_alert_id { get; set; }

        [StringLength(255)]
        [Display(Name = "Директор")]
        public string customer_name_director { get; set; }

        [StringLength(255)]
        [Display(Name = "Должность")]
        public string customer_director_job { get; set; }

        [Display(Name = "Сотрудник")]
        public Guid? spr_employees_id { get; set; }

        [Display(Name = "Тип заявителя")]
        public short? customer_type { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        public virtual data_services data_services { get; set; }

        public virtual spr_employees spr_employees { get; set; }

        public virtual spr_services_sub_type_recipient spr_services_sub_type_recipient { get; set; }
    }
}
