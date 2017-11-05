using System.Web.Mvc;

namespace MVCBank.Areas.TestArea
{
    public class TestAreaAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "TestArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            
            context.MapRoute(
                "TestArea_default",
                "TestArea/{controller}/{action}/{id}",
                new { controller = "test", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}