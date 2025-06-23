namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class MainCountHuntingFarmResult
    {
        public string out_hunting_farm_name { get; set; }
        public int out_count { get; set; }
    }
}
