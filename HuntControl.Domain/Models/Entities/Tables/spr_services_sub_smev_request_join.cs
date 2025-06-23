namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_services_sub_smev_request_join")]
    public partial class spr_services_sub_smev_request_join
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "���� ������")]
        public int spr_smev_request_id { get; set; }

        [Display(Name = "������")]
        public Guid spr_services_sub_id { get; set; }

        [Display(Name = "���� ����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(255)]
        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        public virtual spr_services_sub spr_services_sub { get; set; }

        public virtual spr_smev_request spr_smev_request { get; set; }
    }
}
