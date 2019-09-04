using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Services.City;
using PublicTransportGallery.ViewModels;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class SearchController : Controller
    {
        private readonly IModelBuilderExecuteRebuild<SearchByModelViewModels> searchByModelBuilder;
        private readonly IModelBuilderExecuteRebuild<SearchByCityViewModels> searchByCityBuilder;
        private readonly ICityService cityService;

        public SearchController(IModelBuilderExecuteRebuild<SearchByModelViewModels> searchByModelBuilder, IModelBuilderExecuteRebuild<SearchByCityViewModels> searchByCityBuilder, ICityService cityService)
        {
            this.searchByModelBuilder = searchByModelBuilder;
            this.searchByCityBuilder = searchByCityBuilder;
            this.cityService = cityService;
        }

        [HttpGet]
        public ActionResult SearchByModel()
        {
            return View(searchByModelBuilder.Rebuild(new SearchByModelViewModels()));
        }

        [HttpPost]
        public ActionResult SearchByModel(SearchByModelViewModels model)
        {
            return View(searchByModelBuilder.Execute(model));
        }

        [HttpGet]
        public ActionResult SearchByCity()
        {
            return View(searchByCityBuilder.Rebuild(new SearchByCityViewModels()));
        }

        [HttpPost]
        public ActionResult SearchByCity(SearchByCityViewModels model)
        {
            return View(searchByCityBuilder.Execute(model));
        }

        public JsonResult GetCity(string woj)
        {
            var model = cityService.GetCityJoinVoivodeship(woj);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}