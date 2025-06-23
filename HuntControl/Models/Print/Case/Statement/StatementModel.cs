using HuntControl.Domain.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HuntControl.WebUI.Models.Print.Case.Statement
{
    public class StatementModel
    {
        public StatementInfoGetResult StatementInfoGet { get; set; }
        public IEnumerable<StatementDocumentSelectResult> StatementDocumentSelectList { get; set; }
        public IEnumerable<data_services_customer> DataServiceCustomerList { get; set; }

    }
}