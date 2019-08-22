using PublicTransportGallery.Infrastructure.ModelBuilder.SearchBuilder;
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
        private readonly IImageService imageService;
        private readonly IModelService modelService;

        public HomeController(IImageService _imageService, IModelService _modelService)
        {
            this.imageService = _imageService;
            this.modelService = _modelService;
        }
        
        public ActionResult Index()
        {
            var vm = new HomeViewModel(modelService.getTypeName(), imageService.getAll());
            return View(vm);
        }
    }
}