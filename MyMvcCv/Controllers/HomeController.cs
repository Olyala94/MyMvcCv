using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyMvcCv.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Test() //"ActionResult" olarak kullanılan mettodlarda <-> geriye bir şey döndürmemiz gerekiyor.
        {
            return View();
        }

        public ActionResult Test2() 
        {
            return View();
        }
    }
}