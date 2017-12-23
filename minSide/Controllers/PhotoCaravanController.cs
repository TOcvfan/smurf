﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using minSide.Models;

namespace minSide.Controllers
{
    public class PhotoCaravanController : Controller
    {
        private ISmurfContextPhoto context;

        //Constructors
        public PhotoCaravanController()
        {
            context = new SmurfContext();
        }

        public PhotoCaravanController(ISmurfContextPhoto Context) {
            context = Context;
        }

        // GET: Photo
        public ActionResult Index()
        {
            return View("Index");
        }

        [ChildActionOnly]
        public ActionResult _PhotoGallery(int number = 0)
        {
            List<Photo> photos;

            if (number == 0)
            {
                photos = context.Photos.ToList();
            }
            else
            {
                photos = (from p in context.Photos
                          orderby p.CreatedDate descending
                          select p).Take(number).ToList();
            }

            return PartialView("_PhotoGalleryCaravan", photos);
        }

        [Authorize]
        public ActionResult Create()
        {
            Photo newPhoto = new Photo();
            newPhoto.CreatedDate = DateTime.Today;
            return View("Create", newPhoto);
        }

        [Authorize]
        [HttpPost]
        public ActionResult Create(Photo photo, HttpPostedFileBase image)
        {
            photo.CreatedDate = DateTime.Today;
            if (!ModelState.IsValid)
            {
                return View("Create", photo);
            }
            else
            {
                if (image != null)
                {
                    photo.ImageMimeType = image.ContentType;
                    photo.PhotoFile = new byte[image.ContentLength];
                    image.InputStream.Read(photo.PhotoFile, 0, image.ContentLength);
                }
                context.Add<Photo>(photo);
                context.SaveChanges();
                return RedirectToAction("Index");
            }
        }

        public FileContentResult GetImage(int id)
        {
            Photo photo = context.FindPhotoById(id);
            if (photo != null)
            {
                return File(photo.PhotoFile, photo.ImageMimeType);
            }
            else
            {
                return null;
            }
        }

        public ActionResult SlideShow()
        {
            return View("SlideShow", context.Photos.ToList());
        }
    }
}