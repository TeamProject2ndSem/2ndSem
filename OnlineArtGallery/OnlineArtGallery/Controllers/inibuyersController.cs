using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineArtGallery.Models;

namespace OnlineArtGallery.Controllers
{
    //This Controller is for Admin
    public class inibuyersController : Controller
    {
        private galleryEntities1 db = new galleryEntities1();


        // GET: inibuyers
        [Authorize(Roles = "Admin")] //It will display Information of Users Placed in Sign up
        public ActionResult Index()
        {
            var inibuyers = db.inibuyers.Include(i => i.UserRole);
            return View(inibuyers.ToList());
        }

        [Authorize(Roles = "Admin")]
        // GET: inibuyers/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            inibuyer inibuyer = db.inibuyers.Find(id);
            if (inibuyer == null)
            {
                return HttpNotFound();
            }
            return View(inibuyer);
        }

        //Image Will be Posted in Image Table Through EditImage ActionResult
        [HttpGet]
        public ActionResult Editimage()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Editimage(Artdetail imgage)
        {

            //File with capital F is placed seperatly in model of [EF]
            string FileName = Path.GetFileNameWithoutExtension(imgage.File.FileName);//Specify path without extension
            string extension = Path.GetExtension(imgage.File.FileName);//returns Extension
            FileName = FileName + DateTime.Now.ToString("yymmssff") + extension; //Extension with current data
            imgage.img = "~/Image/" + FileName;
            
            FileName = Path.Combine(Server.MapPath("~/Image"), FileName);
            //Full-Path After Combining FileName and Path
            //It will Save All the Values
            imgage.File.SaveAs(FileName);
            using (galleryEntities1 db = new galleryEntities1())
            {
                db.Artdetails.Add(imgage);
                db.SaveChanges();
            }

            ModelState.Clear();


            return View();
        }

      
    }
}
