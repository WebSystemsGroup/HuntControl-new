namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_services_commentt_recipient")]
    public partial class data_services_commentt_recipient
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_services_commentt_id { get; set; }

        public Guid spr_employees_id_recipient { get; set; }

        [Display(Name = "Дата прочтения")]
        public DateTime? date_read { get; set; }

        [StringLength(70)]
        public string employees_fio { get; set; }

        [StringLength(70)]
        public string employees_fio_read { get; set; }

        [StringLength(100)]
        public string employees_mfc_name { get; set; }

        [StringLength(30)]
        public string employees_job_pos_name { get; set; }

        [Display(Name = "Удален")]
        public bool? is_remove { get; set; }

        [Display(Name = "Кто удалил")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "Дата удаления")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "Причина удаления")]
        public string commentt_remove { get; set; }              
        

        public virtual data_services_commentt data_services_commentt { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
