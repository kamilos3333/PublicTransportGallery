using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;

namespace PublicTransportGallery.Services.Services.City
{
    public class CityService : ICityService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public IList<TblCity> GetAllCities()
        {
            return db.TblCities.OrderBy(a => a.NAZWA).ToList();
        }

        public IList<TblCity> GetCitiesByVoivodeship(string Name)
        {
            return db.TblCities.Where(x => x.TblVoivodeship.NAZWA == Name).OrderBy(a => a.NAZWA).ToList();
        }

        public IList<TblCity> GetCityJoinVoivodeship(string woj)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TblCities.Where(a => a.WOJ == woj).OrderBy(a => a.NAZWA).ToList();
        }
    }
}
