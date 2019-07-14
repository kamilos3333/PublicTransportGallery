using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportGallery.Services.Producent
{
    public partial class ProducentService : IProducentService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void deleteProducent(TblProducent producent)
        {
            db.TblProducents.Remove(producent);
        }

        public IList<TblProducent> getAll()
        {
           return db.TblProducents.OrderBy(a => a.Name).ToList();
        }

        public TblProducent getIdProducent(int ProducentID)
        {
            return db.TblProducents.FirstOrDefault(o => o.ProducentId == ProducentID);
        }

        public void insertProducent(TblProducent producent)
        {
            db.TblProducents.Add(producent);
            db.SaveChanges();
        }

        public void updateProducent(TblProducent producent)
        {
            db.Entry(producent).State = System.Data.Entity.EntityState.Modified;
        }
    }
}
