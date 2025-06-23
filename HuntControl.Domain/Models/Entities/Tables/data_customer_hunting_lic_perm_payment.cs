namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("public.data_customer_hunting_lic_perm_payment")]
    public partial class data_customer_hunting_lic_perm_payment
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        public Guid data_customer_id { get; set; }

        public Guid spr_employees_id { get; set; }

        public int? payment_number { get; set; }

        [DataType(DataType.Date)]
        public DateTime payment_date_enter { get; set; }

        [DataType(DataType.Date)]
        public DateTime? payment_date { get; set; }

        [StringLength(100)]
        public string customer_last_name { get; set; }

        [StringLength(100)]
        public string customer_first_name { get; set; }

        [StringLength(100)]
        public string customer_middle_name { get; set; }

        [StringLength(10)]
        public string document_code { get; set; }

        [StringLength(10)]
        public string document_serial { get; set; }

        [StringLength(20)]
        public string document_number { get; set; }

        [StringLength(30)]
        public string payment_kbk { get; set; }

        [StringLength(30)]
        public string payment_oktmo { get; set; }

        [StringLength(30)]
        public string payment_inn { get; set; }

        [StringLength(30)]
        public string payment_kpp { get; set; }

        [StringLength(70)]
        [Display(Name = "Назначение платежа")]
        public string payment_purpose { get; set; }

        [StringLength(350)]
        [Display(Name = "Получатель")]
        public string payment_recipient { get; set; }

        [Display(Name = "Сумма")]
        [DataType(DataType.Currency)]
        public decimal? payment_value { get; set; }

        [StringLength(20)]
        public string payment_osmp_id { get; set; }

        public int? payment_prv_txn { get; set; }

        public short? payment_agent { get; set; }

        public bool? payment_sign { get; set; }

        [StringLength(20)]
        public string payment_bik { get; set; }

        [StringLength(30)]
        public string payment_rs { get; set; }

        [StringLength(100)]
        public string payment_bank_name { get; set; }

        public short? payment_type { get; set; }

        public int? spr_taxation_id { get; set; }

        public bool is_remove { get; set; }

        public DateTime? date_remove { get; set; }

        [Required]
        [StringLength(70)]
        public string employees_fio { get; set; }

        public virtual spr_taxation spr_taxation { get; set; }
        public virtual spr_employees spr_employees { get; set; }
        public virtual data_customer data_customer { get; set; }
    }
}
