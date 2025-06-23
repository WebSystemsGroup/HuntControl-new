using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class SmevRequestFormModel
    {
        public int? Id { get; set; }
        public DateTime? DocumentBirthDate { get; set; }
        public string CustomerName { get; set; }
        public string CustomerTel1 { get; set; }
        public string CustomerTel2 { get; set; }
        public string CustomerEmail { get; set; }
        public string CustomerSex { get; set; }
        public string DocumentSerial { get; set; }
        public string DocumentNumber { get; set; }
        public string DocumentBirthPlace { get; set; }
        public DateTime? DocumentIssueDate { get; set; }
        public string DocumentIssuePlace { get; set; }
        public string CustomerSnils { get; set; }
        public string CustomerInn { get; set; }
        public string DocumentCode { get; set; }
        public string CustomerLegalAddress { get; set; }
    }
}