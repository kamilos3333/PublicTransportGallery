using AutoMapper;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.Model_Builder.Interface;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.City;
using PublicTransportGallery.Services.Services.PassengerTransport;
using PublicTransportGallery.Services.Services.Voivodeship;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.Model_Builder.VehicleBuilder
{
    public class EditVehicleBuilder : IModelInsertBuilder<EditVehiceViewModels>
    {
        private readonly IProducentService producentService;
        private readonly IModelService modelService;
        private readonly IVehicleService vehicleService;
        private readonly IVoivodeshipService voivodeshipService;
        private readonly ICityService cityService;
        private readonly IPassengerTransportService passengerTransportService;

        public EditVehicleBuilder(IProducentService producentService, IVehicleService vehicleService, IVoivodeshipService voivodeshipService, IModelService modelService, ICityService cityService, IPassengerTransportService passengerTransportService)
        {
            this.producentService = producentService;
            this.vehicleService = vehicleService;
            this.voivodeshipService = voivodeshipService;
            this.modelService = modelService;
            this.cityService = cityService;
            this.passengerTransportService = passengerTransportService;
        }

        public void Execute(EditVehiceViewModels model)
        {
            var mapper = Mapper.Map(model, new TblVehicle());
            vehicleService.Update(mapper);
            vehicleService.Save();
        }

        public EditVehiceViewModels Rebuild(EditVehiceViewModels model)
        {
            model.ProducentList = producentService.getAll();
            model.ModelList = modelService.getModelJoinProducent(model.ProducentId);
            model.VoivodeshipList = voivodeshipService.GetAllVoivodeships();
            model.CityList = cityService.GetCityJoinVoivodeship(model.WOJ);
            model.PassangerTranspotList = passengerTransportService.GetPassengerTransportsJoinCity(model.CityId);
            model.YearOfGetList = DropDownListYear.GetYear();
            model.YearOfRemoveList = DropDownListYear.GetYear();
            return model;
        }
    }
}