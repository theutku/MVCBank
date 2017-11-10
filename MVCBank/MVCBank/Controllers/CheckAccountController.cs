using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBank.Models;
using Microsoft.AspNet.Identity;
using MVCBank.Services;

namespace MVCBank.Controllers
{
    [Authorize]
    public class CheckAccountController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        private CheckAccount GetUserAccount()
        {
            var currentUserId = User.Identity.GetUserId();
            CheckAccount checkAccount = this.db.CheckAccounts.Where(acc => acc.ApplicationUserId == currentUserId).First();
            return checkAccount;
        }

        //private CheckAccount dummyAccount = new CheckAccount { AccountNumber = "001234", FirstName = "Utku", LastName = "Turkoglu", Balance = 100 };
        // GET: CheckAccount
        public ActionResult Index()
        {
            CheckAccount userCheckAccount = this.GetUserAccount();
            return View(userCheckAccount);
        }

        // GET: CheckAccount/Details
        public ActionResult Details()
        {
            CheckAccount userCheckAccount = this.GetUserAccount();
            return View(userCheckAccount);
        }

        //[Authorize(Roles ="Admin")]
        [CheckIfAdmin]
        public ActionResult DetailsForAdmin(int accountId)
        {
            CheckAccount accountDetail = this.db.CheckAccounts.Find(accountId);
            return View("Details", accountDetail);
        }

        //[Authorize(Roles = "Admin")]
        [CheckIfAdmin]
        public ActionResult List()
        {
            List<CheckAccount> allAccounts = this.db.CheckAccounts.ToList();
            return View(allAccounts);
        }

        // GET: CheckAccount/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CheckAccount/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckAccount/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CheckAccount/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: CheckAccount/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CheckAccount/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        public ActionResult Unauthorized()
        {
            return View("Unauthorized");
        }
    }
}
