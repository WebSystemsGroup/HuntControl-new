namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.spr_document_identity")]
    public partial class spr_document_identity
    {
        [Display(Name = "ID")]
        public int id { get; set; }

        [Required]
        [Display(Name = "������������")]
        public string document_name { get; set; }

        [Required]
        [Display(Name = "������� ������������")]
        public string document_name_small { get; set; }

        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [Display(Name = "���� �����������")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime set_date { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }

        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "������")]
        public bool? is_remove { get; set; }

        [Display(Name = "��� ������")]
        public string employees_fio_remove { get; set; }

        [Display(Name = "��� ������")]
        public DateTime? date_remove { get; set; }

        [Display(Name = "������� ��������")]
        public string commentt_remove { get; set; }
    }
}
