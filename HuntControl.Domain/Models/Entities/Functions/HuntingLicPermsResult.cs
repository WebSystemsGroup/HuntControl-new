namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingLicPermsResult
    {
        [Display(Name = "Заявитель")]
        public string out_customer_name { get; set; }

        [Display(Name = "Телефон1")]
        public string out_phone_number1 { get; set; }

        [Display(Name = "Телефон2")]
        public string out_phone_number2 { get; set; }

        [Display(Name = "Адрес")]
        public string out_address { get; set; }

        [Display(Name = "Серия")]
        public string out_hunting_lic_serial { get; set; }

        [Display(Name = "Номер")]
        public string out_hunting_lic_number { get; set; }

        [Display(Name = "Дата выдачи")]
        public DateTime? out_hunting_lic_issue_date { get; set; }

        [Display(Name = "Серия документа")]
        public string out_doc_serial { get; set; }

        [Display(Name = "Номер документа")]
        public string out_doc_number { get; set; }

        [Display(Name = "Дата вылачи документа")]
        public DateTime? out_doc_issue_date { get; set; }

        [Display(Name = "Кем выдан документ")]
        public string out_doc_issue_body { get; set; }

        [Display(Name = "Тип")]
        public string out_hunting_type_name { get; set; }
        [Display(Name = "Группа видов")]
        public string out_group_type_name { get; set; }
        
        [Display(Name = "Дата начала")]
        public DateTime? out_date_start { get; set; }

        [Display(Name = "Дата окончания")]
        public DateTime? out_date_stop { get; set; }

        [Display(Name = "Группа")]
        public string out_season_name { get; set; }

        [Display(Name = "Госпошлина")]
        public Decimal? out_tariff_  { get; set; }

        [Display(Name = "Сумма штрафа")]
        public Decimal? out_charge_ { get; set; }

        [Display(Name = "Установленный сбор")]
        public string out_social_organization_info { get; set; }

        [Display(Name = "Охотугодье")]
        public string out_hunting_farm_name { get; set; }

        [Display(Name = "Должность")]
        public string out_job_pos_name { get; set; }

        [Display(Name = "Сотрудник")]
        public string out_employees_fio { get; set; }

        [Display(Name = "Дата выдачи")]
        public DateTime? out_date_given { get; set; }

        [Display(Name = "Начальник")]
        public string out_head_services { get; set; }
    }
}
