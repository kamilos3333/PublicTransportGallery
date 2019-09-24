using AutoMapper;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.PassengerTransport;
using PublicTransportGallery.ViewModels;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportGallery.Infrastructure.Model_Builder.PassengerTransportBuilder
{
    public class DetailsBuilder : IModelBuilderExecuteReturnModel<PassengerTransportViewModels>
    {
        private readonly IPassengerTransportService passengerTransportService;
        private readonly IVehicleService vehicleService;
        private readonly IImageService imageService;

        public DetailsBuilder(IPassengerTransportService passengerTransportService, IVehicleService vehicleService, IImageService imageService)
        {
            this.passengerTransportService = passengerTransportService;
            this.vehicleService = vehicleService;
            this.imageService = imageService;
        }

        public PassengerTransportViewModels Execute(PassengerTransportViewModels model)
        {
            model.VehicleHistory = vehicleService.GetItemHistoryVehicle(model.PassengerTransId);
            model.VehicleType = vehicleService.GetItemVehicleType(model.PassengerTransId);
            model.VehicleList = FillModel(vehicleService.GetAllVehicleById(model.PassengerTransId));
            return model;
        }

        private IList<VehicleListViewModels> FillModel(IList<TblVehicle> list)
        {
            var mapper = Mapper.Map(list, new List<VehicleListViewModels>());
            foreach (var item in mapper)
            {
                item.Photo = imageService.GetRandomImage(item.VehicleId);
            }

            return mapper;
        }
    }
}