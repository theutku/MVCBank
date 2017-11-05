using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCBank.Areas.TestArea.Controllers
{

    public class TestController : Controller
    {
        // GET: TestArea/Test 
        public ActionResult Index()
        {
            return Content("ok");
        }
    }
}