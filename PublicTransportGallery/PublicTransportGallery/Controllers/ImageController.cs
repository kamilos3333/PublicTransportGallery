using AutoMapper;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PublicTransportGallery.Data.Domain;
using PublicTransportGallery.Infrastructure;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public ActionResult UploadImage()
        {
            var producentModel = new ImageUploadViewModels();
            producentModel.ProducentList = producentService.getAll();

            return View(producentModel);
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult UploadImage(HttpPostedFileBase Image, ImageUploadViewModels model)
        {
            if (ModelState.IsValid)
            {
                var fileName = ImageManager.InsertImage(Image);

                TblImage image = new TblImage
                {
                    Id = User.Identity.GetUserId(),
                    ModelId = model.ModelId,
                    Name = fileName,
                    DateAdd = DateTime.Now,
                    Description = model.Description
                };
                imageService.Insert(image);
                imageService.Save();
                return RedirectToAction("Index","Home");
            }
            var producentModel = new ImageUploadViewModels();
            producentModel.ProducentList = producentService.getAll();
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
            ImageDetailsViewModels modelDetails = new ImageDetailsViewModels();
            if (modelImage == null)
            {
                return HttpNotFound();
            }
            modelDetails.User = UserManager.FindById(modelImage.Id).UserName;
            Mapper.Map(modelImage, modelDetails);

            var comment = commentService.getAllCommentsByImageId(modelDetails.ImageId);
            List<CommentViewModels> list = new List<CommentViewModels>();

            foreach(var item in comment)
            {
                var model = new CommentViewModels
                {
                    ContentText = item.ContentText,
                    DateAdd = item.DateAdd,
                    Username = UserManager.FindById(item.UserId).UserName,
                    ImageId = item.ImageId
                };
                list.Add(model);
            }

            var viewModels = new MainImageDetailsViewModels
            {
                ImageDetails = modelDetails,
                Comments = list
            };

            return View(viewModels);
        }

        public ActionResult PhotoCollectionUser()
        {
            var imageList = imageService.DetailsUser(User.Identity.GetUserId());
            DetailsUserViewModels model = new DetailsUserViewModels
            {
                ImagesList = imageList
            };

            return View(model);
        }

        public ActionResult EditImage(int id)
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
        public ActionResult EditImage(EditImageViewModels model)
        {
            if (ModelState.IsValid)
            {
                var image = imageService.getImageId(model.ImageId);
                image.Description = model.Description;
                imageService.Save();
                return RedirectToAction("PhotoUser");
            }
            return View(model);
        }

        public ActionResult DeleteImage(int id)
        {
            var image = imageService.getImageId(id);
            imageService.Delete(image);
            imageService.Save();
            return RedirectToAction("PhotoUser");
        }

        [HttpPost]
        [ValidateInput(true)]
        public ActionResult AddComment(string commentContent, int id)
        {
            TblComment comment = new TblComment
            {
                ImageId = id,
                ContentText = commentContent,
                DateAdd = DateTime.Now,
                UserId = User.Identity.GetUserId(),
            };
            commentService.insertComments(comment);
            commentService.Save();

            string message = "SUCCESS";
            return Json(new { Message = message, JsonRequestBehavior.AllowGet });
        }
        
        public JsonResult getModel(int id)
        {
            var model = modelService.getModelJoinProducent(id).ToList();
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