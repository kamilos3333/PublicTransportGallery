using AutoMapper;
using Microsoft.AspNet.Identity;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilder.Interface
{
    public class UploadImageBuilder : IModelBuilder<UploadImageViewModels>
    {
        private readonly IProducentService producentService;
        private readonly IImageService imageService;
        
        public UploadImageBuilder(IProducentService producentService, IImageService imageService)
        {
            this.producentService = producentService;
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
            model.ProducentList = producentService.getAll();
            return model;
        }
    }
}