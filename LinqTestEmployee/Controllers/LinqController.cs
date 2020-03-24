using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LinqTestEmployee.Controllers
{
    public class LinqController : Controller
    {
        EmployeeInfoDataContext employeeInfoDataContext = new EmployeeInfoDataContext();
        IEnumerable <EmployeeInfo> Data(int pageNo)
        {
            var numberOfData=10;
            var emp = from x in employeeInfoDataContext.EmployeeInfos select x;
            var fetchedData = emp.Count();
            if (fetchedData <= 100)
            {
                numberOfData = Convert.ToInt32((fetchedData / 6) + 1);
            }
            var indexData = emp.Skip((pageNo - 1) * numberOfData).Take(numberOfData);
            return indexData;
            
        }

        public ActionResult LinqIndex()
        {
            return View();
        }

        public JsonResult LinqJson(int ?pageNo)
        {
            var emp = from x in employeeInfoDataContext.EmployeeInfos select x;
            var fetchedDataCount = emp.Count();
            var numberOfData=10;
            if (fetchedDataCount <= 100)
            {
                numberOfData = Convert.ToInt32((fetchedDataCount / 6) + 1);
            }

            var totalPage = Convert.ToInt32((fetchedDataCount / numberOfData) + 1);
            var employeeInfo = Data(pageNo ?? 1);
                var emp2 = new
                {
                    EmployeeInfo = employeeInfo,
                    totalPg = totalPage
                };
                
            
            return Json(emp2);
            
        }
    }
}