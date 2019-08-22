using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilder.SearchBuilder
{
    public class SearchBuilder : IModelBuilderExecuteRebuild<SearchViewModels>
    {
        private readonly IProducentService producentService;
        private readonly IImageService imageService;
        private readonly IModelService modelService;

        public SearchBuilder(IProducentService producentService, IImageService imageService, IModelService modelService)
        {
            this.producentService = producentService;
            this.imageService = imageService;
            this.modelService = modelService;
        }

        public SearchViewModels Execute(SearchViewModels model)
        {
            model.ProducentList = producentService.getAll();
            model.TypeList = modelService.getTypeName();
            model.ImageList = imageService.SearchImage(model.ProducentId, model.ModelId, model.TypeId);
            return model;
        }

        public SearchViewModels Rebuild()
        {
            SearchViewModels model = new SearchViewModels
            {
                ProducentList = producentService.getAll(),
                TypeList = modelService.getTypeName(),
            };

            return model;
        }
    }
}