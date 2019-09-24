using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder
{
    public class DeleteImageBuilder : IModelCommand<TblImage>
    {
        private readonly IImageService imageService;

        public DeleteImageBuilder(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public void Execute(TblImage model)
        {
            var getImageFromDatabase = imageService.getImageId(model.ImageId);
            imageService.Delete(getImageFromDatabase);
            imageService.Save();
            DeleteImageFromFolder.DeleteImage(getImageFromDatabase.Name);
        }
    }
}