using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HuntControl.Domain.Concrete
{
   public partial class DataCustomerHuntingLicPermSelect
    {
        public string out_fio_given { get; set; }
        public string out_hunting_type_name { get; set; }
        public string out_season_name { get; set; }
        public string out_hunting_farm_name { get; set; }
        public string out_serial_form { get; set; }

        public string out_number_form { get; set; }

        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? out_date_given { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? out_date_start { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? out_date_stop { get; set; }

        public decimal? out_tariff { get; set; }
        public decimal? out_charge { get; set; }

        public string out_employees_fio { get; set; }

        public DateTime? out_set_date { get; set; }

        public string out_employees_fio_modifi { get; set; }

        public DateTime? out_date_remove { get; set; }

        public bool? out_is_remove { get; set; }

        public string out_employees_fio_remove { get; set; }
        public string out_commentt_remove { get; set; }

        public int? out_count_animal { get; set; }
        public int? out_count_back { get; set; }
        public Guid? out_spr_hunting_farm_id { get; set; }
        public Guid? out_data_customer_hunting_lic_perm_id { get; set; }
        public int? out_spr_season_id { get; set; }
        //public int? out_s_form_type_id { get; set; }
    }
}
