namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingFarmSeasonAnimalSelectResult
    {
        public Guid out_spr_animal_id { get; set; }
        public string out_spr_animal_name { get; set; }
    }
}
