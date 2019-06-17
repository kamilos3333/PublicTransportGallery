using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
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
        private IModelService modelService;

        public HomeController(IProducentService _producentService, IImageService _imageService, IModelService _modelService)
        {
            this.imageService = _imageService;
            this.producentService = _producentService;
            this.modelService = _modelService;
        }
        
        public ActionResult Index()
        {
            var imagesList = imageService.getAll();
            var typeList = modelService.getTypeName();

            var vm = new HomeViewModel()
            {
                TypeTransport = typeList,
                Images = imagesList
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

            if (model.ModelId > 0)
            {
                if (ModelState.IsValid)
                {
                    var searchResult = imageService.SearchImage(model.ModelId);
                    model.ImageList = searchResult;
                    return View(model);
                }
                return View(model);
            }

            return View(model);
        }
    }
}