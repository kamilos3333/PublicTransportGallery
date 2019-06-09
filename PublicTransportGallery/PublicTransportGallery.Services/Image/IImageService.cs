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
        IList<TblImage> getAll();
        TblImage getImageId(int ImageId);
        IList<TblImage> SearchImage(int ModelId);
        IList<TblImage> DetailsUser(string Id);
    }
}
