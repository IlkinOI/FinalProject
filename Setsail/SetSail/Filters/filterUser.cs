using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Filters
{
    public class filterUser: ActionFilterAttribute
    {
        //public override void OnActionExecuting(ActionExecutingContext filterContext)
        //{
        //    if (HttpContext.Current.Session["User"] == null)
        //    {
        //        filterContext.Result = new RedirectResult("~/Login/Home");
        //        return;
        //    }
        //    base.OnActionExecuting(filterContext);
        //}
    }
}