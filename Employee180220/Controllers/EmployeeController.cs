using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Employee180220.Models;
using EmployeeTest2PiisTech;

namespace Employee180220.Controllers
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
            return View(GetAllEmployee());
        }
        IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            using (DBModel dB = new DBModel())
            {
                return dB.EmployeeInfoes.ToList<EmployeeInfo>();
            }

        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            EmployeeInfo emp = new EmployeeInfo();
            if (id != 0)
            {
                using (DBModel db = new DBModel())
                {
                    emp = db.EmployeeInfoes.Where(x => x.EmployeeId == id).FirstOrDefault<EmployeeInfo>();
                }
            }

            return View(emp);
        }
        [HttpPost]
        public ActionResult AddOrEdit(EmployeeInfo emp)
        {
            try
            {
                using (DBModel db = new DBModel())
                {
                    if (emp.EmployeeId == 0)
                    {
                        db.EmployeeInfoes.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }
                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Employee", GetAllEmployee()), Message = "Submitted Successfully!" }, JsonRequestBehavior.AllowGet);
            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
            }
        }
    }
}