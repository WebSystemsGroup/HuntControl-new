namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.epgu_slot_time_book")]
    public partial class epgu_slot_time_book
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        public Guid epgu_slot_time_id { get; set; }

        [Required]
        public string book_id { get; set; }

        [Required]
        public string esia_id { get; set; }

        [Required]
        public string organization_id { get; set; }

        [Required]
        public string user_type { get; set; }

        public string last_name { get; set; }
        public string first_name { get; set; }
        public string patronymic { get; set; }
        public string e_mail { get; set; }
        public string mobile_phone { get; set; }
        public string snils { get; set; }
        public string case_number { get; set; }
        public string service_id { get; set; }
        public string area_id { get; set; }

        [Required]
        public bool preliminary_reservation { get; set; }

        [DataType(DataType.Date)]
        public DateTime visit_time { get; set; }
        [Required]
        public bool is_test_pgu { get; set; }

    }
}
