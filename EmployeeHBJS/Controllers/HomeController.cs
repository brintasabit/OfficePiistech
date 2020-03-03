using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeHBJS.Models;

namespace EmployeeHBJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            using (DBModel dB = new DBModel())
            {
                var employeelist = dB.EmployeeInfoes.ToList<EmployeeInfo>();
                return employeelist;
            }

        }

        public ActionResult EmployeeHBJS()
        {
            return View();
        }
        public JsonResult HbJs()
        {
            return Json(new {EmployeeInfoes=GetAllEmployee()});
        }
    }
}