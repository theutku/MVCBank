using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCBank.Models;

namespace MVCBank.Controllers
{
    public class CheckAccountController : Controller
    {
        CheckAccount dummyAccount = new CheckAccount { AccountNumber = "001234", FirstName = "Utku", LastName = "Turkoglu", Balance = 100 };
        // GET: CheckAccount
        public ActionResult Index()
        {
            return View(this.dummyAccount);
        }

        // GET: CheckAccount/Details
        public ActionResult Details()
        {
            return View(this.dummyAccount);
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
    }
}
