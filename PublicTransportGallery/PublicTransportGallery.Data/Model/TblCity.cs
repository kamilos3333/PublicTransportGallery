using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblCity
    {
        [Key]
        public int CityId { get; set; }
        public string WOJ { get; set; }
        public string NAZWA { get; set; }

        public virtual TblVoivodeship TblVoivodeship { get; set; }
        public ICollection<TblPassengerTransport> TblPassengerTransports { get; set; }
    }
}
