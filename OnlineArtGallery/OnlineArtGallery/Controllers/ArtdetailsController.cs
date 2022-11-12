using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using OnlineArtGallery.Models;

namespace OnlineArtGallery.Controllers
{
    public class ArtdetailsController : Controller
    {
        private galleryEntities1 db = new galleryEntities1();

        // GET: Artdetails
        public ActionResult Index()
        {
            return View(db.Artdetails.ToList());
        }

        // GET: Artdetails/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artdetail artdetail = db.Artdetails.Find(id);
            if (artdetail == null)
            {
                return HttpNotFound();
            }
            return View(artdetail);
        }


        // GET: Artdetails/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Artdetail artdetail = db.Artdetails.Find(id);
            if (artdetail == null)
            {
                return HttpNotFound();
            }
            return View(artdetail);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nameart,hidemail,nameartist,descriptionofart,artsize,price,avali,review,img,appstatus")] Artdetail artdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artdetail);
        }

     

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
