using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblPassengerTransport
    {
        [Key]
        public int PassengerTransId { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string Address { get; set; }
        public int CityId { get; set; }

        public virtual TblCity TblCity { get; set; }
        public virtual ICollection<TblVehicle> TblVehicles { get; set; }
    }
}
