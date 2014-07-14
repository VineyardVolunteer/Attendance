<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportsGrid.aspx.cs" Inherits="Attendance.Web.Reports.ReportsGrid" %>

<%@ Register assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" namespace="System.Web.UI.DataVisualization.Charting" tagprefix="asp" %>
<%@ Register assembly="Microsoft.ReportViewer.WebForms, Version=11.0.0.0, Culture=neutral, PublicKeyToken=89845dcd8080cc91" namespace="Microsoft.Reporting.WebForms" tagprefix="rsweb" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/Site.css" />
    <meta charset="utf-8" />
        <title>VARI</title>
        <link href="~/favicon.jpg" rel="shortcut icon" type="image/x-icon" />
        <meta name="viewport" content="width=device-width" />
        <% Styles.Render("~/Content/css"); %>
        <% Scripts.Render("~/bundles/modernizr"); %>
    <style type="text/css">
        .auto-style1 {
            width: 100%;
        }
        .auto-style2 {
            width: 185px;
        }
    </style>
</head>
<body>
    <header>
            <div class="content-wrapper">
                <div class="float-left">
                    <p class="site-title"><a href="../Home/Index">  </a></p>
                </div>
                <div class="float-right">
                    
                </div>
            </div>
        </header>
        <div id="body">
          
                    <aside>
        <h3>Quick Links</h3>
        <ul>
            <li><a href="../Home/Index">Home</a></li>
            <li><a href="../Home/Reports">Reports</a></li>
            <li><a href="../Home/Contact">Contact</a></li>
        </ul>
    </aside> 
             <section class="content-wrapper main-content clear-fix">
      
        <form id="Form1" name="formAttendanceBasic" runat="server">
        <asp:GridView ID="gvAttendanceBasic" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataSourceID="SqlDataSource1" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" PageSize="52" CellPadding="1" CellSpacing="1" HorizontalAlign="Center">
            <AlternatingRowStyle BackColor="#C80067" ForeColor="Black" BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" />
            <Columns>
                <asp:BoundField DataField="Attendance Date" DataFormatString="{0:d}" HeaderText="Attendance Date" SortExpression="Attendance Date" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="12" >
            
<HeaderStyle Width="12px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Name" HeaderText="Name" SortExpression="Name" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Start Time" HeaderText="Start Time" SortExpression="Start Time" ReadOnly="True" ItemStyle-HorizontalAlign="Center" >
<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Attendance Count" HeaderText="Attendance Count" SortExpression="Attendance Count" ItemStyle-HorizontalAlign="Center" HeaderStyle-Width="12" >
<HeaderStyle Width="12px"></HeaderStyle>

<ItemStyle HorizontalAlign="Center"></ItemStyle>
                </asp:BoundField>
                <asp:BoundField DataField="Notes" HeaderText="Notes" SortExpression="Notes" ItemStyle-HorizontalAlign="Center" ItemStyle-Width="100" >
<ItemStyle HorizontalAlign="Center" Width="100px"></ItemStyle>
                </asp:BoundField>
            </Columns>
            <EditRowStyle BorderColor="#333333" BorderStyle="Solid" BorderWidth="1px" />
            <PagerSettings Mode="NumericFirstLast" />
            <PagerStyle BackColor="#333333" ForeColor="#C80067" HorizontalAlign="Center" />
            <RowStyle BorderColor="#333333" BorderStyle="Dotted" BorderWidth="1px" />
            <SortedAscendingHeaderStyle BackColor="Black" Font-Bold="True" ForeColor="#C80067" />
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:attendancedbConnectionString %>" SelectCommand="SELECT weeklyeventattendance.attendancedate AS [Attendance Date], weeklyeventsched.wklyeventname AS Name, CONVERT (VARCHAR(5), weeklyeventsched.starttime, 108) AS [Start Time], weeklyeventattendance.attendancecount AS [Attendance Count], weeklyeventattendance.notes AS Notes FROM weeklyeventattendance INNER JOIN weeklyeventsched ON weeklyeventattendance.wsid = weeklyeventsched.wsid INNER JOIN location ON weeklyeventsched.locationid = location.locationid ORDER BY [Attendance Date] DESC"></asp:SqlDataSource>
        <br />
            Examples:<br />
            <table class="auto-style1">
                <tr>
                    <td class="auto-style2">4 week average</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">13 week average</td>
                    <td>
                        &nbsp;</td>
                </tr>
                <tr>
                    <td class="auto-style2">52 week average (shows average in 2013 for Middletown)</td>
                    <td>
                        <asp:SqlDataSource ID="SqlDataSource2" runat="server" ConnectionString="<%$ ConnectionStrings:attendancedbConnectionString %>" SelectCommand="SELECT AVG(weeklyeventattendance.attendancecount) AS AverageAttendance FROM location INNER JOIN weeklyeventsched ON location.locationid = weeklyeventsched.locationid INNER JOIN weeklyeventattendance ON weeklyeventsched.wsid = weeklyeventattendance.wsid WHERE (location.locationid = '196') AND (YEAR(weeklyeventattendance.attendancedate) = 2013)"></asp:SqlDataSource>
                        <asp:DetailsView ID="DetailsView1" runat="server" AutoGenerateRows="False" CellPadding="4" DataSourceID="SqlDataSource2" ForeColor="#333333" GridLines="None" Height="50px" Width="125px">
                            <AlternatingRowStyle BackColor="White" />
                            <CommandRowStyle BackColor="#C5BBAF" Font-Bold="True" />
                            <EditRowStyle BackColor="#7C6F57" />
                            <FieldHeaderStyle BackColor="#D0D0D0" Font-Bold="True" />
                            <Fields>
                                <asp:BoundField DataField="AverageAttendance" HeaderText="AverageAttendance" SortExpression="AverageAttendance" ReadOnly="True" />
                            </Fields>
                            <FooterStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <HeaderStyle BackColor="#1C5E55" Font-Bold="True" ForeColor="White" />
                            <PagerStyle BackColor="#666666" ForeColor="White" HorizontalAlign="Center" />
                            <RowStyle BackColor="#E3EAEB" />
                        </asp:DetailsView>
                    </td>
                </tr>
            </table>
            <br />
    </form>
            </section>
        </div>
    
        <footer>
            <div class="content-wrapper">
                <div class="float-left">
                    <p>&copy;  <% DateTime.Now.Year.ToString(); %>  - Vineyard Attendance Reporting Index (VARI)</p>
                </div>
            </div>
        </footer>

    
</body>
</html>
