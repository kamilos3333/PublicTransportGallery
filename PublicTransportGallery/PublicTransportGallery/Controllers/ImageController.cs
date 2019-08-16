using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Infrastructure.ModelBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder;
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
        private readonly IProducentService producentService;
        private readonly IModelService modelService;
        private readonly IImageService imageService;
        private readonly ICommentService commentService;
        UploadImageBuilder uploadImageBuilder;
        EditImageBuilder editImageBuilder;
        DeleteImageBuilder deleteImageBuilder;
        DetailImageBuilder detailImageBuilder;
        public ImageController(IImageService _imageService, IProducentService _producentService, ICommentService _commentService, IModelService _modelService)
        {
            this.imageService = _imageService;
            this.producentService = _producentService;
            this.commentService = _commentService;
            this.modelService = _modelService;
            uploadImageBuilder = new UploadImageBuilder(producentService, imageService);
            editImageBuilder = new EditImageBuilder(imageService, producentService, modelService);
            deleteImageBuilder = new DeleteImageBuilder(_imageService);
            detailImageBuilder = new DetailImageBuilder(_commentService);
        }

        // GET: UploadImage
        [Authorize]
        [HttpGet]
        public ActionResult UploadImage()
        {
            return View(uploadImageBuilder.Rebuild(new UploadImageViewModels()));
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult UploadImage(HttpPostedFileBase Image, UploadImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                uploadImageBuilder.Execute(Image, model);
                return RedirectToAction("Index","Home");
            }

            return View(uploadImageBuilder.Rebuild(model));
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
            return View(detailImageBuilder.Execute(mapper));
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
            return View(editImageBuilder.Rebuild(mapper));
        }

        [HttpPost]
        public ActionResult EditImageInfo(HttpPostedFileBase Image, EditImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                editImageBuilder.Execute(Image, model);
                return RedirectToAction("PhotoCollectionUser");
            }
            return View(editImageBuilder.Rebuild(model));
        }

        public ActionResult DeleteImage(int id)
        {
            deleteImageBuilder.Id = id;
            deleteImageBuilder.Execute();
            return RedirectToAction("PhotoCollectionUser");
        }
        
    }
}