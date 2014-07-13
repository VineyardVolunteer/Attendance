using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.SqlClient;
using MvcApplication1.Models;

namespace MvcApplication1.BLL
{
    /// <summary>
    /// this holds the odd lists or classes that don't need its own class
    /// </summary>
    public class UtilBLL
    {

        public static LocationLists GetLocations()
        {
            LocationLists locl = new LocationLists();

            DbAccess dblayer = new DbAccess("DBCon");

            DataTable dt = dblayer.BuildSql("GetLocationData");

            foreach (DataRow dr in dt.Rows)
            {
                Location l = new Location();
                l.locationid = Convert.ToInt32(dr[0].ToString());
                l.locationname = dr[1].ToString();
                l.address = dr[2].ToString();
                l.city = dr[3].ToString();
                l.state = dr[4].ToString();
                l.zip = dr[5].ToString();
                locl.Add(l);
            }

            return locl;
        }

        public static RoomsLists GetRooms()
        {
            RoomsLists rml = new RoomsLists();

            DbAccess dblayer = new DbAccess("DBCon");

            DataTable dt = dblayer.BuildSql("GetRoomData");

            foreach (DataRow dr in dt.Rows)
            {
                Rooms r = new Rooms();
                r.roomid = Convert.ToInt32(dr[0].ToString());
                r.roomname = dr[1].ToString();
                r.capacity = Convert.ToInt32(dr[2].ToString());
                rml.Add(r);
            }

            return rml;
        }

        public static WeeklyEventLists GetWeeklyEvents()
        {
            WeeklyEventLists wel = new WeeklyEventLists();

            DbAccess dblayer = new DbAccess("DBCon");

            DataTable dt = dblayer.BuildSql("GetWeeklyEventList");

            foreach (DataRow dr in dt.Rows)
            {
                WeeklyEvent we = new WeeklyEvent();

                we.weid = Convert.ToInt32(dr[0].ToString());
                we.parentgroup = Convert.ToInt32(dr[1].ToString());
                we.starton = Convert.ToDateTime(dr[2].ToString());
                we.endon = Convert.ToDateTime(dr[3].ToString());
                we.eventname = dr[4].ToString();
                wel.Add(we);
            }
            return wel;
        }

        public static WeeklyEventSchedLists GetWeeklyEventScheds()
        {
            WeeklyEventSchedLists wsl = new WeeklyEventSchedLists();

            DbAccess dblayer = new DbAccess("DBCon");

            DataTable dt = dblayer.BuildSql("GetWeeklyEventSchedList");

            foreach (DataRow dr in dt.Rows)
            {
                WeeklyEventSched ws = new WeeklyEventSched();

                ws.wsid = Convert.ToInt32(dr[0].ToString());
                ws.weid = Convert.ToInt32(dr[1].ToString());
                ws.wklyeventname = dr[2].ToString();
                ws.week = Convert.ToInt32(dr[3].ToString());
                ws.day = Convert.ToInt32(dr[4].ToString());
                ws.visibility = Convert.ToInt32(dr[5].ToString());
                ws.starttime = Convert.ToDateTime(dr[6].ToString());
                ws.endtime = Convert.ToDateTime(dr[7].ToString());
                ws.locationid = Convert.ToInt32(dr[8].ToString());
                ws.roomid = Convert.ToInt32(dr[9].ToString());
                wsl.Add(ws);
            }
            return wsl;
        }

    }
}