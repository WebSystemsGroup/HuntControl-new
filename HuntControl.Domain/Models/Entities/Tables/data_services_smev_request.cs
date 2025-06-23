namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_smev_request")]
    public partial class data_services_smev_request
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public int spr_smev_request_id { get; set; }

        public Guid spr_employees_id { get; set; }

        [StringLength(70)]
        public string message_id { get; set; }

        [StringLength(70)]
        public string message_id_provider { get; set; }

        [StringLength(70)]
        public string request_id_ref { get; set; }

        [Column(TypeName = "date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? date_request { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? time_request { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_response { get; set; }

        [Column(TypeName = "time")]
        public TimeSpan? time_response { get; set; }

        public short? count_day_execution { get; set; }

        public short? spr_services_sub_week_id { get; set; }

        [StringLength(70)]
        public string employees_fio { get; set; }

        [MaxLength(2147483647)]
        public byte[] request_html { get; set; }

        [MaxLength(2147483647)]
        public byte[] response_html { get; set; }

        [MaxLength(2147483647)]
        public byte[] response_html_int { get; set; }

        public Guid data_services_id { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_response_reg { get; set; }

        [StringLength(255)]
        public string response_file_name { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_smev_log> data_services_smev_log { get; set; }

        public virtual spr_employees spr_employees { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }

        public virtual spr_smev_request spr_smev_request { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_smev_request_status> data_services_smev_request_status { get; set; }
    }
}
