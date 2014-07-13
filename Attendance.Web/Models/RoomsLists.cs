using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
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