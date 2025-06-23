namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services")]
    public partial class data_services
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(70)]
        public string data_services_info_id { get; set; }

        public int spr_services_sub_tr_id { get; set; }

        [Column(TypeName = "date")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [DisplayFormat(DataFormatString = "{0:dd'.'MM'.'yyyy}", ApplyFormatInEditMode = true)]
        public DateTime date_enter { get; set; }

        public decimal tariff_state { get; set; }

        [Column(TypeName = "date")]
        public DateTime? date_finish_fact { get; set; }

        [Column(TypeName = "date")]
        public DateTime date_finish_total { get; set; }

        [StringLength(255)]
        public string commentt { get; set; }

        public short spr_services_sub_status_id { get; set; }

        public Guid spr_services_sub_id { get; set; }

        public int count_day_execution { get; set; }

        public short spr_services_sub_week_id { get; set; }

        public Guid spr_employees_id { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        public int count_day_processing { get; set; }

        public int count_day_return { get; set; }

        public Guid? spr_employees_id_execution { get; set; }

        public int spr_employees_job_pos_id { get; set; }

        public int? spr_employees_job_pos_id_execution { get; set; }
        
        [StringLength(1000)]
        public string spr_services_sub_name { get; set; }
        
        [StringLength(350)]
        public string spr_services_provider_name { get; set; }

        public Guid? spr_employees_id_current { get; set; }

        public int? spr_routes_stage_id_current { get; set; }

        [Column(TypeName = "date")]
        public DateTime? routes_stage_date_finish_reg { get; set; }

        [StringLength(30)]
        public string frgu_target_id { get; set; }

        [StringLength(30)]
        public string frgu_services_id { get; set; }

        [StringLength(30)]
        public string frgu_provider_id { get; set; }

        public int? spr_services_sub_tariff_type_id { get; set; }

        public Guid spr_services_sub_way_get_id { get; set; }

        [StringLength(70)]
        public string employees_fio_execution { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        public string epgu_id_form { get; set; }

        public decimal? charge_ { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_employees_alert> data_employees_alert { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_commentt> data_services_commentt { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_customer_call> data_services_customer_call { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_customer> data_services_customer { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_customer_message> data_services_customer_message { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_document> data_services_document { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<data_services_routes_stage> data_services_routes_stage { get; set; }

        public virtual spr_employees spr_employees { get; set; }

        public virtual spr_employees spr_employees_execution { get; set; }

        public virtual spr_employees_job_pos spr_employees_job_pos { get; set; }
        public virtual spr_employees_job_pos spr_employees_job_pos_execution { get; set; }
        public virtual spr_services_sub_status spr_services_sub_status { get; set; }

        public virtual spr_services_sub_tariff_type spr_services_sub_tariff_type { get; set; }

        public virtual spr_services_sub_type_recipient spr_services_sub_type_recipient { get; set; }

        public virtual spr_services_sub_way_get spr_services_sub_way_get { get; set; }

        public virtual spr_services_sub_week spr_services_sub_week { get; set; }
    }
}
