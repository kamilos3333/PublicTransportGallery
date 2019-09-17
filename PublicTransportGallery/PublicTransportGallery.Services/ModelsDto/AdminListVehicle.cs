using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.ModelsDto
{
    public class AdminListVehicle
    {
        public int VehicleId { get; set; }
        public string PassengerTransName { get; set; }
        public string ModelId { get; set; }
        public string ProducentId { get; set; }
        public string VehicleName { get { return ProducentId + " " + ModelId; } }
        public string TypeId { get; set; }
        public int? YearOfGet { get; set; }
        public int? YearOfRemove { get; set; }
        public bool History { get; set; }
    }
}
