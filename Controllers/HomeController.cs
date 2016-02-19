using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5CentrexDataProcessor.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Message = "Home Page";

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Centrex Data Processor";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Adam Daum";

            return View();
        }
    }
}
