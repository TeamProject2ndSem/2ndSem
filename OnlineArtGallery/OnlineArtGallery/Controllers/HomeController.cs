using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace OnlineArtGallery.Controllers
{
    //[Authorize]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

       

        public ActionResult Journey()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult visionnMission()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult PrivacynPolicy()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Payment()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Exhibition()
        {
            return View();
        }
        public ActionResult PersonalDe()
        {
            return View();
        }
    }
}