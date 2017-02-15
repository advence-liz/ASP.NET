using System.Web.Mvc;

namespace sharpGUI.Areas.sss
{
    public class sssAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "sss";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapRoute(
                "sss_default",
                "sss/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}