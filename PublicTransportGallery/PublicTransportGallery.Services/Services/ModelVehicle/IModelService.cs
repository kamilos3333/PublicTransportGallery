using PublicTransportGallery.Data.Model;
using System.Collections.Generic;

namespace PublicTransportGallery.Services.ModelVehicle
{
    public interface IModelService
    {
        IList<TblModel> getAll();
        IList<TblModel> getModelJoinProducent(int ProducentId);
        IList<TblTypeTransport> getTypeName();
    }
}
