using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace SetSail
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
        }

        //protected void Application_Error(object sender, EventArgs e)
        //{
        //    Exception exception = Server.GetLastError();
        //    Response.Clear();

        //    var httpException = exception as HttpException;
        //    if (Request.Url.AbsoluteUri.ToString().Split('/')[3] != "Admin")
        //    {
        //        if (httpException != null)
        //        {
        //            string action;

        //            switch (httpException.GetHttpCode())
        //            {
        //                case 404:
        //                    // page not found
        //                    action = "UserError/404";
        //                    break;
        //                case 403:
        //                    // forbidden
        //                    action = "UserError/403";
        //                    break;
        //                case 500:
        //                    // server error
        //                    action = "UserError/500";
        //                    break;
        //                default:
        //                    action = "UserError/Unknown";
        //                    break;
        //            }

        //            // clear error on server
        //            Server.ClearError();

        //            Response.Redirect(String.Format("~/Error/{0}", action));
        //        }
        //        else
        //        {
        //            // this is my modification, which handles any type of an exception.
        //            Response.Redirect(String.Format("~/Error/Unknown"));
        //        }
        //    }
        //    else
        //    {
        //        if (httpException != null)
        //        {
        //            string action;

        //            switch (httpException.GetHttpCode())
        //            {
        //                case 404:
        //                    // page not found
        //                    action = "AdminError/404";
        //                    break;
        //                case 403:
        //                    // forbidden
        //                    action = "AdminError/404";
        //                    break;
        //                case 500:
        //                    // server error
        //                    action = "AdminError/404";
        //                    break;
        //                default:
        //                    action = "AdminError/404";
        //                    break;
        //            }

        //            // clear error on server
        //            Server.ClearError();

        //            Response.Redirect(String.Format("~/Admin/Errors/{0}", action));
        //        }
        //        else
        //        {
        //            // this is my modification, which handles any type of an exception.
        //            Response.Redirect(String.Format("~/Admin/Errors/Unknown"));
        //        }
        //    }
        //}
    }
}
