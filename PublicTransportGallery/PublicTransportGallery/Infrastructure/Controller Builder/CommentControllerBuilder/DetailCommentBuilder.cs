using AutoMapper;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.Model_Builder.CommentBuilder
{
    public class DetailCommentBuilder : IModelBuilderExecuteReturnModel<CommentViewModels>
    {
        private readonly ICommentService commentService;

        public DetailCommentBuilder(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        public CommentViewModels Execute(CommentViewModels model)
        {
            var list = new List<CommentListViewModels>();
            var comment = commentService.getAllCommentsByImageId(model.ImageId);
            var modelComment = Mapper.Map(comment, list);
            model.CommentList = modelComment;

            return model;
        }
    }
}