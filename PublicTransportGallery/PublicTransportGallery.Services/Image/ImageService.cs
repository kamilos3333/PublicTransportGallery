using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTransportGallery.Data.Domain;

namespace PublicTransportGallery.Services.Image
{
    public class ImageService : IImageService
    {
        private DatabaseEntities db = new DatabaseEntities();

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
            return db.TblImages.Include("TblModel").FirstOrDefault(a => a.ImageId == ImageId);
        }

        public IQueryable<TblImage> SearchImage(int ProducetnId, int? ModelId)
        {
            var result = db.TblImages.Include("TblModel").OrderByDescending(a => a.DateAdd).AsQueryable();

            if (ModelId > 0)
            {
                return result = result.Where(a => a.ModelId == ModelId);
            }
            else
            {
                return result = result.Where(a => a.TblModel.ProducentId == ProducetnId);
            }
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
