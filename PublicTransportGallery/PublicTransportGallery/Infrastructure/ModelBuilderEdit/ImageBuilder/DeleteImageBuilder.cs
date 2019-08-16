using PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder.Interface;
using PublicTransportGallery.Services.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilderEdit.ImageBuilder
{
    public class DeleteImageBuilder : IModelCommand
    {
        private readonly IImageService imageService;

        public DeleteImageBuilder(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public int Id { get; set; }

        public void Execute()
        {
            var getImageFromDatabase = imageService.getImageId(Id);
            imageService.Delete(getImageFromDatabase);
            imageService.Save();
            DeleteImageFromFolder.DeleteImage(getImageFromDatabase.Name);
        }
    }
}