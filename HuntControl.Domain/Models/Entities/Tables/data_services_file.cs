namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_file")]
    public partial class data_services_file
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_services_table_id { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime date_enter { get; set; }

        [Required]
        [StringLength(400)]
        public string file_name { get; set; }

        [Required]
        [StringLength(10)]
        public string file_ext { get; set; }

        public int file_size { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        public Guid spr_employees_id { get; set; }

        public short? file_flag { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
