namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportHuntingLicIssuedReestrResult
    {
        [Display(Name = "ФИО")]
        public string out_customer_name { get; set; }

        [Display(Name = "Дата рождения")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_doc_birth_date { get; set; }

        [Display(Name = "Место рождения")]
        public string out_doc_birth_place { get; set; }

        [Display(Name = "Адрес регистрации")]
        public string out_legal_address { get; set; }

        [Display(Name = "Телефон")]
        public string out_phone_number { get; set; }

        [Display(Name = "Эл. почта")]
        public string out_e_mail { get; set; }

        [Display(Name = "Дата выдачи")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_doc_issue_date { get; set; }

        [Display(Name = "Адрес проживания")]
        public string out_actual_address { get; set; }

        [Display(Name = "Серия")]
        public string out_serial_license { get; set; }

        [Display(Name = "Номер")]
        public string out_number_license { get; set; }

        [Display(Name = "Дата выдачи")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_issue_date { get; set; }

        [Display(Name = "Серия документа")]
        public string out_doc_serial { get; set; }

        [Display(Name = "Номер документа")]
        public string out_doc_number { get; set; }

        [Display(Name = "Кем выдан")]
        public string out_doc_issue_body { get; set; }

        [Display(Name = "Организация")]
        public string out_social_organization_info { get; set; }

        [Display(Name = "Должность")]
        public string out_social_job_position { get; set; }

        [Display(Name = "Пенсионер")]
        public string out_social_pensioner { get; set; }

        [Display(Name = "Нетрудоспособный")]
        public string out_social_incapable { get; set; }

        [Display(Name = "Дата внесения в реестр")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_reestr_date { get; set; }

        [Display(Name = "Дата аннулирования")]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_cancelled_date { get; set; }

        [Display(Name = "Основание аннулирования")]
        public string out_cancelled_ground { get; set; }

        [Display(Name = "Физ лицо")]
        public Guid out_data_customer_id { get; set; }

    }
}
