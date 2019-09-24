using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services;
using PublicTransportGallery.Services.Services.PassengerTransport;
using PublicTransportGallery.Services.Services.Voivodeship;
using PublicTransportGallery.ViewModels;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilder.Interface
{
    public class UploadImageBuilder : IModelBuilderImage<UploadImageViewModels>
    {
        private readonly IVoivodeshipService voivodeshipService;
        private readonly IImageService imageService;
        
        public UploadImageBuilder(IVoivodeshipService voivodeshipService, IImageService imageService)
        {
            this.voivodeshipService = voivodeshipService;
            this.imageService = imageService;
        }

        public void Execute(HttpPostedFileBase upload, UploadImageViewModels model)
        {
            var fileName = ImageUpload.InsertImage(upload);
            var modelMapping = Mapper.Map(model, new TblImage(fileName, HttpContext.Current.User.Identity.GetUserId()));
            imageService.Insert(modelMapping);
            imageService.Save();
            ImageThumbnail.Crop(fileName, 340, 255);
        }

        public UploadImageViewModels Rebuild(UploadImageViewModels model)
        {
            model.VoivodeshiList = voivodeshipService.GetAllVoivodeships();
            return model;
        }
    }
}