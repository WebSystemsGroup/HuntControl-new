using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SprServicesSubTariffSelectResult
    {
        [Display(Name = "Обработка")]
        public short out_count_day_processing { get; set; }

        [Display(Name = "Срок исполнения")]
        public short out_count_day_execution { get; set; }

        [Display(Name = "Возврат")]
        public short out_count_day_return { get; set; }

        [Display(Name = "Гос. пошлина")]
        public decimal out_tariff_ { get; set; }

        [Display(Name = "Тип расчета")]
        public short out_spr_services_sub_week_id { get; set; }

        public int out_spr_services_sub_tariff_type_id { get; set; }

        public Guid out_spr_services_sub_tariff_id { get; set; }

        [Display(Name = "Тариф")]
        public string out_type_tariff_name { get; set; }

        [Display(Name = "Тип расчета")]
        public string out_type_week_name { get; set; }

        [Display(Name = "Примечание")]
        public string out_commentt { get; set; }

        [Display(Name = "Сбор")]
        public decimal out_charge_ { get; set; }

    }
}
