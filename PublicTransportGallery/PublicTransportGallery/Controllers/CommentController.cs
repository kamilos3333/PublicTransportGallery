﻿using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
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

        public CommentController(ICommentService commentService)
        {
            this.commentService = commentService;
        }

        // GET: Comment
        [HttpPost]
        [ValidateInput(true)]
        public ActionResult AddComment(CommentInsertViewModels model)
        {
            if (ModelState.IsValid)
            {
                var comment = new TblComment(User.Identity.GetUserId());
                var mapper = Mapper.Map(model, comment);
                commentService.insertComments(mapper);
                commentService.Save();
            }

            return Json(JsonRequestBehavior.AllowGet);
        }
    }
}