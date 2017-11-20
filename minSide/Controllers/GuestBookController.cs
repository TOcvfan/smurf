using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minSide.Models;

namespace minSide.Controllers
{
    public class GuestBookController : Controller
    {
        private ISmurfGuestBookContext context;

        public GuestBookController() {
            context = new SmurfContext();
        }
        
        
        // GET: GuestBook
        public ActionResult Index()
        {
            var entries = from gb in context.GuestBookNotes
                          orderby gb.CreatedDate descending
                          select gb;

            return View(entries.ToList());
        }
        // GET:/Guestbook/AddEntry
        public ActionResult AddEntry() {
            return View();
        }

        [Authorize]
        [HttpPost]
        public ActionResult AddEntry(GuestBook guest, FormCollection formCollection) {
            if (!formCollection["FormEntryBotWatch"].Equals("JS-GOT-ME")) {
                ModelState.AddModelError("", "The controller thinks you are a bot, please wait for message to say it is safe to submit entry (30 Seconds)");
            } else {
                if (ModelState.IsValid) {
                    guest.CreatedDate = DateTime.Now;

                    context.Add(guest);
                    return RedirectToAction("Index", "GuestBook");
                }
            }
            return View();
        }
    }
}