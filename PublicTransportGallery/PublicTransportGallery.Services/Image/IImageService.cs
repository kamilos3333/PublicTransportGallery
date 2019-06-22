using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Image
{
    public interface IImageService 
    {
        void Insert(TblImage image);
        void Delete(TblImage image);
        TblImage getImageId(int ImageId);
        IList<TblImage> getAll();
        IQueryable<TblImage> SearchImage(int ProducetnId, int? ModelId);
        IList<TblImage> DetailsUser(string Id);
        void Save();
    }
}
