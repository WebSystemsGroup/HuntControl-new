namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_account")]
    public partial class spr_account
    {
        [Key]
        public Guid id { get; set; }

        [Required]
        [Display(Name ="Логин")]
        public string employees_login { get; set; }

        [Required]
        [Display(Name ="Пароль")]
        public string employees_password { get; set; }

        [Required]
        [Display(Name ="Имя")]
        public string employees_name { get; set; }

        [Required]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio_add { get; set; }

        [StringLength(70)]
        public string employees_fio_modifi { get; set; }

        [Required]
        public bool is_remove { get; set; }
        public string commentt_modifi { get; set; }
        public string ip_address_add { get; set; }
        public string ip_address_modify { get; set; }

    }
}
