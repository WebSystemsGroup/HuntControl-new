namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class HuntingLimitAnimalSelectResult
    {
        public Guid? out_spr_animal_id { get; set; }
        public int? out_limit_day { get; set; }
        public int? out_limit_season { get; set; }
        public string out_animal_name { get; set; }
        public DateTime? out_date_start { get; set; }
        public DateTime? out_date_stop { get; set; }
        public int? out_animal_sex { get; set; }
        public int? out_animal_age { get; set; }
    }
}
