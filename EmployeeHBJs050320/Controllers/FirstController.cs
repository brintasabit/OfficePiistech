using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeHBJs050320.Models;

namespace EmployeeHBJs050320.Controllers
{
    public class FirstController : Controller
    {

        IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            using (DBModel dB = new DBModel())
            {
                var employeeList = dB.EmployeeInfoes.ToList<EmployeeInfo>();
                return employeeList;
            }

        }

        public ActionResult Hbjs()
        {
            return View();
        }
        public JsonResult HbJsController()
        {
            var employeeInfo6 = GetAllEmployee();
            
            var response =
                new
                {
                    EmployeeInfo = employeeInfo6,
                    
                };

            return Json(response, JsonRequestBehavior.AllowGet);
        }

    }
}