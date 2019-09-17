using AutoMapper;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.Model_Builder.Interface;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.Voivodeship;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Infrastructure.Model_Builder.VehicleBuilder
{
    public class CreateVehicleBuilder : IModelInsertBuilder<CreateVehicleViewModels>
    {
        private readonly IProducentService producentService;
        private readonly IVehicleService vehicleService;
        private readonly IVoivodeshipService voivodeshipService;

        public CreateVehicleBuilder(IProducentService producentService, IVehicleService vehicleService, IVoivodeshipService voivodeshipService)
        {
            this.producentService = producentService;
            this.vehicleService = vehicleService;
            this.voivodeshipService = voivodeshipService;
        }

        public void Execute(CreateVehicleViewModels model)
        {
            var modelMapping = Mapper.Map(model, new TblVehicle());
            vehicleService.InsertVehicle(modelMapping);
            vehicleService.Save();
        }

        public CreateVehicleViewModels Rebuild(CreateVehicleViewModels model)
        {
            model.ProducentList = producentService.getAll();
            model.VoivodeshiList = voivodeshipService.GetAllVoivodeships();
            model.YearOfGetList = GetYear();
            model.YearOfRemoveList = GetYear();
            return model;
        }

        private IEnumerable<int> GetYear()
        {
            List<int> years = new List<int>();

            for(int i = DateTime.Now.Year; i >= 1890; i--)
            {
                years.Add(i);
            }

            return years;
        }
    }
}