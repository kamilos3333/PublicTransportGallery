using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;

namespace PublicTransportGallery.Services.Services.Voivodeship
{
    public class VoivodeshipService : IVoivodeshipService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public IList<TblVoivodeship> GetAllVoivodeships()
        {
            return db.TblVoivodeships.ToList();
        }
    }
}
