using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Configuration;

namespace MvcApplication1.Reports
{
    public partial class ReportsDashboard : System.Web.UI.Page
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
        string cmd = "SELECT weeklyeventsched.wklyeventname AS [Event Name], weeklyeventattendance.attendancedate AS Date, weeklyeventattendance.attendancecount AS Count, location.locationname AS Location FROM weeklyeventattendance INNER JOIN weeklyeventsched ON weeklyeventattendance.wsid = weeklyeventsched.wsid INNER JOIN location ON weeklyeventsched.locationid = location.locationid";
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
            str.Append(@"<script type='text/javascript'> google.load('visualization', '1', {'packages':['motionchart']});
                google.setOnLoadCallback(drawChart); function drawChart() { var data = new google.visualization.DataTable();
                data.addColumn('string', 'Event Name');
                data.addColumn('date', 'Date');
                data.addColumn('number', 'Count');
                data.addColumn('string', 'Location');
                data.addRows([");
 
            int count = dt.Rows.Count - 1;
 
            for (int i = 0; i <= count; i++)
            {
               
                if (i == count)
                {
                    str.Append("['" + dt.Rows[i]["wklyeventname"].ToString() + "', new Date (" + dt.Rows[i]["attendancedate"].ToString() + "), " + dt.Rows[i]["attendancecount"].ToString() + ", '" + dt.Rows[i]["locationname"].ToString() + "']");
                }
                else
                {
                    str.Append("['" + dt.Rows[i]["wklyeventname"].ToString() + "', new Date (" + dt.Rows[i]["attendancedate"].ToString() + "), " + dt.Rows[i]["attendancecount"].ToString() + ", '" + dt.Rows[i]["locationname"].ToString() + "'],");
                }
            }
 
            str.Append(" ]);");
            str.Append("  var chart = new google.visualization.MotionChart(document.getElementById('chart_div'));");
            str.Append(" chart.draw(data, {width: 800, height:400}); }");          
            str.Append("</script>");
            lt.Text = str.ToString();
        }
        catch (Exception ex)
        {
        }
    }
}
}