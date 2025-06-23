using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class ReferenceViewModel
    {
        public IEnumerable<spr_bank> SprBankList { get; set; }
        public IEnumerable<spr_account> SprAccountList { get; set; }
        public IEnumerable<spr_document_identity> SprDocumentIdentityList { get; set; }
        public IEnumerable<spr_services_type> SprServiceTypeList { get; set; }
        public IEnumerable<spr_hunting_type> SprHuntingTypeList { get; set; }
        public IEnumerable<spr_animal_hunting_type_join> SprHuntingTypeAnimalList { get; set; }
        public IEnumerable<spr_violations> SprViolationList { get; set; }
        public IEnumerable<spr_violations_part> SprViolationPartList { get; set; }
        public IEnumerable<spr_season> SprSeasonList { get; set; }
        public IEnumerable<spr_season_open> SprSeasonOpens { get; set; }
        public IEnumerable<spr_season_animal> SprSeasonAnimalList { get; set; }
        public IEnumerable<spr_season_open_animal> SprSeasonOpenAnimals { get; set; }
        public IEnumerable<data_change_log> DataChangeLogList { get; set; }
        public PageInfo PageInfo { get; set; }
    }
}