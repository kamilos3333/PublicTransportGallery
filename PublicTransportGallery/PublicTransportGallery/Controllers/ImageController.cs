using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System.Collections.Generic;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class ImageController : Controller
    {
        private IProducentService producentService;
        private IModelService modelService;
        private IImageService imageService;
        private ICommentService commentService;

        public ImageController(IImageService _imageService, IProducentService _producentService, IModelService _modelService, ICommentService _commentService)
        {
            this.imageService = _imageService;
            this.modelService = _modelService;
            this.producentService = _producentService;
            this.commentService = _commentService;
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
                
                return RedirectToAction("Index","Home");
            }

            var producentModel = new UploadImageViewModels(producentService.getAll());
            return View(producentModel);
        }

        [OutputCache(Duration = 20)]
        public ActionResult Details(int id)
        {
            if(id <= 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            var modelImage = imageService.getImageId(id);
            if (modelImage == null)
            {
                return HttpNotFound();
            }
            var modelDetails = new ImageDetailsViewModels();
            Mapper.Map(modelImage, modelDetails);

            var comment = commentService.getAllCommentsByImageId(modelDetails.ImageId);
            List<CommentListViewModels> list = new List<CommentListViewModels>();

            foreach(var item in comment)
            {
                var model = new CommentListViewModels(item.ContentText, UserManager.FindById(item.Id).UserName, item.ImageId, item.DateAdd);
                list.Add(model);
            }

            var viewModels = new MainImageDetailsViewModels(modelDetails, list);
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
            var image = imageService.getImageId(id);

            EditImageViewModels model = new EditImageViewModels
            {
                ImageId = image.ImageId,
                Description = image.Description
            };
            return View(model);
        }

        [HttpPost]
        public ActionResult EditImageInfo(EditImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                var image = imageService.getImageId(model.ImageId);
                image.Description = model.Description;
                imageService.Save();
                return RedirectToAction("PhotoCollectionUser");
            }
            return View(model);
        }

        public ActionResult DeleteImage(int id)
        {
            var image = imageService.getImageId(id);
            imageService.Delete(image);
            imageService.Save();
            return RedirectToAction("PhotoCollectionUser");
        }

        [HttpPost]
        [ValidateInput(true)]
        public JsonResult AddComment(string commentContent, int id)
        {
            if (ModelState.IsValid)
            {
                var comment = new TblComment();
                commentService.insertComments(comment);
                commentService.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
        
        public JsonResult getModel(int id)
        {
            var model = modelService.getModelJoinProducent(id);
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