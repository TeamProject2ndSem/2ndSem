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
        public ActionResult Index()
        {
            var inibuyers = db.inibuyers.Include(i => i.UserRole);
            return View(inibuyers.ToList());
        }

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

        // GET: inibuyers/Create
        public ActionResult Create()
        {
            ViewBag.users = new SelectList(db.UserRoles, "role", "role");
            return View();
        }

        // POST: inibuyers/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "id,users,fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass,verifyed")] inibuyer inibuyer)
        {
            if (ModelState.IsValid)
            {
                db.inibuyers.Add(inibuyer);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.users = new SelectList(db.UserRoles, "role", "role", inibuyer.users);
            return View(inibuyer);
        }

        // GET: inibuyers/Edit/5
        public ActionResult Edit(int? id)
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
            ViewBag.users = new SelectList(db.UserRoles, "role", "role", inibuyer.users);
            return View(inibuyer);
        }

        // POST: inibuyers/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,users,fname,lname,email,contacto,contactt,adress,region,city,country,pcode,gender,pass,verifyed")] inibuyer inibuyer)
        {
            if (ModelState.IsValid)
            {
                db.Entry(inibuyer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.users = new SelectList(db.UserRoles, "role", "role", inibuyer.users);
            return View(inibuyer);
        }

        // GET: inibuyers/Delete/5
        public ActionResult Delete(int? id)
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

        // POST: inibuyers/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            inibuyer inibuyer = db.inibuyers.Find(id);
            db.inibuyers.Remove(inibuyer);
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
                ////session name for email:
                //string name = Session["name"].ToString();
                //var dated = db.inibuyers.Where(x => x.email == name).SingleOrDefault();
                //string users =Session["users"].ToString();
                db.Artdetails.Add(imgage);
                db.SaveChanges();
            }

            ModelState.Clear();


            //string name = Session["name"].ToString();
            //using (galleryEntities1 context = new galleryEntities1())
            //{
            //    var dated = context.inibuyers.Where(x => x.email == name).SingleOrDefault();
            //    return View(dated);
            //}
            return View();
        }

        [HttpGet]
        public ActionResult EditimageView(int id)
        {
            Artdetail imgage = new Artdetail();
            using (galleryEntities1 db = new galleryEntities1())
            {
                imgage = db.Artdetails.Where(x => x.id == id).FirstOrDefault();

            }
            return View(imgage);
        }
    }
}
