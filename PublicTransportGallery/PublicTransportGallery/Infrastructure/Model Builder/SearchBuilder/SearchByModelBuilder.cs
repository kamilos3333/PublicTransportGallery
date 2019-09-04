using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.Services.ModelVehicle;
using PublicTransportGallery.Services.Producent;
using PublicTransportGallery.Services.Services.Search;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.ModelBuilder.SearchBuilder
{
    public class SearchByModelBuilder : IModelBuilderExecuteRebuild<SearchByModelViewModels>
    {
        private readonly IProducentService producentService;
        private readonly ISearchService searchService;
        private readonly IModelService modelService;

        public SearchByModelBuilder(IProducentService producentService, ISearchService searchService, IModelService modelService)
        {
            this.producentService = producentService;
            this.searchService = searchService;
            this.modelService = modelService;
        }

        public SearchByModelViewModels Execute(SearchByModelViewModels model)
        {
            model.ProducentList = producentService.getAll();
            model.TypeList = modelService.getTypeName();
            model.ImageList = searchService.SearchByModel(model.ProducentId, model.ModelId, model.TypeId);
            return model;
        }

        public SearchByModelViewModels Rebuild(SearchByModelViewModels model)
        {
            model.ProducentList = producentService.getAll();
            model.TypeList = modelService.getTypeName();
            return model;
        }
    }
}