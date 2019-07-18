using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
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
        public ImageController(IImageService _imageService, IProducentService _producentService, ICommentService _commentService, IModelService _modelService)
        {
            this.imageService = _imageService;
            this.producentService = _producentService;
            this.commentService = _commentService;
            this.modelService = _modelService;
        }

        // GET: UploadImage
        [Authorize]
        [HttpGet]
        public ActionResult UploadImage()
        {
            var producentModel = new UploadImageViewModels(producentService.getAll());
            return View(producentModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult UploadImage(HttpPostedFileBase Image, UploadImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                var fileName = ImageUpload.InsertImage(Image);
                var image = Mapper.Map(model, new TblImage(fileName, User.Identity.GetUserId()));
                imageService.Insert(image);
                imageService.Save();
                ImageThumbnail.Crop(fileName, 340, 255);

                return RedirectToAction("Index","Home");
            }

            var producentModel = new UploadImageViewModels(producentService.getAll());
            return View(producentModel);
        }

        [OutputCache(Duration = 20)]
        public ActionResult Details(int id)
        {
            if(id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var modelImage = imageService.getImageId(id);
            if (modelImage == null)
                return HttpNotFound();

            var modelDetails = new ImageDetailsViewModels();
            Mapper.Map(modelImage, modelDetails);

            var comment = commentService.getAllCommentsByImageId(modelDetails.ImageId);
            List<CommentListViewModels> list = new List<CommentListViewModels>();
            var modelComment = Mapper.Map(comment, list);

            var viewModels = new MainImageDetailsViewModels(modelDetails, modelComment);
            return View(viewModels);
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

            var modelEdit = new EditImageViewModels(producentService.getAll(), modelService.getModelJoinProducent(image.TblModel.ProducentId));
            var model = Mapper.Map(image, modelEdit);

            return View(model);
        }

        [HttpPost]
        public ActionResult EditImageInfo(EditImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                var image = imageService.getImageId(model.ImageId);
                var modelEdit = Mapper.Map(model, image);
                imageService.Update(modelEdit);
                imageService.Save();
                return RedirectToAction("PhotoCollectionUser");
            }
            return View(model);
        }

        public ActionResult DeleteImage(int id)
        {
            imageService.Delete(imageService.getImageId(id));
            imageService.Save();
            return RedirectToAction("PhotoCollectionUser");
        }
        
    }
}