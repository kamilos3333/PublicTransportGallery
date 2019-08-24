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
    public class SearchController : Controller
    {
        private SearchBuilder searchBuilder;

        public SearchController(IProducentService producentService, IImageService imageService, IModelService modelService)
        {
            searchBuilder = new SearchBuilder(producentService, imageService, modelService);
        }

        [HttpGet]
        public ActionResult SearchByModel()
        {
            return View(searchBuilder.Rebuild(new SearchViewModels()));
        }

        [HttpPost]
        public ActionResult SearchByModel(SearchViewModels model)
        {
            return View(searchBuilder.Execute(model));
        }
    }
}