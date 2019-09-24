using AutoMapper;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Image;
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

namespace PublicTransportGallery.Infrastructure.ModelBuilder
{
    public class EditImageBuilder : IModelBuilderImage<ImageEditViewModels>
    {
        private readonly IImageService imageService;
        private readonly IVoivodeshipService voivodeshipService;
        private readonly ICityService cityService;
        private readonly IPassengerTransportService passengerTransportService;
        private readonly IVehicleService vehicleService;

        public EditImageBuilder(IImageService imageService, IVoivodeshipService voivodeshipService, ICityService cityService, IPassengerTransportService passengerTransportService, IVehicleService vehicleService)
        {
            this.imageService = imageService;
            this.voivodeshipService = voivodeshipService;
            this.cityService = cityService;
            this.passengerTransportService = passengerTransportService;
            this.vehicleService = vehicleService;
        }

        public void Execute(HttpPostedFileBase upload, ImageEditViewModels model)
        {
            var image = imageService.getImageId(model.ImageId);
            var fileName = image.Name;
            if(upload != null)
            {
                ImageUpload.EditImage(upload, fileName);
                ImageThumbnail.Crop(fileName, 340, 255);
            }
            var modelMapping = Mapper.Map(model, image);
            imageService.Update(modelMapping);
            imageService.Save();
        }

        public ImageEditViewModels Rebuild(ImageEditViewModels model)
        {
            model.VoivodeshipList = voivodeshipService.GetAllVoivodeships();
            model.CityList = cityService.GetCityJoinVoivodeship(model.WOJ);
            model.PassangerTransportList = passengerTransportService.GetPassengerTransportsJoinCity(model.CityId);
            model.VehicleList = vehicleService.GetVehicleJoinPassangerTransport(model.PassengerTransId);
            return model;
        }
    }
}