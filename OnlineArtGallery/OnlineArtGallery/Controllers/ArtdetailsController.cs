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

        //// GET: Artdetails/Create
        //public ActionResult Create()
        //{
        //    return View();
        //}

        //// POST: Artdetails/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public ActionResult Create([Bind(Include = "id,nameart,userrole,nameartist,descriptionofart,artsize,price,avali,review,img,dates,hidemail")] Artdetail artdetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Artdetails.Add(artdetail);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(artdetail);
        //}

        //// GET: Artdetails/Edit/5
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

        // POST: Artdetails/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,nameart,userrole,nameartist,descriptionofart,artsize,price,avali,review,img,dates,hidemail")] Artdetail artdetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(artdetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(artdetail);
        }

        // GET: Artdetails/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: Artdetails/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Artdetail artdetail = db.Artdetails.Find(id);
            db.Artdetails.Remove(artdetail);
            db.SaveChanges();
            return RedirectToAction("Index");
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
