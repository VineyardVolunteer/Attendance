using System.Collections.Generic;

namespace Attendance.Web.Models
{
    public class RoomsLists:List<Rooms>
    {
    }

    public class Rooms
    {
        public int roomid { get; set; }

        public string roomname { get; set; }

        public int capacity { get; set; }
    }
}