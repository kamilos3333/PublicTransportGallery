using PublicTransportGallery.Infrastructure.Model_Builder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.PassengerTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.ViewModels
{
    [Authorize(Roles = "Admin")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IPassengerTransportService passengerTransportService;
        private readonly IModelInsertBuilder<CreateVehicleViewModels> vehicleModelBuilder;

        public VehicleController(IVehicleService vehicleService, IModelInsertBuilder<CreateVehicleViewModels> vehicleModelBuilder, IPassengerTransportService passengerTransportService)
        {
            this.vehicleService = vehicleService;
            this.vehicleModelBuilder = vehicleModelBuilder;
            this.passengerTransportService = passengerTransportService;
        }

        // GET: Vehicle
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(vehicleModelBuilder.Rebuild(new CreateVehicleViewModels()));
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleViewModels model)
        {
            if (ModelState.IsValid)
            {
                vehicleModelBuilder.Execute(model);
                return RedirectToAction("List", "Vehicle");
            }

            return View(vehicleModelBuilder.Rebuild(new CreateVehicleViewModels()));
        }

        public ActionResult GetVehicleToList()
        {
            return Json(new { data = vehicleService.GetAllVehicleJson() }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetVehicleListToDropdownList(int PassengerTransId)
        {
            var model = vehicleService.GetVehicleJoinPassangerTransport(PassengerTransId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetPassangerTransport(int CityId)
        {
            var model = passengerTransportService.GetPassengerTransportsJoinCity(CityId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}