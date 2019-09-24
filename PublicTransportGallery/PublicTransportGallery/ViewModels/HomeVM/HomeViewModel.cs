using PublicTransportGallery.Data.Model;
using System.Collections.Generic;

namespace PublicTransportGallery.ViewModels
{
    public class HomeViewModel
    {
        public HomeViewModel()
        {

        }

        public HomeViewModel(IEnumerable<TblTypeTransport> TypeTransport, IEnumerable<ImageContentViewModel> Images)
        {
            this.TypeTransport = TypeTransport;
            this.Images = Images;
        }

        public IEnumerable<TblTypeTransport> TypeTransport { get; set; } 
        public IEnumerable<ImageContentViewModel> Images { get; set; }
    }
}