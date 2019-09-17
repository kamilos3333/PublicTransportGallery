using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class AdminController : Controller
    {
        private readonly IImageService imageService;

        public AdminController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        // GET: Admin
        [Authorize(Roles = "Admin")]
        public ActionResult ImageList()
        {
            return View();
        }

        //public ActionResult GetImagesToImageList()
        //{
        //    return Json(new { data = imageService.AdminImageList()}, JsonRequestBehavior.AllowGet);
        //}
    }
}