using System;
using System.Collections.Generic;

namespace Attendance.Web.Models
{
    public class WeeklyEventSchedLists:List<WeeklyEventSched>
    {
    }

    public class WeeklyEventSched
    {
        public int wsid { get; set; }

        public int weid { get; set; }

        public string wklyeventname { get; set; }

        public int week { get; set; }

        public int day { get; set; }

        public int visibility { get; set; }

        public DateTime starttime { get; set; }

        public DateTime endtime { get; set; }

        public int locationid { get; set; }

        public int roomid { get; set; }

    }
}