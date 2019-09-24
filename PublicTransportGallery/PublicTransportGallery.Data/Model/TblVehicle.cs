using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblVehicle
    {
        public TblVehicle()
        {

        }
        public TblVehicle(int VehicleId)
        {
            this.VehicleId = VehicleId;
        }

        [Key]
        public int VehicleId { get; set; }
        public int PassengerTransId { get; set; }
        public int ModelId { get; set; }
        public int? YearOfGet { get; set; }
        public int? YearOfRemove { get; set; }
        public bool History { get; set; }

        public virtual TblModel TblModel { get; set; }
        public virtual TblPassengerTransport TblPassengerTransport { get; set; }
        public virtual ICollection<TblImage> TblImage { get; set; }
    }
}
