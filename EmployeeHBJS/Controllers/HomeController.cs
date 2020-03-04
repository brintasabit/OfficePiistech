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

        IEnumerable<EmployeeInfo5> GetAllEmployee()
        {
            using (DBModel dB = new DBModel())
            {
                var employeeList = dB.EmployeeInfo5.ToList<EmployeeInfo5>();
                return employeeList;
            }

        }

        public ActionResult EmployeeHBJS()
        {
            return View();
        }
        public JsonResult HbJs()
        {
            var employeeInfo5 = GetAllEmployee();

            return Json(new {EmployeeInfo5 = employeeInfo5 });
        }
    }
}