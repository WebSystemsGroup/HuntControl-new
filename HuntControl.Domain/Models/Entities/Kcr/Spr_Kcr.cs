using System;
using System.ComponentModel.DataAnnotations;

namespace HuntControl.Domain.Models.Entities
{
    public class Spr_Kcr
    {
        [Display(Name = "Идентификатор цифрового регламента")]
        [StringLength(12)]
        [Required]
        public string id { get; set; }

        [Display(Name = "Наименование цифрового регламента")]
        [StringLength(255)]        
        public string name { get; set; }

        [Display(Name = "Идентификатор услуги")]
        public Guid? spr_services_id { get; set; }
    }
}
