using System;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace Attendance.Web.Reports
{
    public partial class ReportsDLEarly : System.Web.UI.Page
    {
        StringBuilder str = new StringBuilder();
        //Get connection string from web.config

        SqlConnection conn = new SqlConnection("Data Source=KIM-LAPTOP;Initial Catalog=attendancedb;Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack == false)
            {
                BindChart();
            }
        }

        private DataTable GetData()
        {
            DataTable dt = new DataTable();

            string cmd = "SELECT DATEDIFF(d, weeklyeventattendance.attendancedate, GETDATE()) / 7 AS weeks_ago, SUM(weeklyeventattendance.attendancecount) AS [Total Count] FROM weeklyeventattendance INNER JOIN weeklyeventsched ON weeklyeventattendance.wsid = weeklyeventsched.wsid INNER JOIN location ON weeklyeventsched.locationid = location.locationid WHERE (DATEDIFF(d, weeklyeventattendance.attendancedate, GETDATE()) <= 52 * 7) AND (weeklyeventsched.wsid = '140' OR weeklyeventsched.wsid = '142' OR weeklyeventsched.wsid = '143' OR weeklyeventsched.wsid = '144' ) GROUP BY DATEDIFF(d, weeklyeventattendance.attendancedate, GETDATE()) / 7";
            SqlDataAdapter adp = new SqlDataAdapter(cmd, conn);
            adp.Fill(dt);
            return dt;
        }

        private void BindChart()
        {
            DataTable dt = new DataTable();
            try
            {
                dt = GetData();

                str.Append(@"<script type=text/javascript> google.load( *visualization*, *1*, {packages:[*corechart*]});
                       google.setOnLoadCallback(drawChart);
                       function drawChart() {
        var data = new google.visualization.DataTable();
        data.addColumn('string', 'weeks_ago');
        data.addColumn('number', 'Total Count');     
 
        data.addRows(" + dt.Rows.Count + ");");

                for (int i = 0; i <= dt.Rows.Count - 1; i++)
                {
                    str.Append("data.setValue( " + i + "," + 0 + "," + "'" + dt.Rows[i]["weeks_ago"].ToString() + "');");
                    str.Append("data.setValue(" + i + "," + 1 + "," + dt.Rows[i]["Total Count"].ToString() + ") ;");
                }

                str.Append(" var chart = new google.visualization.ColumnChart(document.getElementById('chart_div1'));");
                str.Append(" chart.draw(data, {width: 700, height: 500, title: 'Vineyard Tri-County DiscoveryLand Early Attendance',");
                str.Append("hAxis: {title: 'Date', titleTextStyle: {color: 'black'}}");
                str.Append("}); }");
                str.Append("</script>");
                lt.Text = str.ToString().TrimEnd(',').Replace('*', '"');
            }
            catch
            { }
        }
    }
}

