using PublicTransportGallery.Data.Model;
using System.Collections.Generic;

namespace PublicTransportGallery.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel(IEnumerable<TblTypeTransport> TypeTransport, IEnumerable<TblImage> Images)
        {
            this.TypeTransport = TypeTransport;
            this.Images = Images;
        }

        public IEnumerable<TblTypeTransport> TypeTransport { get; set; } 
        public IEnumerable<TblImage> Images { get; set; }
    }
}