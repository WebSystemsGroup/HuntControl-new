namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportHuntingLicPermResult
    {
        [Display(Name = "���")]
        public string out_customer_name { get; set; }

        [Display(Name = "�������1")]
        public string out_phone_number1 { get; set; }

        [Display(Name = "�������2")]
        public string out_phone_number2 { get; set; }

        [Display(Name = "����� ����������")]
        public string out_actual_address { get; set; }

        [Display(Name = "����� ������")]
        public string out_serial_form { get; set; }

        [Display(Name = "����� ������")]
        public string out_number_form { get; set; }

        [Display(Name = "���� ��������� ������")]
        [Column(TypeName ="date")]
        //[DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime? out_date_stop { get; set; }

        [Display(Name = "����������")]
        public string out_hunting_farm_name { get; set; }

        [Display(Name = "������ �����")]
        public string out_season_name { get; set; }

        [Display(Name = "���� ������")]
        [Column(TypeName = "date")]
        public DateTime? out_date_given { get; set; }

        [Display(Name = "���������� �����")]
        public string out_fio_given { get; set; }

        [Display(Name = "���������� ��������")]
        public int? out_count_animal { get; set; }
        [Display(Name = "��� ����")]
        public Guid out_data_customer_id { get; set; }

    }
}
