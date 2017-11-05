using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBank.Controllers
{

    public class HomeController : Controller
    { 
        public ActionResult Index(int data = 1)
        { 
            ViewBag.PageHeader = "Home" + data;
            return View();
        }
         
    

        public ActionResult Test(string letter)
        {
            string testPhrase = "App Works!";
            if (letter == "lower")
            {
                return Content(testPhrase.ToLower());
            }
            return Content(testPhrase.ToUpper());
        }

        [Route("serial/{letterCase}")]
        public ActionResult Serial(string letterCase)
        {
            Random rnd = new Random();
            int num = rnd.Next(10000, 100000);
            string serial = "MVC" + num.ToString();
            if (letterCase == "lower")
            {
                return Content(serial.ToLower());
            }
            return Content(serial);
        }
        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Please write us using the form below!";

            return View();
        }

        [HttpPost]
        public JsonResult Contact(string clientMessage)
        {
            return Json("Your Message: " + clientMessage,JsonRequestBehavior.AllowGet);
        }
    }
}