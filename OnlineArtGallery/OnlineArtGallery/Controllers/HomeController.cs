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
        private galleryEntities1 db = new galleryEntities1();

        public ActionResult Index()
        {
            return View();

        }

        public ActionResult Journey()
        {

            return View();
        }
        public ActionResult visionnMission()
        {

            return View();
        }
        public ActionResult PrivacynPolicy()
        {

            return View();
        }

        
        public ActionResult Contact()
        {

            return View();
        }
        public ActionResult ArtInSale()
        {
            return View(db.Artdetails.ToList());
        }
        [Authorize(Roles = "Buyer")]
        public ActionResult Payment()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        [Authorize(Roles = "Buyer")]
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