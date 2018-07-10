using System.Web.Mvc;

namespace BasicFramework.Web.Areas.Front
{
    public class FrontAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Front";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Front",
                string.Empty,
                new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );

            context.MapRoute(
                    "Home",
                    "Front/Home/Content/{firstMenuID}/{secondMenuID}/{thirdMenuID}",
                    new { controller = "Home", action = "Content", firstMenuID = UrlParameter.Optional, secondMenuID = UrlParameter.Optional, thirdMenuID = UrlParameter.Optional }
            );

            context.MapRoute(
                    "Error",
                    "Error/{msg}",
                    new { controller = "Home", action = "Error", msg = UrlParameter.Optional }
            );

            context.MapRoute(
                "Front_default",
                "Front/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}