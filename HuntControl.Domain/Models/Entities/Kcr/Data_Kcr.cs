using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace HuntControl.Domain.Models.Entities
{
    public class Data_Kcr
    {
        [Key, DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid id { get; set; }

        [Display(Name = "Идентификатор цифрового регламента")]
        [Required]
        public string spr_kcr_id { get; set; }

        [Display(Name = "Цифровой регламент в формате json")]
        [Required]
        public byte[] json { get; set; }

        [Display(Name = "Дата добавления")]
        [Required]
        public DateTime date_add { get; set; }
    }
}
