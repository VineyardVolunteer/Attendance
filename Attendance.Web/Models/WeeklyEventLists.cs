using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MvcApplication1.Models
{
    public class WeeklyEventLists:List<WeeklyEvent>
    {
    }

    public class WeeklyEvent
    {
        public int weid { get; set; }

        public int parentgroup { get; set; }

        public DateTime starton { get; set; }

        public DateTime endon { get; set; }

        public string eventname { get; set; }

    }
}