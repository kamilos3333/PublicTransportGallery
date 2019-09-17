using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.ModelsDto;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportGallery.Services.Services
{
    public interface IVehicleService
    {
        IList<AdminListVehicle> GetAllVehicleJson();
        IList<TblVehicle> GetAllVehicle();
        IList<TblVehicle> GetAllVehicleById(int id);
        IList<VehicleDropDown> GetVehicleJoinPassangerTransport(int id);
        IQueryable<bool> GetItemHistoryVehicle(int id);
        IQueryable<string> GetItemVehicleType(int id);
        void InsertVehicle(TblVehicle model);
        void Save();
    }
}
