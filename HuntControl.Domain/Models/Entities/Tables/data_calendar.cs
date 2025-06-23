namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_calendar")]
    public partial class data_calendar
    {
        [Key]
        [Column(TypeName = "date")]
        public DateTime date_ { get; set; }

        public short date_type { get; set; }

        public DateTime set_date { get; set; }

        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        public virtual data_calendar_day_type data_calendar_day_type { get; set; }
    }
}
