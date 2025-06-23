using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class HuntingFarmViewModel
    {
        public IEnumerable<spr_legal_person> LegalPersonList { get; set; }
        public IEnumerable<spr_hunting_farm> HuntingFarmList { get; set; }
        public IEnumerable<spr_hunting_farm_season> HuntingFarmSeasonList { get; set; }
        public IEnumerable<spr_hunting_farm_season_animal> HuntingFarmSeasonAnimalList { get; set; }
        public IEnumerable<spr_hunting_farm_season_forms> HuntingFarmSeasonFormList { get; set; }
        public IEnumerable<spr_hunting_farm_limit> HuntingFarmLimitList { get; set; }
        public IEnumerable<spr_hunting_farm_accounting> HuntingFarmAccountingList { get; set; }
        public IEnumerable<spr_hunting_farm_animal> HuntingFarmAnimalList { get; set; }
        public IEnumerable<spr_hunting_farm_type> HuntingFarmTypeList { get; set; }
        public IEnumerable<spr_season> spr_season { get; set; }



        public PageInfo PageInfo { get; set; }
    }

    public class HuntingFarmLocationModel
    {
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }
    }

}