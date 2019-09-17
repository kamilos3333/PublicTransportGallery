using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using System.Collections.Generic;
using System.Linq;
using System.Data.Entity;
using System.Threading.Tasks;
using PublicTransportGallery.Services.ModelsDto;
using System;

namespace PublicTransportGallery.Services.Image
{
    public class ImageService : IImageService
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public IList<TblImage> getAll()
        {
           return db.TblImages.OrderByDescending(a => a.DateAdd).ToList();
        }

        public void Insert(TblImage image)
        {
            db.TblImages.Add(image);
        }

        public TblImage getImageId(int ImageId)
        {
            return db.TblImages.Include(x => x.TblVehicles).Include(x => x.users).FirstOrDefault(a => a.ImageId == ImageId);
        }
        
        public IList<TblImage> DetailsUser(string Id)
        {
            return db.TblImages.Include(x => x.TblVehicles).Where(a => a.Id == Id).OrderByDescending(a => a.DateAdd).ToList();
        }

        public void Delete(TblImage image)
        {
            db.TblImages.Remove(image);
        }
        
        public void Update(TblImage image)
        {
            db.Entry(image).State = EntityState.Modified;
        }

        public void Save()
        {
            db.SaveChanges();
        }
        
        public async Task SaveAsync()
        {
            await db.SaveChangesAsync();
        }

        public IList<AdminListImage> AdminImageList()
        {
            return db.TblImages.Include(x => x.users).OrderByDescending(a => a.DateAdd).Select(x => new AdminListImage { ImageId = x.ImageId, ModelName = x.TblVehicles.TblModel.NameModel, ProducentName = x.TblVehicles.TblModel.TblProducent.Name, ImageName = x.Name, VehicleType = x.TblVehicles.TblModel.TblTypeTransport.Name, Author = x.users.UserName, DateAdded = x.DateAdd }).ToList();
        }

        public TblImage GetRandomImage(int VehicleId)
        {
            Random rnd = new Random();
            return db.TblImages.Where(a => a.VehicleId == VehicleId).OrderBy(x => Guid.NewGuid()).FirstOrDefault();
        }
    }
}
