using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
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
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class ImageController : Controller
    {
        private IImageManager imageManager;
        private ProducentService serviceProd = new ProducentService();
        private ModelService serviceModel = new ModelService();
        private ImageService imageService = new ImageService();

        public ImageController(IImageManager imageManager)
        {
            this.imageManager = imageManager;
        }

        // GET: UploadImage
        [Authorize]
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
                    Id = User.Identity.GetUserId(),
                    ModelId = model.ModelId,
                    Name = fileName,
                    DateAdd = DateTime.Now,
                    Description = model.Description
                };
                imageService.Insert(image);
                return RedirectToAction("Index","Home");
            }
            var producentModel = new ImageUploadViewModels();
            producentModel.ProducentList = serviceProd.getAll();
            return View(producentModel);
        }

        public ActionResult Details(int id)
        {
            if(id == 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var model = imageService.getImageId(id);
            if(model == null)
            {
                return HttpNotFound();
            }
            var user = UserManager.FindById(model.Id).UserName;
            ImageDetailsViewModels viewModels = new ImageDetailsViewModels
            {
                User = user,
                ImageName = model.Name,
                DateAdd = model.DateAdd,
                Producent = model.TblModel.TblProducent.Name,
                Model = model.TblModel.NameModel,
                Description = model.Description,
                YearProduction = model.TblModel.YearProduction,
                YearEndProduction = model.TblModel.YearProductionEnd
            };
            return View(viewModels);
        }

        public JsonResult getModel(int id)
        {
            var model = serviceModel.getModelJoinProducent(id).ToList();
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

    }
}