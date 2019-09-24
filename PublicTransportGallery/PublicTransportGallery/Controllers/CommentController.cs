using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.CommentBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Comment;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class CommentController : Controller
    {
        private readonly ICommentService commentService;
        private readonly AddCommentBuilder commentBuilder;
        private readonly IModelBuilderExecuteReturnModel<CommentViewModels> detailCommentBuilder;
        public CommentController(ICommentService commentService, IModelBuilderExecuteReturnModel<CommentViewModels> detailCommentBuilder)
        {
            this.commentService = commentService;
            this.detailCommentBuilder = detailCommentBuilder;
            commentBuilder = new AddCommentBuilder(commentService);
        }
        
        public ActionResult _CommentSection(int ImageId)
        {
            return PartialView("_CommentSection", detailCommentBuilder.Execute(new CommentViewModels(ImageId)));
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

        public ActionResult DeleteComment(int CommentId)
        {
            if (CommentId <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var getComment = commentService.GetCommentById(CommentId);
            if (getComment == null)
                return HttpNotFound();

            commentService.deleteComments(getComment);
            commentService.Save();
            return Json(JsonRequestBehavior.AllowGet);
        }
        
    }
}