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
    [HandleError]
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
            var vm = new HomeViewModel(modelService.getTypeName(), imageService.getAll());

            return View(vm);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        [HttpGet]
        public ActionResult Search()
        {
            var searchModel = new SearchViewModels(producentService.getAll(), modelService.getTypeName());
            return View(searchModel);
        }

        [HttpPost]
        public ActionResult Search(SearchViewModels model)
        {
            if (model.ImageList == null)
            {
                var searchModel = new SearchViewModels(producentService.getAll(), modelService.getTypeName(), imageService.SearchImage(model.ProducentId, model.ModelId, model.TypeId));
                return View(searchModel);
            }
            return View();
        }

    }
}