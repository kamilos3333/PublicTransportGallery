using PublicTransportGallery.Data.Domain;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class UploadImageController : Controller
    {
        private IImageManager imageManager;
        private ProducentService serviceProd = new ProducentService();
        private ModelService serviceModel = new ModelService();
        private ImageService imageService = new ImageService();

        public UploadImageController(IImageManager imageManager)
        {
            this.imageManager = imageManager;
        }

        // GET: UploadImage
        public ActionResult UploadImage()
        {
            var producentModel = new ImageUploadViewModels();
            producentModel.ProducentList = serviceProd.getAll();

            return View(producentModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult UploadImage(HttpPostedFileBase Image, ImageUploadViewModels model)
        {
            if (ModelState.IsValid)
            {
                var fileName = imageManager.InsertImage(Image);

                TblImage image = new TblImage
                {
                    ModelId = model.ModelId,
                    Name = fileName,
                    DateAdd = DateTime.Now,
                };
                imageService.Insert(image);
                return RedirectToAction("Index","Home");
            }
            var producentModel = new ImageUploadViewModels();
            producentModel.ProducentList = serviceProd.getAll();
            return View(producentModel);
        }

        public JsonResult getModel(int id)
        {
            var model = serviceModel.getModelJoinProducent(id).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

    }
}