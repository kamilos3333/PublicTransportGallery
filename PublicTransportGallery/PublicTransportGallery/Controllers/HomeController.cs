﻿using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class HomeController : Controller
    {
        private IProducentService producentService;
        private IImageService imageService;

        public HomeController(IProducentService _producentService, IImageService _imageService)
        {
            this.imageService = _imageService;
            this.producentService = _producentService;
        }

        [OutputCache(Duration = 60)]
        public ActionResult Index()
        {
            var imagesList = imageService.getAll();

            var vm = new MainViewModel()
            {
                images = imagesList
            };

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Search(SearchViewModels model)
        {
            model.ProducentList = producentService.getAll();

            if (model.ImageList != null)
            {
                var searchResult = imageService.SearchImage(model.ModelId);
                model.ImageList = searchResult;
                return View(model);
            }

            return View(model);
        }
    }
}