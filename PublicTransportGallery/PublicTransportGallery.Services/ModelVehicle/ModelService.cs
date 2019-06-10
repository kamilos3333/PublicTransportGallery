using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTransportGallery.Data.Domain;

namespace PublicTransportGallery.Services.ModelVehicle
{
    public class ModelService : IModelService
    {
        private DatabaseEntities db = new DatabaseEntities();

        public IList<TblModel> getAll()
        {
            return db.TblModels.Include("TblProducent").Include("TblTypeTransport").OrderBy(a => a.TblProducent.Name).ToList();
        }

        public IList<TblModel> getModelJoinProducent(int ProducentId)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TblModels.Where(a => a.ProducentId == ProducentId).OrderBy(a => a.NameModel).ToList();
        }

        public IList<TblTypeTransport> getTypeName()
        {
            return db.TblTypeTransports.ToList();
        }
    }
}
