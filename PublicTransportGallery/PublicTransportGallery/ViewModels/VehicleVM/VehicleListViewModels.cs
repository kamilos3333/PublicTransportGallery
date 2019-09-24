using PublicTransportGallery.Services.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class VehicleListViewModels
    {
        public int VehicleId { get; set; }
        public string ProducentName { get; set; }
        public string ModelName { get; set; }
        public int? YearOfGet { get; set; }
        public int? YearOfRemove { get; set; }
        public string Photo { get; set; }

        public bool History { get; set; }
        public string TypeTransportName { get; set; }
    }
}