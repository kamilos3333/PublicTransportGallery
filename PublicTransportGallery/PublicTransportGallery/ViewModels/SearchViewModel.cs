using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class SearchViewModel
    {
        public IList<TblProducent> ProducentsList { get; set; }
        public int ProducentId { get; set; }
        public int ModelId { get; set; }

        public IEnumerable<TblImage> ResultImages { get; set; }
    }
}