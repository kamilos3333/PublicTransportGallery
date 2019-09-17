using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.ModelsDto;

namespace PublicTransportGallery.Services.Services.PassengerTransport
{
    public class PassengerTransportService : IPassengerTransportService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public TblPassengerTransport GetPassengerTransportById(int id)
        {
            return db.TblPassengerTransports.FirstOrDefault(x => x.PassengerTransId == id);
        }

        public IList<TblPassengerTransport> GetPassengerTransportsJoinCity(int CityId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TblPassengerTransports.Where(a => a.CityId == CityId).OrderBy(a => a.PassengerTransId).ToList();
        }
    }
}
