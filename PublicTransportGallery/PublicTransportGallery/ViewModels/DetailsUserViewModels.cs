using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

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