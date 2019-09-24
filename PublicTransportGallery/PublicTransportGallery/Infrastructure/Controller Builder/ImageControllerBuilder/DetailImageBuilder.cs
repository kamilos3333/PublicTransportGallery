using AutoMapper;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.Services.Log;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder
{
    public class DetailImageBuilder : IModelBuilderExecuteReturnModel<ImageDetailsViewModels>
    {
        private readonly ICommentService commentService;
        private readonly ILogVisitorImageService logVisitorImageService;

        public DetailImageBuilder(ICommentService commentService, ILogVisitorImageService logVisitorImageService)
        {
            this.commentService = commentService;
            this.logVisitorImageService = logVisitorImageService;
        }

        public ImageDetailsViewModels Execute(ImageDetailsViewModels model)
        {
            model.CountComment = commentService.GetCommentCount(model.ImageId);
            model.CountVisitor = logVisitorImageService.CountVisitor(model.ImageId);
            RegisterVisitor(model.ImageId);
            return model;
        }

        private void RegisterVisitor(int id)
        {
            TblLogVisitorImage logVisitor = new TblLogVisitorImage()
            {
                ImageId = id,
                DateVisit = DateTime.Now
            };
            logVisitorImageService.Insert(logVisitor);
        }
    }
}