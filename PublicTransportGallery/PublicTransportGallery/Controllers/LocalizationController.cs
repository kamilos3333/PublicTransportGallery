using PagedList;
using PublicTransportGallery.Services.Services.City;
using PublicTransportGallery.Services.Services.PassengerTransport;
using PublicTransportGallery.Services.Services.Voivodeship;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class LocalizationController : Controller
    {
        private readonly IVoivodeshipService voivodeshipService;
        private readonly ICityService cityService;
        private readonly IPassengerTransportService passengerTransportService;

        public LocalizationController(IVoivodeshipService voivodeshipService, ICityService cityService, IPassengerTransportService passengerTransportService)
        {
            this.voivodeshipService = voivodeshipService;
            this.cityService = cityService;
            this.passengerTransportService = passengerTransportService;
        }

        public ActionResult VoivodeshipList()
        {
            return View(voivodeshipService.GetAllVoivodeships());
        }

        // GET: Localization
        [HttpGet]
        public ActionResult CityList(string WOJ, int? page)
        {
            var pageNumber = page ?? 1;
            var pageSize = 30;
            var model = cityService.GetCitiesByVoivodeship(WOJ).ToPagedList(pageNumber, pageSize);
            return View(model);
        }

        [HttpGet]
        public ActionResult PassengerTransportList(string City)
        {
            var model = passengerTransportService.GetPassengerTransportsByCity(City);
            return View(model);
        }

    }
}