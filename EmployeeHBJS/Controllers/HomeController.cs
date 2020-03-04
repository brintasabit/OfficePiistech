﻿using System;
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

        IEnumerable<EmployeeInfo2> GetAllEmployee()
        {
            using (DBModel dB = new DBModel())
            {
                var employeelist = dB.EmployeeInfo2.ToList<EmployeeInfo2>();
                return employeelist;
            }

        }

        public ActionResult EmployeeHBJS()
        {
            return View();
        }
        public JsonResult HbJs()
        {
            var employeeInfos = GetAllEmployee();

            return Json(new {EmployeeInfoes= employeeInfos });
        }
    }
}