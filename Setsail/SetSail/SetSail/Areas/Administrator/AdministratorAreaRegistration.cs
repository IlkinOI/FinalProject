using System.Web.Mvc;

namespace SetSail.Areas.Administrator
{
    public class AdministratorAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Administrator";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "Administrator",
                "Administrator/{controller}/{action}/{id}",
                new { controller = "Home", action = "Login", id = UrlParameter.Optional },
                new[] { "SetSail.Areas.Administrator.Controllers" }
            );
        }
    }
}