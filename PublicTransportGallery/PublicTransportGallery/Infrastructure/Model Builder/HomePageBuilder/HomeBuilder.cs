using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Log;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public class HomeBuilder : IModelBuilderExecuteReturnModel<HomeViewModel>
    {
        private readonly IImageService imageService;
        private readonly IModelService modelService;
        private readonly ICommentService commentService;
        private readonly ILogVisitorImageService logVisitorImageService;

        public HomeBuilder(IImageService imageService, IModelService modelService, ICommentService commentService, ILogVisitorImageService logVisitorImageService)
        {
            this.imageService = imageService;
            this.modelService = modelService;
            this.commentService = commentService;
            this.logVisitorImageService = logVisitorImageService;
        }

        public HomeViewModel Execute(HomeViewModel model)
        {
            return new HomeViewModel(model.TypeTransport = modelService.getTypeName(), model.Images = FillImageContentVM());
        }

        public IEnumerable<ImageContentViewModel> FillImageContentVM()
        {
            var fiilList = new List<ImageContentViewModel>();

            foreach(var image in imageService.getAll())
            {
                var newModel = new ImageContentViewModel()
                {
                    ImageId = image.ImageId,
                    PhotoSrc = image.Name,
                    NameProducent = image.TblModel.TblProducent.Name,
                    NameModel = image.TblModel.NameModel,
                    TypeVehicle = image.TblModel.TblTypeTransport.Name,
                    CommentCount = commentService.GetCommentCount(image.ImageId),
                    VisitorCount = logVisitorImageService.CountVisitor(image.ImageId)
                };
                fiilList.Add(newModel);
            }

            return fiilList;
        }
    }
}