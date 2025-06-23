namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingFarmActiveGroupTypeSelectResult
    {
        public Guid? out_spr_animal_group_type_id { get; set; }
        public string out_group_type_name { get; set; }
        public DateTime? out_date_start { get; set; }
        public DateTime? out_date_stop { get; set; }
        public Guid? out_spr_hunting_farm_season_id { get; set; }
        public string out_season_name { get; set; }
        public int out_spr_season_id { get; set; }
    }
}
