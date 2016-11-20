using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.Globalization;
using System.Threading;

namespace ICSFrontEndPt2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            //CultureInfo newCulture = (CultureInfo)Thread.CurrentThread.CurrentCulture.Clone();
            //newCulture.DateTimeFormat.ShortDatePattern = "dd/mm/yyyy";
            //newCulture.DateTimeFormat.DateSeparator = "/";
            //newCulture.DateTimeFormat.LongDatePattern = "dd/MM/ yyyy";
            //Thread.CurrentThread.CurrentCulture = newCulture;
        }
    }
}
