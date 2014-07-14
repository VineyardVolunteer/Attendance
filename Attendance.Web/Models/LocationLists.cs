using System.Collections.Generic;

namespace Attendance.Web.Models
{
    public class LocationLists : List<Location>
    {
    }
    public class Location
    {
        public int locationid { get; set; }

        public string locationname { get; set; }

        public string address { get; set; }

        public string city { get; set; }

        public string state { get; set; }

        public string zip { get; set; }
    }
}