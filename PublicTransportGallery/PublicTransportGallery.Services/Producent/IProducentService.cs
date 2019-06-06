using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Producent
{
    public interface IProducentService
    {
        IList<TblProducent> getAll();
        void insertProducent(TblProducent producent);
        void updateProducent(TblProducent producent);
        void deleteProducent(TblProducent producent);
        TblProducent getIdProducent(int ProducentID);
    }
}
