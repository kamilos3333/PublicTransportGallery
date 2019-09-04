using PublicTransportGallery.Infrastructure.ModelBuilder.Interface;
using PublicTransportGallery.Services.Services.City;
using PublicTransportGallery.Services.Services.Search;
using PublicTransportGallery.Services.Services.Voivodeship;
using PublicTransportGallery.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.Model_Builder.SearchBuilder
{
    public class SearchByCityBuilder : IModelBuilderExecuteRebuild<SearchByCityViewModels>
    {
        private readonly ISearchService searchService;
        private readonly IVoivodeshipService voivodeshipService;

        public SearchByCityBuilder(ISearchService searchService, IVoivodeshipService voivodeshipService)
        {
            this.searchService = searchService;
            this.voivodeshipService = voivodeshipService;
        }

        public SearchByCityViewModels Execute(SearchByCityViewModels model)
        {
            model.VoivodeshipsList = voivodeshipService.GetAllVoivodeships();
            model.PassengerTransportsList = searchService.SearchByCity(model.CityId);
            return model;
        }

        public SearchByCityViewModels Rebuild(SearchByCityViewModels model)
        {
            model.VoivodeshipsList = voivodeshipService.GetAllVoivodeships();
            return model;
        }
    }
}