using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBank.Models;

namespace MVCBank.Controllers
{
    public class AccountTypesController : Controller
    {
        // GET: AccountTypes
        public ActionResult Index()
        {
            string[] accountTypes = new AccountTypes().GetAccountTypes();
            ViewBag.AccountTypes = accountTypes;
            return View();
        }
    }
}