namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.epgu_slot_time")]
    public partial class epgu_slot_time
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public DateTime visit_time { get; set; }
        [Required]
        public bool is_test_pgu { get; set; }

        [Required]
        [StringLength(20)]
        public string service_id { get; set; }
        [Required]
        [StringLength(50)]
        public string area_id { get; set; }
    }
}
