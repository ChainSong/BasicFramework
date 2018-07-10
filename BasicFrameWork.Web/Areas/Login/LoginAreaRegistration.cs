using System.Web.Mvc;

namespace BasicFramework.Web.Areas.Login
{
    public class LoginAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Login";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                   "Login",
                   "Login",
                   new { controller = "Account", action = "Login" }
           );

            context.MapRoute(
                "Login_default",
                "Login/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}