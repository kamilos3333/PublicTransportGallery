using AutoMapper;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.PassengerTransport;
using PublicTransportGallery.ViewModels;
using System.Net;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class PassengerTransportController : Controller
    {
        private readonly IPassengerTransportService passengerTransportService;
        private readonly IModelBuilderExecuteReturnModel<PassengerTransportViewModels> DetailsBuilder;

        public PassengerTransportController(IPassengerTransportService passengerTransportService, IModelBuilderExecuteReturnModel<PassengerTransportViewModels> DetailsBuilder)
        {
            this.passengerTransportService = passengerTransportService;
            this.DetailsBuilder = DetailsBuilder;
        }

        public ActionResult Details(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var getPassengerTransport = passengerTransportService.GetPassengerTransportById(id);
            if (getPassengerTransport == null)
                return HttpNotFound();

            var mapper = Mapper.Map(getPassengerTransport, new PassengerTransportViewModels());
            return View(DetailsBuilder.Execute(mapper));
        }
        
    }
}