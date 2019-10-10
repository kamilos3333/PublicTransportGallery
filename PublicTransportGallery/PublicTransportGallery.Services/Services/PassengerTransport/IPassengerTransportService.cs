using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.ModelsDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Services.PassengerTransport
{
    public interface IPassengerTransportService
    {
        TblPassengerTransport GetPassengerTransportById(int id);
        IList<TblPassengerTransport> GetPassengerTransportsJoinCity(int id);
        IList<TblPassengerTransport> GetPassengerTransportsByCity(string City);
    }
}
