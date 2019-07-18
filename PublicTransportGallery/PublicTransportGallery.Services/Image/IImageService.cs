using PublicTransportGallery.Data.Model;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportGallery.Services.Image
{
    public interface IImageService 
    {
        void Insert(TblImage image);
        void Delete(TblImage image);
        void Update(TblImage image);
        TblImage getImageId(int ImageId);
        IList<TblImage> getAll();
        IQueryable<TblImage> SearchImage(int ProducetnId, int? ModelId, int? TypeId);
        IList<TblImage> DetailsUser(string Id);
        void Save();
    }
}
