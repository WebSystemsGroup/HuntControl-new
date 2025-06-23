using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class StatisticsViewModel
    {

        public IEnumerable<MainCountEpguAndMfcResult> MainCountEpguAndMfcList { get; set; }
        public IEnumerable<MainCountHuntingFarmResult> MainCountHuntingFarmList { get; set; }
        public IEnumerable<MainCountIssueAndCancelledHuntingLicResult> MainCountIssueAndCancelledHuntingLicList { get; set; }
        public IEnumerable<MainCountIssueGroupTypeResult> MainCountIssueGroupTypeList { get; set; }
        public IEnumerable<MainCountViolationsResult> MainCountViolationsList { get; set; }
        public MainGeneralInformationResult MainGeneralInformationList { get; set; }
        public PageInfo PageInfo { get; set; }
    }

}