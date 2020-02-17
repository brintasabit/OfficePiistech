using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Employee170220.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult Employee()
        {
            return View();
        }
        public ActionResult AddOrEdit()
        {
            return View();
        }
    }
}