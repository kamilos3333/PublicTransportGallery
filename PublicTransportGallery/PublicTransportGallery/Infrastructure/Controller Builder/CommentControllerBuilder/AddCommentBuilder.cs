using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilderEdit.CommentBuilder
{
    public class AddCommentBuilder
    {
        private readonly ICommentService commentService;

        public AddCommentBuilder(ICommentService _commentService)
        {
            commentService = _commentService;
        }
        
        public void Execute(string CommentContent, int ImageId)
        {
            var comment = new TblComment(HttpContext.Current.User.Identity.GetUserId(), ImageId);
            var mapper = Mapper.Map(FillModel(CommentContent), comment);
            commentService.insertComments(mapper);
            commentService.Save();
        }

        public CommentInsertViewModels FillModel(string CommentContent)
        {
            return new CommentInsertViewModels { ContentText = CommentContent }; 
        }

        
    }
}