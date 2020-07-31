using aspnetmvc2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace aspnetmvc2
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            log4net.Config.XmlConfigurator.Configure(new System.IO.FileInfo(Server.MapPath("~/log4net.config.xml")));
            LogHelper.Default.WriteInfo("AppStart");


            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            LogHelper.Default.WriteInfo("AppEnd");
        }

        protected void Application_Error()
        {
            var ex = Server.GetLastError();
            if (ex == null)
            {
                return;
            }
            //log the error!
            LogHelper.Default.WriteError("Application_Error", ex);

            // ÉGÉâÅ[âÊñ ëJà⁄
            var httperror = ex as HttpException;
            Response.StatusCode = httperror.GetHttpCode();
            Response.Redirect("/ja-JP/Error/Index");
            Server.ClearError();

        }
    }
}
