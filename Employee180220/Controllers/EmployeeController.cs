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
                var employeelist = dB.EmployeeInfoes.ToList<EmployeeInfo>();
                return employeelist;
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
        public JsonResult AddOrEdit(EmployeeInfo emp)
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
                var json= Json(new { success = true, Message = "Submitted Successfully!" }, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception e)
            {
                var json= Json(new { success = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
                return json;
            }
        }


        public JsonResult Delete(int id)
        {
            try
            {
                using (DBModel dB = new DBModel())
                {
                    EmployeeInfo emp = dB.EmployeeInfoes.Where(x => x.EmployeeId == id).FirstOrDefault<EmployeeInfo>();
                    dB.EmployeeInfoes.Remove(emp);
                    dB.SaveChanges();
                }
                var json= Json(new { success = true, Message = "Deleted Successfully!" }, JsonRequestBehavior.AllowGet);
                return json;
            }
            catch (Exception e)
            {
                var json= Json(new { success = false, Message = e.Message }, JsonRequestBehavior.AllowGet);
                return json;
            }
        }

        public JsonResult SearchFunc(string SearchBy, string SearchValue)
        {
            using (DBModel dB = new DBModel())
            {
                List<EmployeeInfo>emp=new List<EmployeeInfo>();
                if (SearchBy=="Id")
                {
                    try
                    {
                        int Id = Convert.ToInt32(SearchValue);
                        emp = dB.EmployeeInfoes.Where(x => x.EmployeeId == Id || SearchValue == null).ToList();
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("{0} Is Not A Id ", SearchValue);
                    }
                    return Json(emp, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    emp = dB.EmployeeInfoes.Where(x => x.Name.StartsWith(SearchValue) || SearchValue == null).ToList();
                    return Json(emp, JsonRequestBehavior.AllowGet);
                }
                
            }

        }
    }
}