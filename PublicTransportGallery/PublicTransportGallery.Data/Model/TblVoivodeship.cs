using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblVoivodeship
    {
        [Key]
        public string WOJ { get; set; }
        public string NAZWA { get; set; }

        public virtual ICollection<TblCity> TblCities { get; set; }
    }
}
