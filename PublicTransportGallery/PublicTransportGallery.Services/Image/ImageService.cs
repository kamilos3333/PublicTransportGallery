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

        public void Insert(TblImage image)
        {
            db.TblImages.Add(image);
            db.SaveChanges();
        }
    }
}
