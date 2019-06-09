using PublicTransportGallery.Services.Image;
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
        private ProducentService producentService = new ProducentService();
        private ImageService imageService = new ImageService();
        
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

        public ActionResult SearchVehice()
        {
            var model = new SearchViewModel();
            model.ProducentsList = producentService.getAll();
            return View(model);
        }

        [HttpPost]
        public ActionResult SearchResult(SearchViewModel model)
        {
            var imageModel = imageService.SearchImage(model.ModelId);

            return View();
        }
    }
}