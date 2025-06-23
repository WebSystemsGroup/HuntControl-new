using System.ComponentModel;

namespace HuntControl.Domain.Concrete
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SprServicesSubCustomerTypeRecipientSelect
    {

        [Display(Name = "Айди")]
        public int out_spr_services_sub_type_recipient_id { get; set; }

        [Display(Name = "Наименование")]
        public string out_type_name { get; set; }

    }
}
