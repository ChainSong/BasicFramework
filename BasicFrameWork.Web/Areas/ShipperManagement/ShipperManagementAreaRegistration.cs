using System.Web.Mvc;

namespace BasicFramework.Web.Areas.ShipperManagement
{
    public class ShipperManagementAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "ShipperManagement";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "ShipperManagement_default",
                "ShipperManagement/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
