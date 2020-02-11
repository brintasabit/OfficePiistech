using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeCRUDAjax.Models;

namespace EmployeeCRUDAjax.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewAll()
        {
            return View(GetAllEmployee());
        }

        IEnumerable<Employee> GetAllEmployee()
        {
            using (DbModel dB = new DbModel())
            {
                return dB.Employees.ToList<Employee>();
            }

        }
        [HttpGet]
        public ActionResult AddOrUpdate()
        {

                //Employee employee = new Employee();
                //if (id != null)
                //{
                //    using (DbModel dB = new DbModel())
                //    {
                //        employee = dB.Employees.Where(x => x.EmployeeId == id).FirstOrDefault<Employee>();
                //    }
                //}

            
            return View();
        }
        [HttpPost]
        public ActionResult AddOrEdit(Employee emp)
        {
            try
            {

                //if (emp.ImageUpload != null)
                //{
                //    var fileName = Path.GetFileNameWithoutExtension(emp.ImageUpload.FileName);
                //    var extension = Path.GetExtension(emp.ImageUpload.FileName);
                //    fileName = fileName + DateTime.Now.ToString("yy-MMM-dd ddd") + extension;
                //    emp.ImagePath = "~/AppFiles/ImageFiles/" + fileName;
                //    emp.ImageUpload.SaveAs(Path.Combine(Server.MapPath("~/AppFiles/ImageFiles/"), fileName));
                //}

                using (DbModel db = new DbModel())
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