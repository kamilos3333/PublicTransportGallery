using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublicTransportGallery.Data.Model
{
    public class TblThumbnail
    {
        [Key]
        public int ThumbnailId { get; set; }
        public string Name { get; set; }
        public int ImageId { get; set; }

        public virtual TblImage TblImage { get; set; }
    }
}
