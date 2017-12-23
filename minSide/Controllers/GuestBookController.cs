using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minSide.Models;
using PagedList;

namespace minSide.Controllers
{
    public class GuestBookController : Controller
    {
        private ISmurfGuestBookContext context;

        public GuestBookController() {
            context = new SmurfContext();
        }

        //public ActionResult Index()
        //{
        //    return View("Guestbook");
        //}

        public ActionResult Index(int page = 1, int pageSize = 100)
        {
            var notes = context.GuestBookNotes.OrderByDescending(g => g.CreatedDate).ToList();
            var model = new PagedList<GuestBook>(notes, page, pageSize);

            return View(model);
        }

        //This attribute means the action cannot be accessed from the browser's address bar
        
        /*public PartialViewResult _CommentsForGuestbook()
        {
            //The comments for a particular photo have been requested. Get those comments.
            var comments = from c in context.GuestBookNotes
                           orderby c.CreatedDate descending
                           select c;
            //Save the PhotoID in the ViewBag because we'll need it in the view
            
            return PartialView(comments.ToList());
        }

        //
        //POST: This action creates the comment when the AJAX comment create tool is used
        [HttpPost]
        public PartialViewResult _CommentsForGuestbook(GuestBook GB)
        {

            //Save the new comment
            context.Add<GuestBook>(GB);
            context.SaveChanges();

            //Get the updated list of comments
            var comments = from c in context.GuestBookNotes
                           orderby c.CreatedDate descending
                           select c;
            //Save the PhotoID in the ViewBag because we'll need it in the view
            
            //Return the view with the new list of comments
            return PartialView("_CommentsForGuestbook", comments.ToList());
        }*/

        public ActionResult Create()
        {
            return View();
        }
        //
        // GET: /Comment/_Create. A Partial View for displaying the create comment tool as a AJAX partial page update
        [Authorize]
        [HttpPost]
        public ActionResult Create(GuestBook message)
        {
            //Create the new comment
            if (ModelState.IsValid)
            {
                message.CreatedDate = DateTime.Now;
                context.Add(message);
                context.SaveChanges();
                return RedirectToAction("");
            }
            return View();
        }
    }
}