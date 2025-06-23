namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingFarmActiveHuntingTypeSelectResult
    {
        public Guid out_spr_hunting_type_id { get; set; }
        public string out_type_name { get; set; }
    }
}
