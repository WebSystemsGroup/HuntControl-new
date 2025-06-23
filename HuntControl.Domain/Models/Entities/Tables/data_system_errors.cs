namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_system_errors")]
    public partial class data_system_errors
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "����� ������")]
        public string error_message { get; set; }

        [Display(Name = "��������� ������")]
        public string error_inner_exception { get; set; }

        [Required]
        [Display(Name = "���������")]
        public string employees_fio { get; set; }

        [Required]
        [Display(Name = "���������")]
        public Guid spr_employees_id { get; set; }

        [Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "���� ������")]
        public DateTime error_date { get; set; }

        [Required]
        [Display(Name = "����������� �����")]
        public string stack_trace { get; set; }

        public virtual spr_employees spr_employees { get; set; }
    }
}
