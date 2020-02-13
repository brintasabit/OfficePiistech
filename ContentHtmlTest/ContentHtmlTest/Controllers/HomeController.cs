﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ContentHtmlTest.Models;

namespace ContentHtmlTest.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Dashboard()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }
        IEnumerable<Employee> GetAllEmployee()
        {
            using (DbModels dB = new DbModels())
            {
                return dB.Employees.ToList<Employee>();
            }

        }
        [HttpGet]
        public ActionResult AddOrEdit(int id = 0)
        {
            Employee emp = new Employee();
            if (id != 0)
            {
                using (DbModels db = new DbModels())
                {
                    emp = db.Employees.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                }
            }

            return View(emp);
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            try
            {

                if (emp.ImageUpload != null)
                {
                    var fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                    var extension = Path.GetExtension(emp.ImageUpload.FileName);
                    fileName = fileName + DateTime.Now.ToString("yy-MMM-dd ddd") + extension;
                    emp.ImagePath = "~/AppFiles/ImageFiles/" + fileName;
                    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/ImageFiles/"), fileName));
                }

                using (DbModels db = new DbModels())
                {
                    if (emp.EmployeeId == 0)
                    {
                        db.Employees.Add(emp);
                        db.SaveChanges();
                    }
                    else
                    {
                        db.Entry(emp).State = EntityState.Modified;
                        db.SaveChanges();
                    }

                }


                return Json(new { success = true, html = GlobalClass.RenderRazorViewToString(this, "ViewAll", GetAllEmployee()), Message = "Submitted Successfully!" }, JsonRequestBehavior.AllowGet);

            }
            catch (Exception e)
            {
                return Json(new { success = false, Message = e.Message }, JsonRequestBehavior.AllowGet);


            }
        }

    }
}