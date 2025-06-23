namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_routes_stage_next")]
    public partial class spr_routes_stage_next
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int id { get; set; }

        public int spr_routes_stage_id { get; set; }

        public int spr_routes_stage_next_id { get; set; }

        public virtual spr_routes_stage spr_routes_stage { get; set; }

        public virtual spr_routes_stage spr_routes_stage1 { get; set; }
    }
}
