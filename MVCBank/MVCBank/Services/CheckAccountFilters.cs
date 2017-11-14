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
    public class AllowOnlyAdmin : ActionFilterAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var controller = filterContext.RouteData.Values["controller"];
            var action = filterContext.RouteData.Values["action"];
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();

            if (!CheckAccountServices.isOfAccountType(currentUserId, AccountTypes.Admin))
            {
                //filterContext.Controller.ViewBag.AccountTitle = AccountTypes.Admin.ToString();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "CheckAccount" }, { "action", "Unauthorized" } });
            }
            base.OnActionExecuting(filterContext);
        }
  
    }

    public class AllowOnlyPrivate: ActionFilterAttribute
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            string currentUserId = HttpContext.Current.User.Identity.GetUserId();
            if (!CheckAccountServices.isOfAccountType(currentUserId, AccountTypes.Private))
            {
                //filterContext.Controller.ViewBag.AccountTitle = AccountTypes.Private.ToString();
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary { { "controller", "CheckAccount" }, { "action", "Unauthorized" } });
            }
            base.OnActionExecuting(filterContext);
        }
    }
}