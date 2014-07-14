using System.Web.Mvc;
using Attendance.Web.Models;

namespace Attendance.Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "to VARI - Vineyard Attendance Reporting Index!";

            Models.Attendance a = new Models.Attendance();

            a.Location = BLL.UtilBLL.GetLocations();

            return View(a);
        }

        public ActionResult Attendance()
        {
            ViewBag.Message = "Enter Attendance Data...";

            return View();
        }

        public ActionResult Reports()
        {
            ViewBag.Message = "Reporting Options";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Need Help?  Questions?  Suggestions?";

            return View();
        }

        [HttpPost]
        public ActionResult Index(Models.Attendance model = null)
        {
            
            if (model.attendancedate == null)
            {
                ModelState.AddModelError("Date Error", "Please choose a date");

            }
            if (model.locationid == null)
            {
                ModelState.AddModelError("Location Error", "Please choose a location");
            }
            if (ModelState.IsValid)
            {
                //AttendanceList al = BLL.AttendanceBLL.GetEventsofDay(model.locationid, model.attendancedate.ToString());
                return RedirectToAction("Attendance", "home", model);

            }
            else
            {
                model.Location = BLL.UtilBLL.GetLocations();
                return View(model);
            }

            }

        [HttpGet]
        public ActionResult Attendance(Models.Attendance id = null)
        {

            AttendanceList al = new AttendanceList();
            //now lets load this model to pass to the view
            al = BLL.AttendanceBLL.GetEventsofDay(id.locationid, id.attendancedate);

            return View(al);
        }

        // this calls the saveattendance sp
        [HttpPost]
       public ActionResult Attendance(AttendanceList id = null)
        {
            foreach (Models.Attendance a in id)
            {
                AttendanceList alst = new AttendanceList();
                BLL.AttendanceBLL.SaveAttendance(a);
                //save
            }
           return RedirectToAction("Index", "Home");
        }

        // this calls the deleteattendance sp
        [HttpPost]
        public ActionResult DeleteAttendance(AttendanceList id = null)
        {
            //loop through the model and delete
            foreach (Models.Attendance a in id)
            {
                AttendanceList alst = new AttendanceList();
                BLL.AttendanceBLL.DeleteAttendance(a);
                //delete that record
            }

            return RedirectToAction("Index", "Home");
        } 
       
       
    }
}

