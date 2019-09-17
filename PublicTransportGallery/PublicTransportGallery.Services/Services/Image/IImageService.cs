using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.ModelsDto;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Image
{
    public interface IImageService 
    {
        void Insert(TblImage image);
        void Delete(TblImage image);
        void Update(TblImage image);
        TblImage getImageId(int ImageId);
        TblImage GetRandomImage(int VehicleId);
        IList<TblImage> getAll();
        IList<TblImage> DetailsUser(string Id);
        IList<AdminListImage> AdminImageList();
        void Save();
        Task SaveAsync();
    }
}
