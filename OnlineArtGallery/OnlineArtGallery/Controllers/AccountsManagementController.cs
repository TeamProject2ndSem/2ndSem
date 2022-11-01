using OnlineArtGallery.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace OnlineArtGallery.Controllers
{
    public class AccountsManagementController : Controller
    {
        // GET: AccountsManagement
        public ActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Login(UserAuthClass model)
        {
           
            using (var context = new galleryEntities1())
            {
                bool isvaid = context.inibuyers.Any(x => x.email == model.email && x.pass == model.pass);
                if (isvaid)
                {
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Invalid username and password");
                return View();
            }

        }
        public ActionResult signup()
        {
            return View();
        }
        [HttpPost]
        public ActionResult signup(inibuyer model)
        {
            using (var context = new galleryEntities1())
            {
                
                try
                {
                    context.inibuyers.Add(model);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    foreach (var eve in e.EntityValidationErrors)
                    {
                        Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                            eve.Entry.Entity.GetType().Name, eve.Entry.State);
                        foreach (var ve in eve.ValidationErrors)
                        {
                            Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                ve.PropertyName, ve.ErrorMessage);
                        }
                    }
                    throw;
                }
            }
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();
            return RedirectToAction("Login");
        }
    }
}