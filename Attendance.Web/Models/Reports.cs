using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MvcApplication1.Models;

namespace MvcApplication1.Models
{
    public class Reports : List<AttendanceReport>
    {
        public string attendancedate;
    
        public int locationid { get; set; }
    
        public string notes { get; set; }
        
        public int attendancecount { get; set; }

        public string starttime { get; set; }
    }

    public class AttendanceReport
    {
        public int attendanceid { get; set; }

        public string attendancedate { get; set; }

        public int attendancecount { get; set; }

        public int wsid { get; set; }

        public int locationid { get; set; }

        public string notes { get; set; }

        public LocationLists Location { get; set; }

        public RoomsLists Rooms { get; set; }

        public WeeklyEventLists WeeklyEvent { get; set; }

        public WeeklyEventSchedLists WeeklyEventSched { get; set; }

        public string EventName { get; set; }

        public string starttime { get; set; }


        internal void Add(Attendance a)
        {
            throw new NotImplementedException();
        }
    }
}