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
        public ActionResult DeleteEmployee()
        {
            return View(GetAllEmployee());
        }
        public ActionResult EditEmployee()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<EmployeeInfo> GetAllEmployee()
        {
            using (DBModel dB = new DBModel())
            {
                var employeelsit = dB.EmployeeInfoes.ToList<EmployeeInfo>();
                return employeelsit;
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
                    emp = db.EmployeeInfoes.Where(x => x.EmployeeId == id).First<EmployeeInfo>();
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
                var json= Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "EmployeeInfo", GetAllEmployee()), Message = "Submitted Successfully!" }, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception e)
            {
                var json= Json(new { success = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
                return json;
            }
        }


        public ActionResult Delete(int id)
        {
            try
            {
                using (DBModel dB = new DBModel())
                {
                    EmployeeInfo emp = dB.EmployeeInfoes.Where(x => x.EmployeeId == id).FirstOrDefault<EmployeeInfo>();
                    dB.EmployeeInfoes.Remove(emp);
                    dB.SaveChanges();
                }
                var json= Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "Employee", GetAllEmployee()), Message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception e)
            {
                var json= Json(new { success = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
                return json;
            }
        }
    }
}