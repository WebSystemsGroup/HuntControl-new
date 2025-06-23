namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class ReportReestrCountServiceResult
    {
        [Display(Name = "Поставщик")]
        public string out_provider_name { get; set; }

        [Display(Name = "Услуга")]
        public string out_service_name { get; set; }

        [Display(Name = "Количество услуг")]
        public decimal? out_service_count { get; set; }

        [Display(Name = "Сбор")]
        public decimal? out_service_charge { get; set; }

        [Display(Name = "Тариф")]
        public decimal? out_service_tariff { get; set; }

        [Display(Name = "Сумма сбора")]
        public decimal? out_service_charge_sum { get; set; }

        [Display(Name = "Сумма тарифа")]
        public decimal? out_service_tariff_sum { get; set; }

        [Display(Name = "Физ лицо")]
        public Guid out_data_customer_id { get; set; }

    }
}
