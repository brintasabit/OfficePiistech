using System.Web;
using System.Web.Mvc;

namespace EmployeeHBJs050320
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }
    }
}
