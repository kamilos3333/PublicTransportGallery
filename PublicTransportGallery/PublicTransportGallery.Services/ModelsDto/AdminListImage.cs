using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.ModelsDto
{
    public class AdminListImage
    {
        public int ImageId { get; set; }
        public string ImageName { get; set; }
        public string ModelName { get; set; }
        public string ProducentName { get; set; }
        public string VehicleName { get { return ProducentName + " " + ModelName; } }
        public string VehicleType { get; set; }
        public string Author { get; set; }
        public DateTime DateAdded { get; set; }
    }
}
