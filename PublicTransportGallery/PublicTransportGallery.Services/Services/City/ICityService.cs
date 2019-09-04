using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Services.City
{
    public interface ICityService
    {
        IList<TblCity> GetAllCities();
        IList<TblCity> GetCityJoinVoivodeship(string woj);
    }
}
