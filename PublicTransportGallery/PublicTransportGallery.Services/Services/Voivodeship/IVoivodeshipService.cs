using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Services.Voivodeship
{
    public interface IVoivodeshipService
    {
        IList<TblVoivodeship> GetAllVoivodeships();
    }
}
