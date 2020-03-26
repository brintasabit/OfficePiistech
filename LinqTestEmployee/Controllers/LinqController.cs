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
            var emp = from x in employeeInfoDataContext.EmployeeInfos select x;
            var fetchedDataCount = emp.Count();
            var numberOfData = fetchedDataCount >= 21 ? Convert.ToInt32((fetchedDataCount / 1000)) : 20;
            //var totalPageCount = Convert.ToInt32((fetchedDataCount / numberOfData));
            var index = emp.Skip((pageNo - 1) * numberOfData).Take(numberOfData);
            return index;
        }
        public ActionResult LinqIndex()
        {
            return View();
        }
        public JsonResult LinqJson(int ?pageNo)
        {
            var emp = from x in employeeInfoDataContext.EmployeeInfos select x;
            var fetchedDataCount = emp.Count();
            var numberOfData = fetchedDataCount >= 21 ? Convert.ToInt32((fetchedDataCount / 1000)) : 20;
            var totalPageCount = Convert.ToInt32((fetchedDataCount / numberOfData) + 1);
            var indexData = Data(pageNo ?? 1);
            var empData = new
            {
                EmployeeInfo = indexData,
                totalPage = totalPageCount,
                fetchData = fetchedDataCount,
                numberOfDataPerPage = numberOfData
            };
            return Json(empData);

        }
    }
}