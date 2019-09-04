using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using System.Data.Entity;
using System.Linq;

namespace PublicTransportGallery.Services.Services.Search
{
    public class SearchService : ISearchService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public IQueryable<TblPassengerTransport> SearchByCity(int CityId)
        {
            var result = db.TblPassengerTransports.Where(a => a.CityId == CityId).AsQueryable();
            return result;
        }

        public IQueryable<TblImage> SearchByModel(int ProducetnId, int? ModelId, int? TypeId)
        {
            var result = db.TblImages.Include(x => x.TblModel).Include(x => x.TblModel.TblProducent).OrderByDescending(a => a.DateAdd).AsQueryable();

            if (ModelId > 0)
            {
                result = result.Where(a => a.ModelId == ModelId);
            }
            if (ProducetnId > 0)
            {
                result = result.Where(a => a.TblModel.ProducentId == ProducetnId);
            }
            if (TypeId > 0)
            {
                result = result.Where(a => a.TblModel.TypeId == TypeId);
            }

            return result;
        }
    }
}
