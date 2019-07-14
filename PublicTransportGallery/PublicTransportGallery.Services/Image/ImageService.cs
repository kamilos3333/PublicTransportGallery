using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportGallery.Services.Image
{
    public class ImageService : IImageService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
            return db.TblImages.Include("TblModel").Include("users").FirstOrDefault(a => a.ImageId == ImageId);
        }

        public IQueryable<TblImage> SearchImage(int ProducetnId, int? ModelId, int? TypeId)
        {
            var result = db.TblImages.Include("TblModel").OrderByDescending(a => a.DateAdd).AsQueryable();

            if (ModelId > 0)
            {
                result = result.Where(a => a.ModelId == ModelId);
            }
            if (ProducetnId > 0)
            {
                result = result.Where(a => a.TblModel.ProducentId == ProducetnId);
            }
            if (TypeId > 0)
            {
                result = result.Where(a => a.TblModel.TypeId == TypeId);
            }
            
            return result;
        }

        public IList<TblImage> DetailsUser(string Id)
        {
            return db.TblImages.Include("TblModel").Where(a => a.Id == Id).OrderByDescending(a => a.DateAdd).ToList();
        }

        public void Delete(TblImage image)
        {
            db.TblImages.Remove(image);
        }

        public void Save()
        {
            db.SaveChanges();
        }

    }
}
