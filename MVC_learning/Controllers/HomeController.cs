using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC_learning.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewData["countries"] = new List<string>()
            {

                "Pakistan",
                "Turkey",
                "China",
                "Iran"

            };


            return View();
        }

    }
}