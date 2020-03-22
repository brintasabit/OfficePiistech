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
        public ActionResult Index(int ?i)
        {
            return View(GetAllEmployee(i));
        }

        IEnumerable<EmployeeInfo5> GetAllEmployee(int ?i)
        {
            using (DBModel dB = new DBModel())
            {
                
                var employeeList = dB.EmployeeInfo5.ToList<EmployeeInfo5>();
                return employeeList.ToPagedList(i ?? 1,10);
            }

        }
        IPagedList GetAllEmployee2(int ?i)
        {
            using (DBModel dB = new DBModel())
            {
                
                var employeeList = dB.EmployeeInfo5.ToList<EmployeeInfo5>();
                return employeeList.ToPagedList(i ?? 1,5);
            }

        }
        public ActionResult EmployeeHBJS(int ?pageNo)
        {
            return View(pageNo);
        }
        public JsonResult HbJs(int ?pageNo)
        {
            var employeeInfo5 = GetAllEmployee(pageNo);
            var e = new {EmployeeInfo5 = employeeInfo5};
            
            return Json(e);
        }
    }
}