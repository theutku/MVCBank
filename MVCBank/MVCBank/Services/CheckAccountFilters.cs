using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MVCBank.Models;
using System.Web.Routing;

namespace MVCBank.Services
{
    public class CheckIfAdmin : ActionFilterAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            var isUserAdmin = this.db.Users.Any(user => user.Id == currentUserId && user.UserRole == "Admin");

            if (!isUserAdmin)
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "CheckAccount" }, { "action", "Unauthorized" } });
            }
            base.OnActionExecuting(filterContext);
        }
  
    }
}