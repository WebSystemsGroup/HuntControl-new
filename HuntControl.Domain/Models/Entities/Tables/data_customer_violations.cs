namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_violations")]
    public partial class data_customer_violations
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_customer_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата добавления")]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Добавил")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "Изменил")]
        public string employees_fio_modifi { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер дела")]
        public string pr_number_case { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата поступления в ОЖМ")]
        public DateTime? pr_date_in_ogm { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер протокола")]
        public string pr_number_protocol { get; set; }

        [Display(Name = "Дата сотавления протокола")]
        [Column(TypeName = "date")]
        //[DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy hh':'mm}", ApplyFormatInEditMode = true)]
        public DateTime? pr_date_create { get; set; }

        [Display(Name = "Время сотавления протокола")]
        [Column(TypeName = "time")]
        [DisplayFormat(DataFormatString = "{0:hh':'mm}", ApplyFormatInEditMode = true)]
        public TimeSpan? pr_time_create { get; set; }

        [Display(Name = "Охотугодье")]
        public Guid? pr_spr_hunting_farm_id { get; set; }

        [StringLength(255)]
        [Display(Name = "Сведения о незаконно добытой продукции")]
        public string pr_no_legal_products { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ознакомления(направления почтой)")]
        public DateTime? pr_date_receiving { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер")]
        public string pr_gun_permission_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Срок действия")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? pr_gun_permission_date_stop { get; set; }

        [StringLength(70)]
        [Display(Name = "ФИО составителя протокола")]
        public string pr_name_create { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата направления определения")]
        public DateTime? def_date_sent { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата вынесения определения")]
        public DateTime? def_date_definition { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата получения уведомления о вручении")]
        public DateTime? def_date_handing { get; set; }
                

        [Display(Name = "Вид определения")]
        public int? def_spr_definition_type_id { get; set; }
        
        [Display(Name = "Дата и время рассмотрения")]
        public DateTime? pl_date { get; set; }

        [StringLength(255)]
        [Display(Name = "Место рассмотрения")]
        public string pl_place { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата направления")]
        public DateTime? tr_date_sent { get; set; }

        [StringLength(255)]
        [Display(Name = "Наименование органа власти")]
        public string tr_name_organization { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата прекращения")]
        public DateTime? dis_date { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ознакомления")]
        public DateTime? dis_date_receiving { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата вручения копии")]
        public DateTime? dis_date_receiving_copy { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер постановления")]
        public string dis_number { get; set; }

        [StringLength(5000)]
        [Display(Name = "Основание прекращения")]
        public string dis_basis_discontinued { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата постановления")]
        public DateTime? res_date { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата получения уведомления о вручении")]
        public DateTime? res_date_handing { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата получения нарушителем")]
        public DateTime? res_date_receiving { get; set; }

        [Display(Name = "Сумма штрафа")]
        public decimal? res_amount_fine { get; set; }

        [Display(Name = "Сумма причиненного вреда")]
        public decimal? res_amount_harm { get; set; }

        [Display(Name = "Начальник управления")]
        public string res_head_managing { get; set; }

        [Display(Name = "Оплачено или нет")]
        public bool? res_payment { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер постановления ")]
        public string res_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата вступления в законную силу")]
        public DateTime? res_date_entry { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата вручении копии постановления")]
        public DateTime? res_date_receiving_copy { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата направления")]
        public DateTime? bai_date_sent { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер письма")]
        public string bai_number { get; set; }

        [StringLength(255)]
        [Display(Name = "Наименование")]
        public string bai_name_bailiffs { get; set; }

        [StringLength(255)]
        [Display(Name = "Адрес")]
        public string bai_address { get; set; }

        [StringLength(70)]
        [Display(Name = "Начальник")]
        public string bai_head { get; set; }

        [StringLength(70)]
        [Display(Name = "Начальник ОЖМ")]
        public string bai_head_protection_nature { get; set; }

        [StringLength(1500)]
        [Display(Name = "Приложение")]
        public string bai_attached { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер протокола")]
        public string pr20_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата протокола")]
        public DateTime? pr20_date { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ознакомления нарушителя")]
        public DateTime? pr20_date_receipt { get; set; }

        [Display(Name = "ФССП")]
        public Guid? bai_spr_bailiffs_id { get; set; }

        [Display(Name = "Орган власти")]
        public Guid? tr_spr_organization_id { get; set; }

        [StringLength(70)]
        [Display(Name = "Начальник ОЖМ")]
        public string tr_head_protection_nature { get; set; }

        [StringLength(70)]
        [Display(Name = "Начальник ОЖМ")]
        public string pr20_head_protection_nature { get; set; }

        [StringLength(5000)]
        [Display(Name = "Текст")]
        public string tr_text { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер")]
        public string tr_number { get; set; }

        [Display(Name = "Номер определения")]
        public string def_nomer { get; set; }              

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "Cопротивление, угрозы, оскорбления")]
        public string pr_resistance { get; set; }

        [StringLength(1500)]
        [Display(Name = "Объяснение физ. лица")]
        public string pr_explanation { get; set; }

        [StringLength(5000)]
        [Display(Name = "Событие правонарушения")]
        public string pr_description { get; set; }

        [StringLength(20)]
        [Display(Name = "Семейное положение")]
        public string pr_marital_status { get; set; }

        [StringLength(100)]
        [Display(Name = "На иждевение")]
        public string pr_dependent { get; set; }

        [StringLength(100)]
        [Display(Name = "Марка транспорта и номер ")]
        public string pr_motor_transport { get; set; }

        [StringLength(500)]
        [Display(Name = "Нарушена статья, пункт, абзац")]
        public string pr_article { get; set; }

        [StringLength(30)]
        [Display(Name = "Калибр орудия")]
        public string pr_gun_caliber { get; set; }

        [StringLength(1500)]
        [Display(Name = "К протоколу прилагается")]
        public string pr_attached { get; set; }

        [Display(Name = "Место работы")]
        public string pr_place_work { get; set; }

        [StringLength(255)]
        [Display(Name = "Свидетель 1")]
        public string pr_witnesses1 { get; set; }

        [StringLength(255)]
        [Display(Name = "Свидетель 2")]
        public string pr_witnesses2 { get; set; }

        [StringLength(255)]
        [Display(Name = "Гражданство")]
        public string pr_citizenship { get; set; }

        [StringLength(255)]
        [Display(Name = "Документ удостоверяющий личность")]
        public string pr_document { get; set; }

        [StringLength(10)]
        [Display(Name = "Серия")]
        public string pr_hunting_lic_serial { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер")]
        public string pr_hunting_lic_number { get; set; }

        [StringLength(255)]
        [Display(Name = "Кем выдан")]
        public string pr_hunting_lic_issue_body { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата выдачи охот. билета")]
        public DateTime? pr_hunting_lic_issue_date { get; set; }

        [StringLength(100)]
        [Display(Name = "Наименование охотугодья")]
        public string pr_hunting_farm_name { get; set; }

        [Display(Name = "Cтатья нарушения")]
        public Guid? pr_spr_violations_part_id { get; set; }

        [Display(Name = "Должность")]
        public string pr_job_pos_name { get; set; }

        [StringLength(100)]
        [Display(Name = "ФИО нарушителя")]
        public string pr_customer_name { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата рождения")]
        public DateTime? pr_birth_date { get; set; }

        [StringLength(255)]
        [Display(Name = "Место рождения")]
        public string pr_birth_place { get; set; }

        [StringLength(255)]
        [Display(Name = "Место жительства")]
        public string pr_customer_address { get; set; }

        [StringLength(100)]
        [Display(Name = "Номер телефона")]
        public string pr_customer_phone_number { get; set; }

        [StringLength(10)]
        [Display(Name = "Серия документа")]
        public string pr_doc_serial { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер документа")]
        public string pr_doc_number { get; set; }
        
        [Column(TypeName = "date")]
        [Display(Name = "Дата выдачи")]
        public DateTime? pr_doc_issue_date { get; set; }

        [StringLength(255)]
        [Display(Name = "Кем выдан")]
        public string pr_doc_issue_body { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер оружия нарушителя")]
        public string pr_gun_number { get; set; }

        [StringLength(70)]
        [Display(Name = "Оружие системы")]
        public string pr_gun { get; set; }

        [StringLength(255)]
        [Display(Name = "Кем выдано")]
        public string pr_gun_permission_issued { get; set; }

        [StringLength(255)]
        [Display(Name = "Место составления протокола")]
        public string pr_place_protocol { get; set; }

        [Required]
        [Display(Name = "Дата и время совершения правонарушения")]
        public DateTime pr_date_law_violation { get; set; }

        [Display(Name = "Дело будет рассмотрено")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy HH':'mm}", ApplyFormatInEditMode = true)]
        public DateTime? pr_date_examination { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер заказного письма")]
        public string pr_number_letter { get; set; }

        [StringLength(255)]
        [Display(Name = "Место составления")]
        public string pr20_place { get; set; }

        [StringLength(255)]
        [Display(Name = "Должность")]
        public string pr20_job_pos_name { get; set; }

        [StringLength(20)]
        [Display(Name = "Инн для ИП")]
        public string pr20_inn { get; set; }

        [StringLength(255)]
        [Display(Name = "Место регистрации")]
        public string pr20_customer_address_legal { get; set; }

        [StringLength(255)]
        [Display(Name = "Документ удостоверяющий личность")]
        public string pr20_document { get; set; }

        [StringLength(1500)]
        [Display(Name = "Обьяснения и замечания лица")]
        public string pr20_explanation { get; set; }

        [StringLength(1500)]
        [Display(Name = "К протоколу прилагается")]
        public string pr20_attached { get; set; }

        [StringLength(100)]
        [Display(Name = "ФИО составителя протокола")]
        public string pr20_name_create { get; set; }

        [StringLength(20)]
        [Display(Name = "Номер заказного письма")]
        public string res_number_letter { get; set; }

        [StringLength(500)]
        [Display(Name = "Реквизиты доверенности")]
        public string res_details_trust { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата отправки заказного письма")]
        public DateTime? res_date_receiving_letter { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата оплаты штрафа")]
        public DateTime? res_payment_date { get; set; }


        [Column(TypeName = "date")]
        [Display(Name = "Дата отправки почтой")]
        public DateTime? pr_date_receiving_letter { get; set; }

        [StringLength(70)]
        [Display(Name = "Начальник управления")]
        public string def_head_managing { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата уведомления")]
        public DateTime? al20_date { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер уведомления")]
        public string al20_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата приглашения")]
        public DateTime? al20_date_invitations { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ознакомления, направления почтой")]
        public DateTime? al20_date_receiving { get; set; }

        [Display(Name = "Ответсвенный")]
        public Guid? tr_spr_employees_id { get; set; }

        [Display(Name = "ФИО составителя протокола")]
        public Guid? pr_spr_employees_id_create { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? pr_spr_employees_id { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? al_spr_employees_id { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? def_spr_employees_id { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? res_spr_employees_id { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? al20_spr_employees_id { get; set; }

        [Display(Name = "Ответсвенный")]
        public Guid? pr20_spr_employees_id { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? bai_spr_employees_id { get; set; }

        [Display(Name = "Ответственный")]
        public Guid? dis_spr_employees_id { get; set; }

        [StringLength(255)]
        [Display(Name = "Адрес рассмотрения")]
        public string pr_address_consideration { get; set; }

        [Column(TypeName ="date")]
        [Display(Name = "Дата уведомления")]
        public DateTime? al_date { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер уведомления")]
        public string al_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата приглашения")]
        public DateTime? al_date_invitations { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ознакомления, направления почтой")]
        public DateTime? al_date_receiving { get; set; }
        
        [Display(Name = "Кем выявлено нарушение")]
        public int? al_who_identified { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер ответа")]
        public string bai_answer_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ответа по приставам")]
        public DateTime? bai_answer_date { get; set; }
                
        [Display(Name = "Результат")]
        public int? bai_spr_bailiffs_result_id { get; set; }

        [StringLength(10)]
        [Display(Name = "Номер ответа по организации")]
        public string tr_answer_number { get; set; }

        [Column(TypeName = "date")]
        [Display(Name = "Дата ответа по организации")]
        public DateTime? tr_answer_date { get; set; }

        [Display(Name = "Результат")]
        public int? tr_spr_organization_result_id { get; set; }

        [StringLength(255)]
        [Display(Name = "Отметка о взыскании штрафа")]
        public string res_payment_mark { get; set; }
                
        [Display(Name = "Сумма штрафа")]
        public Decimal? tr_payment { get; set; }

        [Display(Name = "Отметка о получении протокола")]
        public int? pr_copy { get; set; }


        public data_customer data_customer { get; set; }        
        public spr_organization spr_organization { get; set; }
        public spr_bailiffs spr_bailiffs { get; set; }
        public spr_violations_part spr_violations_part { get; set; }
        public spr_bailiffs_result spr_bailiffs_result { get; set; }
        public spr_organization_result spr_organization_result { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_customer_violations_file> data_customer_violations_file { get; set; }

    }
}
