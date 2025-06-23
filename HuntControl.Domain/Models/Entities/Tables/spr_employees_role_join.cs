namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_employees_role_join")]
    public partial class spr_employees_role_join
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Сотрудник")]
        public Guid spr_employees_id { get; set; }

        [Display(Name = "Роль")]
        public int spr_employees_role_id { get; set; }

        [StringLength(100)]
        public string enter_user { get; set; }

        public DateTime? enter_date { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарии")]
        public string commentt { get; set; }

        public virtual spr_employees spr_employees { get; set; }

        public virtual spr_employees_role spr_employees_role { get; set; }
    }
}
