using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.Comment;
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

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: Comment
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
    }
}