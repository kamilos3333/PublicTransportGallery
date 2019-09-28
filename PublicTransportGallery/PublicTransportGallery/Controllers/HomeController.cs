using PublicTransportGallery.Infrastructure.ModelBuilder.SearchBuilder;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
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