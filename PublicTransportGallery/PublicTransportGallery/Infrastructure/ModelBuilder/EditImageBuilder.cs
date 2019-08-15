using AutoMapper;
using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilder
{
    public class EditImageBuilder : IModelBuilder<EditImageViewModels>
    {
        private readonly IImageService imageService;
        private readonly IProducentService producentService;
        private readonly IModelService modelService;

        public EditImageBuilder(IImageService imageService, IProducentService producentService, IModelService modelService)
        {
            this.imageService = imageService;
            this.producentService = producentService;
            this.modelService = modelService;
        }

        public void Execute(HttpPostedFileBase upload, EditImageViewModels model)
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

        public EditImageViewModels Rebuild(EditImageViewModels model)
        {
            model.ProducentList = producentService.getAll();
            model.ModelList = modelService.getModelJoinProducent(model.ProducentId);
            return model;
        }
    }
}