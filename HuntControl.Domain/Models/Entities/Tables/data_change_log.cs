namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_change_log")]
    public partial class data_change_log
    {

        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [Display(Name = "�������")]
        public string table_name_ { get; set; }

        [Required]
        [Display(Name = "����")]
        public string field_name_ { get; set; }

        [Display(Name = "������ ��������")]
        public string old_value { get; set; }

        [Display(Name = "����� ��������")]
        public string new_value { get; set; }

        [Required]
        [StringLength(70)]
        [Display(Name = "�������")]
        public string employees_fio { get; set; }


        [Required]
        [Display(Name = "����")]
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime? date_change { get; set; }

        [Display(Name = "�����������")]
        public string commentt { get; set; }

        [Display(Name = "���. ����")]
        public Guid? data_customer_id { get; set; }

        [Display(Name = "����� ����")]
        public string data_services_info_id { get; set; }

        [Display(Name = "�������")]
        public string table_name_base_ { get; set; }

        [Display(Name = "����")]
        public string field_name_base_ { get; set; }


    }
}
