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
        private readonly AddCommentBuilder commentBuilder;
        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
            commentBuilder = new AddCommentBuilder(commentService);
        }
        
        [HttpPost]
        [ValidateInput(true)]
        public JsonResult AddComment(CommentInsertViewModels model/*, int ImageId*/)
        {
            if (ModelState.IsValid)
            {
                ViewBag.Item = model; //to remove
                //commentBuilder.ImageId = ImageId;
                //commentBuilder.CommentContent = getValueContentComment;
                commentBuilder.Execute();
                return Json(JsonRequestBehavior.AllowGet);
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}