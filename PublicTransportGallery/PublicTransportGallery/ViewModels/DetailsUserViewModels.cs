using PublicTransportGallery.Data.Model;
using System.Collections.Generic;

namespace PublicTransportGallery.ViewModels
{
    public class DetailsUserViewModels
    {
        public DetailsUserViewModels(IEnumerable<TblImage> model)
        {
            this.ImagesList = model;
        }

        public IEnumerable<TblImage> ImagesList { get; set; }
    }
}