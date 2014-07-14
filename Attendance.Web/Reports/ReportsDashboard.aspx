<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReportsDashboard.aspx.cs" Inherits="Attendance.Web.Reports.ReportsDashboard" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <link rel="stylesheet" type="text/css" href="~/Content/Site.css" />
    <meta charset="utf-8" />
        <title>VARI</title>
        <link href="~/favicon.jpg" rel="shortcut icon" type="image/x-icon" />
        <meta name="viewport" content="width=device-width" />
        <% Styles.Render("~/Content/css"); %>
        <% Scripts.Render("~/bundles/modernizr"); %>

      <!--Load the AJAX API-->
<script type="text/javascript" src="https://www.google.com/jsapi"></script>

</head>
<body>
    <header>
            <div class="content-wrapper">
                <div class="float-left">
                    <p class="site-title"><a href="../Home/Index">  </a></p>
                </div>
                             
            </div>
        </header>
        <div id="body">
            <div class="float-aside">
                    <aside>
        <h3>Quick Links</h3>
        <ul>
            <li><a href="../Home/Index">Home</a></li>
            <li><a href="../Home/Reports">Reports</a></li>
            <li><a href="../Home/Contact">Contact</a></li>
        </ul>
    </aside>
                </div>   
            <section class="content-wrapper main-content clear-fix">
      <div style="margin-bottom: 10px; padding: 5px; border: 1px solid gray; background-color: buttonface;">
      <form action="ReportsDashboard.aspx">
        <span> Select time units: </span>
        <select style="font-size: 12px" onchange="changeTimeUnits(this.value)">
          <option value="0">Week</option>
          <option value="1">Quarter</option>
          <option value="2">Year</option>
          <option value="3">Date</option>
          </select>
        </form>
      </div>
    <form id="form1" runat="server">
    <div>
        <asp:Literal ID="lt" runat="server"></asp:Literal>
    </div>  
    <div id="chart_div"></div>      
    </form>
        </section>   
        </div>
    
</body>
</html>
