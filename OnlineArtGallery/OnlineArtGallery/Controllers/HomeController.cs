using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using OnlineArtGallery.Models;

namespace OnlineArtGallery.Controllers
{
    [AllowAnonymous]
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

        
        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
        public ActionResult Exhibition()
        {
            return View();
        }
        [Authorize(Roles = "Buyer")]
        public ActionResult Payment()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [Authorize(Roles = "Buyer")]
        [HttpGet]
        public ActionResult PersonalDe()
        {
            try
            {
                string name = Session["name"].ToString();
                using (galleryEntities1 context = new galleryEntities1())
                {
                    var dated = context.inibuyers.Where(x => x.email == name).SingleOrDefault();
                   
                    
                    return View(dated);
                }
            }
            catch
            {
                ViewBag.message = "Error Appeared";
            }
            return View();

        }

    }
}