using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SetSail.Areas.Administrator.Filters
{
    public class filterAdmin : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (HttpContext.Current.Session["Admin"] == null)
            {
                filterContext.Result = new RedirectResult("~/Administrator/Home");
                return;
            }
            base.OnActionExecuting(filterContext);
        }
    }
}