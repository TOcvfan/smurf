using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minSide.Models;


namespace minSide.Controllers
{
    public class UserController : Controller
    {
        private ISmurfUserContext context;

        public UserController() {
            context = new SmurfContextBil();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddInfo() {
            return View();
        }

        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddInfo(User userinfo, FormCollection form) {
            
            if (ModelState.IsValid) {

                //context.Add(User.Identity.Name);
                context.Add(userinfo);
                context.SaveChanges();
                return RedirectToAction("Index", "Home");
            }
            else {
                return View();
            }
            
            
        }
    }
}