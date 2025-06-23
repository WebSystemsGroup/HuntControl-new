namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportHuntingLicPermResult
    {
        [Display(Name = "ФИО")]
        public string out_customer_name { get; set; }

        [Display(Name = "Телефон1")]
        public string out_phone_number1 { get; set; }

        [Display(Name = "Телефон2")]
        public string out_phone_number2 { get; set; }

        [Display(Name = "Адрес проживания")]
        public string out_actual_address { get; set; }

        [Display(Name = "Серия бланка")]
        public string out_serial_form { get; set; }

        [Display(Name = "Номер бланка")]
        public string out_number_form { get; set; }

        [Display(Name = "Дата окончания сезона")]
        [Column(TypeName ="date")]
        //[DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_stop { get; set; }

        [Display(Name = "Охотугодья")]
        public string out_hunting_farm_name { get; set; }

        [Display(Name = "Группа видов")]
        public string out_season_name { get; set; }

        [Display(Name = "Дата выдачи")]
        [Column(TypeName = "date")]
        public DateTime? out_date_given { get; set; }

        [Display(Name = "Разрешение выдал")]
        public string out_fio_given { get; set; }

        [Display(Name = "Количество животных")]
        public int? out_count_animal { get; set; }
        [Display(Name = "Физ лицо")]
        public Guid out_data_customer_id { get; set; }

    }
}
