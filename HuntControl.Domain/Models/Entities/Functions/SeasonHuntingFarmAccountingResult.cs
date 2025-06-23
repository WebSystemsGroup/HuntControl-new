namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SeasonHuntingFarmAccountingResult
    {
        public string out_hunting_farm_name { get; set; }
        public bool out_is_there { get; set; }
    }
}
