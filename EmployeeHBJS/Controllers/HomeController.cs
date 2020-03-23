using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeHBJS.Models;
using PagedList;
using PagedList.Mvc;

namespace EmployeeHBJS.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int ?pageNo)
        {
            return View(GetAllEmployee(pageNo) as IPagedList<EmployeeInfo5>);
        }

        IEnumerable<EmployeeInfo5> GetAllEmployee(int ?pageNo)
        {
            using (DBModel dB = new DBModel())
            {
                
                var employeeList = dB.EmployeeInfo5.ToList<EmployeeInfo5>();
                var e = employeeList.ToPagedList(pageNo??1,20);
                return e;
            }

        }
        public ActionResult EmployeeHBJS()
        {
            return View();
        }
        public JsonResult HbJs(int? pageNo)
        {
            ;
            var employeeInfo5 = GetAllEmployee(pageNo??1);
            var e = new {EmployeeInfo5 = employeeInfo5};
            
            return Json(e);
        }
    }
}