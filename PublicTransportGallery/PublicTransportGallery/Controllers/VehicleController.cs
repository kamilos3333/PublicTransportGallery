using AutoMapper;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.Model_Builder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.PassengerTransport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.ViewModels
{
    [Authorize(Roles = "Admin")]
    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicleService;
        private readonly IPassengerTransportService passengerTransportService;
        private readonly IModelInsertBuilder<CreateVehicleViewModels> createVehicleModel;
        private readonly IModelInsertBuilder<EditVehiceViewModels> editVehicleModel;
        private readonly IModelCommand<TblVehicle> deleteVehicleModel;

        public VehicleController(IVehicleService vehicleService, IModelInsertBuilder<CreateVehicleViewModels> createVehicleModel, IModelInsertBuilder<EditVehiceViewModels> editVehicleModel, IPassengerTransportService passengerTransportService, IModelCommand<TblVehicle> deleteVehicleModel)
        {
            this.vehicleService = vehicleService;
            this.createVehicleModel = createVehicleModel;
            this.editVehicleModel = editVehicleModel;
            this.passengerTransportService = passengerTransportService;
            this.deleteVehicleModel = deleteVehicleModel;
        }

        // GET: Vehicle
        public ActionResult List()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View(createVehicleModel.Rebuild(new CreateVehicleViewModels()));
        }

        [HttpPost]
        public ActionResult Create(CreateVehicleViewModels model)
        {
            if (ModelState.IsValid)
            {
                createVehicleModel.Execute(model);
                return RedirectToAction("List", "Vehicle");
            }

            return View(createVehicleModel.Rebuild(new CreateVehicleViewModels()));
        }
        
        [HttpGet]
        public ActionResult Edit(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var getVehicle = vehicleService.GetVehicleById(id);
            if (getVehicle == null)
                return HttpNotFound();

            var mapper = Mapper.Map(getVehicle, new EditVehiceViewModels());
            return View(editVehicleModel.Rebuild(mapper));
        }

        [HttpPost]
        public ActionResult Edit(EditVehiceViewModels model)
        {
            if (ModelState.IsValid)
            {
                editVehicleModel.Execute(model);
                return RedirectToAction("List");
            }
            return View(editVehicleModel.Rebuild(model));
        }

        public ActionResult Delete(int id)
        {
            if (id <= 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            var getVehicle = vehicleService.GetVehicleById(id);
            if (getVehicle == null)
                return HttpNotFound();

            deleteVehicleModel.Execute(new TblVehicle(id));
            return Json(JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public ActionResult GetVehicleToList()
        {
            return Json(new { data = vehicleService.GetAllVehicleJson() }, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetVehicleListToDropdownList(int PassengerTransId)
        {
            var model = vehicleService.GetVehicleJoinPassangerTransport(PassengerTransId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }

        [AllowAnonymous]
        public JsonResult GetPassangerTransport(int CityId)
        {
            var model = passengerTransportService.GetPassengerTransportsJoinCity(CityId);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
    }
}