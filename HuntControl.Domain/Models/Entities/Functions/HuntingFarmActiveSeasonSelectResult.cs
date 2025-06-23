namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingFarmActiveSeasonSelectResult
    {
        public Guid out_spr_hunting_farm_id { get; set; }
        public string out_hunting_farm_name { get; set; }
    }
}
