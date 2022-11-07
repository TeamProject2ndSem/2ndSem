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
        //Action Method For Login Page
        [HttpPost]
        public ActionResult Login(UserAuthClass model)
        {
           //All Data which will be in UserAuthClass will be displayed in model           
            using (var context = new galleryEntities1())
            {
                //Checking if the email and pass entered is Stored on database
                bool isvaid = context.inibuyers.Any(x => x.email == model.email && x.pass == model.pass);
                if (isvaid)
                {
                    //Storing in tempdata to pass in home controller action result personelde
                    //TempData["name"] = model.email;
                    Session["name"] = model.email;
                    //keeping email for a while
                    FormsAuthentication.SetAuthCookie(model.email, false);
                    return RedirectToAction("Index", "Home");
                }
                //if there is no match with email and password then this will be throw
                ModelState.AddModelError("", "Invalid Email and password");
                return View();
            }

        }
        public ActionResult signup()
        {
            //empty signup
            return View();
        }
        [HttpPost]
        public ActionResult signup(inibuyer model)
        {
            //overloaded signup
            using (var context = new galleryEntities1())
            {
                
                try
                {
                    //it is used to add information in database table inibuyer
                    context.inibuyers.Add(model);
                    context.SaveChanges();
                }
                catch (DbEntityValidationException e)
                {
                    //Exception is used if there will be any type of error
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
            //Make login visible
            return RedirectToAction("Login");
        }

        public ActionResult Logout()
        {
            //session will be ended
            Session.Abandon();
            //Authentication will be signout and every fetched detail will be droped
            FormsAuthentication.SignOut();
            //Make login visible
            return RedirectToAction("Login");
        }
    }
}