namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_violations_file")]
    public partial class data_customer_violations_file
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Required]
        [StringLength(255)]
        [Display(Name = "Имя файла")]
        public string file_name { get; set; }

        
        [StringLength(10)]
        [Display(Name = "Расширение")]
        public string file_ext { get; set; }

        
        [Display(Name = "Размер")]
        public int file_size { get; set; }


        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата и время добавления")]
        public DateTime set_date { get; set; }

        
        [StringLength(70)]
        [Display(Name = "Кто добавил запись")]
        public string employees_fio { get; set; }

        [Display(Name = "Комментарий")]
        public string commentt { get; set; }        

        [StringLength(70)]
        [Display(Name = "Кто редактировал запись")]
        public string employees_fio_modifi { get; set; }

        [Display(Name = "Удалена запись или нет")]
        public bool is_remove { get; set; }

        [StringLength(70)]
        [Display(Name = "Кто удалил запись")]
        public string employees_fio_remove { get; set; }

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [Display(Name = "Дата удаления записи")]
        public DateTime? date_remove { get; set; }

        [StringLength(255)]
        [Display(Name = "Комментарий при удалении записи")]
        public string commentt_remove { get; set; }

        [Display(Name = "Нарушение, связь с data_customer_violations id")]
        public Guid data_customer_violations_id { get; set; }
        
        public virtual data_customer_violations data_customer_violations { get; set; }
    }
}
