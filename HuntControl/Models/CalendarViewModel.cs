using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HuntControl.Domain.Concrete;

namespace HuntControl.WebUI.Models
{
    public class CalendarViewModel
    {

        public IEnumerable<data_calendar> DataCalendarList { get; set; }
        public IEnumerable<data_calendar_day_type> DataCalendarDayTypeList { get; set; }
    }

}