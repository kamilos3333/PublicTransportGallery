using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.ModelsDto;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace PublicTransportGallery.Services.Services.Vehicle
{
    public class VehicleService : IVehicleService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public void Delete(TblVehicle model)
        {
            db.TblVehicles.Attach(model);
            db.TblVehicles.Remove(model);
        }

        public IList<TblVehicle> GetAllVehicle()
        {
            return db.TblVehicles.ToList();
        }

        public IList<TblVehicle> GetAllVehicleById(int id)
        {
            return db.TblVehicles.Include(x => x.TblModel).Include(x => x.TblModel.TblProducent).Include(x => x.TblImage).Where(x => x.PassengerTransId == id).ToList();
        }

        public IList<AdminListVehicle> GetAllVehicleJson()
        {
            return db.TblVehicles.Include(x => x.TblPassengerTransport).Select(x => new AdminListVehicle { ModelId = x.TblModel.NameModel, ProducentId = x.TblModel.TblProducent.Name, PassengerTransName = x.TblPassengerTransport.Name, VehicleId = x.VehicleId, TypeId = x.TblModel.TblTypeTransport.Name, YearOfGet = x.YearOfGet, YearOfRemove = x.YearOfRemove }).ToList();
        }

        public IQueryable<bool> GetItemHistoryVehicle(int id)
        {
            return db.TblVehicles.Where(x => x.PassengerTransId == id).Select(x => x.History).Distinct();
        }

        public IQueryable<string> GetItemVehicleType(int id)
        {
            return db.TblVehicles.Include(x => x.TblModel.TblTypeTransport).Where(x => x.PassengerTransId == id).Select(x => x.TblModel.TblTypeTransport.Name).Distinct();
        }

        public TblVehicle GetVehicleById(int VehicleId)
        {
            return db.TblVehicles.FirstOrDefault(x => x.VehicleId == VehicleId);
        }

        public IList<VehicleDropDown> GetVehicleJoinPassangerTransport(int id)
        {
            db.Configuration.ProxyCreationEnabled = false;
            return db.TblVehicles.Where(x => x.PassengerTransId == id).Select(x => new VehicleDropDown { VehicleId = x.VehicleId, NameModel = x.TblModel.NameModel, ProducentModel = x.TblModel.TblProducent.Name, YearOfGet = x.YearOfGet, YearOfRemove = x.YearOfRemove }).ToList();
        }

        public void InsertVehicle(TblVehicle model)
        {
            db.TblVehicles.Add(model);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(TblVehicle model)
        {
            db.Entry(model).State = EntityState.Modified;
        }
    }
}
