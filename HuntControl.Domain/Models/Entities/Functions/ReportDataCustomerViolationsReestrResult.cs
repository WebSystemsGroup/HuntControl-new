namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportDataCustomerViolationsReestrResult
    {
        [Display(Name = "Номер дела")]
        public string out_pr_number_case { get; set; }

        [Display(Name = "Дата поступления протокола в ОЖМ")]
        public DateTime? out_pr_date_in_ogm { get; set; }

        [Display(Name = "№ протокола")]
        public string out_pr_number_protocol { get; set; }

        [Display(Name = "Дата составления протокола")]
        public DateTime? out_pr_date_create { get; set; }

        [Display(Name = "Место составления протокола")]
        public string out_pr_place_protocol { get; set; }

        [Display(Name = "ФИО нарушителя")]
        public string out_pr_customer_name { get; set; }

        [Display(Name = "Место жительство нарушителя")]
        public string out_pr_customer_address { get; set; }

        [Display(Name = "Контактный телефон нарушителя")]
        public string out_pr_customer_phone_number { get; set; }

        [Display(Name = "Дата рождения нарушителя")]
        public DateTime? out_pr_birth_date { get; set; }

        [Display(Name = "Статья нарушения по КоАП РФ")]
        public string out_violations_name { get; set; }
        
        [Display(Name = "Дата и номер направления определения")]
        public DateTime? out_def_date_sent { get; set; }

        [Display(Name = "Дата получения уведомления о вручении определения")]
        public DateTime? out_def_date_handing { get; set; }

        [Display(Name = "Дата постановления")]
        public DateTime? out_res_date { get; set; }

        [Display(Name = "Номер постановления")]
        public string out_res_number { get; set; }

        [Display(Name = "Сумма штрафа")]
        public Decimal? out_res_amount_fine { get; set; }

        [Display(Name = "Дата направления постановления")]
        public DateTime? out_res_date_receiving_letter { get; set; }

        [Display(Name = "Сумма причиненного вреда")]
        public string out_res_amount_harm { get; set; }

        [Display(Name = "Дата получения уведомления о вручении постановления")]
        public DateTime? out_res_date_handing { get; set; }

        [Display(Name = "Дата вступления постановления в законную силу")]
        public DateTime? out_res_date_entry { get; set; }

        [Display(Name = "Оплата штрафа нарушителя")]
        public string out_res_payment { get; set; }

        [Display(Name = "Дата направления в ФССП")]
        public DateTime? out_bai_date_sent { get; set; }

        [Display(Name = "Дата направления в орган власти")]
        public DateTime? out_tr_date_sent { get; set; }

        [Display(Name = "Описание статьи")]
        public string out_violations_part_text { get; set; }

        [Display(Name = "ID")]
        public Guid? out_data_customer_id { get; set; }
    }
}
