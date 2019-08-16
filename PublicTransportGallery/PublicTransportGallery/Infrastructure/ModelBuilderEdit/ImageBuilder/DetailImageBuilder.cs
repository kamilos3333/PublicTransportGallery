using AutoMapper;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder
{
    public class DetailImageBuilder : IModelBuilder<ImageDetailsViewModels>
    {
        private readonly ICommentService commentService;

        public DetailImageBuilder(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public ImageDetailsViewModels Execute(ImageDetailsViewModels model)
        {
            model.CommentList = FillCommentListToModel(model.ImageId);
            model.CommentModel = new CommentInsertViewModels();
            return model;
        }

        private List<CommentListViewModels> FillCommentListToModel(int Id)
        {
            var comment = commentService.getAllCommentsByImageId(Id);
            var list = new List<CommentListViewModels>();
            var modelComment = Mapper.Map(comment, list);
            return modelComment;
        }
    }
}