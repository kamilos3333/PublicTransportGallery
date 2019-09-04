using PublicTransportGallery.Data.Model;
using System.Linq;

namespace PublicTransportGallery.Services.Services.Search
{
    public interface ISearchService
    {
        IQueryable<TblImage> SearchByModel(int ProducetnId, int? ModelId, int? TypeId);
        IQueryable<TblPassengerTransport> SearchByCity(int CityId);
    }
}
