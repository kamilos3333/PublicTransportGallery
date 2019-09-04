using PublicTransportGallery.Data.Model;
using System.Collections.Generic;

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
