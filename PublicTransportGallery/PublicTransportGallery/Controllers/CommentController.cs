using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.CommentBuilder;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private AddCommentBuilder commentBuilder;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
            commentBuilder = new AddCommentBuilder(commentService);
        }
        
        [HttpPost]
        [ValidateInput(true)]
        public JsonResult AddComment(string getValueContentComment, int ImageId)
        {
            if (ModelState.IsValid)
            {
                commentBuilder.Execute(getValueContentComment, ImageId);
                return Json(JsonRequestBehavior.AllowGet);
            }

            return Json(JsonRequestBehavior.AllowGet);
        }

        public int GetCountComments(int id)
        {
            return commentService.GetCommentCount(id);
        }

    }
}