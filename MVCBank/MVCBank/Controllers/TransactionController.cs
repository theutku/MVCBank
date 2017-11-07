using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using MVCBank.Models;

namespace MVCBank.Controllers
{
    [Authorize]
    public class TransactionController : Controller
    {

        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Transaction
        public ActionResult Index()
        {
            return View();
        }

        // GET: Transaction/Withdraw
        public ActionResult Withdraw()
        {
            return View();
        }

        [HttpPost]
        public ContentResult Withdraw(decimal amount)
        {
            return Content(amount.ToString());
        }

        public ActionResult Deposit(int checkAccountId)
        {
            return View();
        }

        [HttpPost]
        public ActionResult Deposit(Transaction newTransaction)
        {
            if(ModelState.IsValid)
            {
                this.db.Transactions.Add(newTransaction);
                this.db.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            return View();
        }
    }
}