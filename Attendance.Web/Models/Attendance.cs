using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Attendance.Web.Models
{
    public class AttendanceList : List<Attendance>
    {
        public string attendancedate;
        // public DateTime dtDate { get; set; }
        public int locationid { get; set; }
        public string starttime {get; set; }
    }

    public class Attendance
    {
        public int attendanceid { get; set; }

        public string attendancedate { get; set; }

        public int attendancecount { get; set; }

        public int wsid { get; set; }

        [Required(ErrorMessage="Really, the location is required!")]
        public int? locationid { get; set; }

        public string notes { get; set; }

        public LocationLists Location { get; set; }

        public RoomsLists Rooms { get; set; }

        public WeeklyEventLists WeeklyEvent { get; set; }

        public WeeklyEventSchedLists WeeklyEventSched { get; set; }

        public string EventName { get; set; }

        public string starttime { get; set; }
    
    }

}