using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Infrastructure.ModelBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class ImageController : Controller
    {
        private readonly IModelBuilderImage<UploadImageViewModels> UploadBuilderImage;
        private readonly IModelCommand<TblImage> DeleteBuilderImage;
        private readonly IModelBuilderImage<EditImageViewModels> EditBuilderImage;
        private readonly IModelBuilderExecuteReturnModel<ImageDetailsViewModels> DetailBuilderImage;
        private readonly IImageService imageService;
        public ImageController(IImageService imageService, IModelBuilderImage<UploadImageViewModels> UploadBuilderImage, IModelCommand<TblImage> DeleteBuilderImage, IModelBuilderImage<EditImageViewModels> EditBuilderImage, IModelBuilderExecuteReturnModel<ImageDetailsViewModels> DetailBuilderImage)
        {
            this.UploadBuilderImage = UploadBuilderImage;
            this.DeleteBuilderImage = DeleteBuilderImage;
            this.EditBuilderImage = EditBuilderImage;
            this.DetailBuilderImage = DetailBuilderImage;
            this.imageService = imageService;
        }

        // GET: UploadImage
        [Authorize]
        [HttpGet]
        public ActionResult UploadImage()
        {
            return View(UploadBuilderImage.Rebuild(new UploadImageViewModels()));
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult UploadImage(HttpPostedFileBase Image, UploadImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                UploadBuilderImage.Execute(Image, model);
                return RedirectToAction("Index","Home");
            }

            return View(UploadBuilderImage.Rebuild(model));
        }

        [OutputCache(Duration = 20)]
        public ActionResult Details(int id)
        {
            if(id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var modelImage = imageService.getImageId(id);
            if (modelImage == null)
                return HttpNotFound();

            var mapper = Mapper.Map(modelImage, new ImageDetailsViewModels());
            return View(DetailBuilderImage.Execute(mapper));
        }
        
        public ActionResult PhotoCollectionUser()
        {
            var model = new DetailsUserViewModels(imageService.DetailsUser(User.Identity.GetUserId()));
            return View(model);
        }

        [HttpGet]
        public ActionResult EditImageInfo(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var image = imageService.getImageId(id);
            if (image == null)
                return HttpNotFound();

            var mapper = Mapper.Map(image, new EditImageViewModels());
            return View(EditBuilderImage.Rebuild(mapper));
        }

        [HttpPost]
        public ActionResult EditImageInfo(HttpPostedFileBase Image, EditImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                EditBuilderImage.Execute(Image, model);
                return RedirectToAction("PhotoCollectionUser");
            }
            return View(EditBuilderImage.Rebuild(model));
        }

        public ActionResult DeleteImage(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var getImage = imageService.getImageId(id);
            if (getImage == null)
                return HttpNotFound();

            DeleteBuilderImage.Execute(new TblImage(id));
            return RedirectToAction("PhotoCollectionUser");
        }
        
    }
}