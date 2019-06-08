using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class MainViewModel
    {
        public IEnumerable<TblImage> images { get; set; }
    }
}