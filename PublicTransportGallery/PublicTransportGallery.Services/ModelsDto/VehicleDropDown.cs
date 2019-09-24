using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.ModelsDto
{
    public class VehicleDropDown
    {
        public int VehicleId { get; set; }
        public string ProducentModel { get; set; }
        public string NameModel { get; set; }
        public int? YearOfGet { get; set; }
        public int? YearOfRemove { get; set; }
        public string Year { get { return $"{YearOfGet}{(YearOfRemove == null ? "" : "-")}{YearOfRemove}"; } } 
        public string VehicleName { get { return $"{ProducentModel} {NameModel} ({Year})"; } }
    }
}
