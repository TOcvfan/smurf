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
            context = new SmurfContext();
        }
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult AddInfo() {
            return View();
        }

        public ActionResult AddInfo(User userinfo, FormCollection form) {
            if (!form["FormEntryBotWatch"].Equals("CMH-IS-COOL")) {
                ModelState.AddModelError("", "The controller thinks you are a bot, please wait for message to say it is safe to submit entry (30 Seconds)");
            } else {
                if (ModelState.IsValid) {

                    context.Add(userinfo);
                    context.SaveChanges();
                    return RedirectToAction("Index", "Home");
                }
            }
            return View();
        }
    }
}