namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;


    public partial class CustomerHuntingSeason
    {
        public Guid out_spr_hunting_farm_id { get; set; }
        public Guid out_spr_animal_id { get; set; }
        public string out_animal_name { get; set; }
        public int out_count_animal { get; set; }
        public string out_hunting_farm_name { get; set; }
        public Guid out_spr_hunting_farm_accounting_id { get; set; }

    }
}
