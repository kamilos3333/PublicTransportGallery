using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.ModelVehicle
{
    public interface IModelService
    {
        IList<TblModel> getAll();
        IList<TblModel> getModelJoinProducent(int ProducentId);
    }
}
