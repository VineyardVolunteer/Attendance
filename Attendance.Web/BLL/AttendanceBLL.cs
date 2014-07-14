using System;
using System.Data;
using System.Data.SqlClient;
using Attendance.Web.DAL;
using Attendance.Web.Models;

namespace Attendance.Web.BLL
{
    public class AttendanceBLL
    {
        // private static SqlParameter[] SQLParams;
        /// <summary>
        /// get all of attendance info
        /// </summary>
        /// <param name="attendanceid"></param>
        /// <returns></returns>
        

        public static AttendanceList GetEventsofDay(int? locationid, string eventdate)
        {
            DataTable dtResults;
            DbAccess DbLayer = new DbAccess("DBCon");
            // did they pass us anything 
            if (locationid != 0)
            {
                //load up sql paramater
                SqlParameter[] SQLParams = new SqlParameter[]{
                   new SqlParameter("@locationid", locationid), 
                   new SqlParameter("@eventdate", eventdate)
                };
                dtResults = DbLayer.BuildSql("GetEventsofDay", SQLParams);
            }
            else
            {
                dtResults = DbLayer.BuildSql("GetEventsofDay");
            }

            return FillAttendanceClass(dtResults);
        }

        public static void SaveAttendance(Models.Attendance model)
        {
            SqlParameter SQLattendanceid;
            // if the attendance id is null or 0 change the value of the parameter so the stored proc will pick it up
            if (model.attendanceid == 0 || model.attendanceid == null)
            {
                SQLattendanceid = new SqlParameter("@attendanceid", DBNull.Value);
            }
            else
            {
                SQLattendanceid = new SqlParameter("@attendanceid", model.attendanceid);
            }
            //set up the parameters
            SqlParameter[] SQLParams = new SqlParameter[]{
                 SQLattendanceid,
                 new SqlParameter("@attendancedate",model.attendancedate),
                 new SqlParameter("@attendancecount",model.attendancecount),
                 new SqlParameter("@wsid",model.wsid),
                 new SqlParameter("@notes",model.notes)
       };

            //call the proc
            DbAccess dbLayer = new DbAccess("DBCon");
            dbLayer.RunSql("SaveAttendance", SQLParams);

        }
        public static AttendanceList FillAttendanceClass(DataTable dtResults)
        {
            AttendanceList at = new AttendanceList();

            foreach (DataRow dr in dtResults.Rows)
            {
                Models.Attendance a = new Models.Attendance();
                if (dr[3].ToString() != "")
                {
                    a.attendanceid = Convert.ToInt32(dr[3].ToString());
                }
                a.attendancedate = dr["EventDate"].ToString();
                if (dr[2].ToString() != "")
                {
                    a.attendancecount = Convert.ToInt32(dr[2].ToString());
                }
                if (dr[0].ToString() != "")
                {
                    a.wsid = Convert.ToInt32(dr[0].ToString());
                }
                a.notes = dr[5].ToString();
                a.EventName = dr[1].ToString();
                a.starttime = dr[6].ToString();

                at.Add(a);
            }
            return at;
        }

        public static void DeleteAttendance(Models.Attendance model)
        {

            SqlParameter SQLattendanceid;
            // if the attendance id is null or 0 change the value of the parameter so the stored proc will pick it up
            if (model.attendanceid == 0 || model.attendanceid == null)
            {
                SQLattendanceid = new SqlParameter("@attendanceid", DBNull.Value);
            }
            else
            {
                SQLattendanceid = new SqlParameter("@attendanceid", model.attendanceid);
            }
            //set up the parameters
            SqlParameter[] SQLParams = new SqlParameter[]{
                 SQLattendanceid,
                 new SqlParameter("@attendancedate",model.attendancedate)
             };

            //call the proc
            DbAccess dbLayer = new DbAccess("DBCon");
            dbLayer.RunSql("DeleteAttendance", SQLParams);

        }
    }
}