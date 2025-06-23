using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SprServicesSubSelectResult
    {

        public Guid out_spr_services_sub_id { get; set; }

        [Display(Name = "Наименование")]
        public string out_service_name { get; set; }

        [Display(Name = "Поставщик")]
        public string out_service_provider_name { get; set; }

        [Display(Name = "Мнемоника")]
        public string out_service_mnemo { get; set; }
        public short out_count_day_execution { get; set; }
        public short out_count_day_processing { get; set; }
        public short out_count_day_return { get; set; }
        public decimal out_tariff_ { get; set; }
        public decimal out_charge_ { get; set; }


    }
}
