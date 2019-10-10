using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.ViewModels;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    [HandleError]
    public class HomeController : Controller
    {
        private readonly IModelBuilderExecuteReturnModel<HomeViewModel> HomeBuilderModel;
        public HomeController(IModelBuilderExecuteReturnModel<HomeViewModel> HomeBuilderModel)
        {
            this.HomeBuilderModel = HomeBuilderModel;
        }
        
        public ActionResult Index()
        {
            return View(HomeBuilderModel.Execute(new HomeViewModel()));
        }
    }
}