using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqTestEmployee.Controllers
{
    public class LinqController : Controller
    {
        IEnumerable <EmployeeInfo> Data(int pageNo)
        {
            EmployeeInfoDataContext employeeInfoDataContext=new EmployeeInfoDataContext();
            var emp = from x in employeeInfoDataContext.EmployeeInfos select x;
            var index = emp.Skip((pageNo - 1) * 6).Take(6);
            return index;
        }
        public ActionResult LinqIndex()
        {
            return View();
        }

        public JsonResult LinqJson(int ?pageNo)
        {
            
            var employeeInfo = Data(pageNo??1);
            var emp = new {EmployeeInfo = employeeInfo};
            
            return Json(emp);
        }
    }
}