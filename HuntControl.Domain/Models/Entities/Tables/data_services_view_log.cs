namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_view_log")]
    public partial class data_services_view_log
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Сотрудник")]
        public Guid spr_employees_id { get; set; }

        [Required]
        [StringLength(30)]
        [Display(Name = "Должность")]
        public string employees_job_pos_name { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Сотрудник")]
        public string employees_fio { get; set; }

        [Display(Name = "Дата фактическая")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "Номер дела")]
        public string data_services_info_id { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
