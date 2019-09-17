using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblLogVisitorImage
    {
        [Key]
        public int LogVisitorId { get; set; }
        public int ImageId { get; set; }
        public DateTime DateVisit { get; set; }
        
        public virtual TblImage TblImage { get; set; }
    }
}
