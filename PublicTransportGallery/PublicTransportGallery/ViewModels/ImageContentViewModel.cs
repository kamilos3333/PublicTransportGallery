using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class ImageContentViewModel
    {
        public int ImageId { get; set; }
        public string PhotoSrc { get; set; }
        public string NameProducent { get; set; }
        public string NameModel { get; set; }
        public string TypeVehicle { get; set; }
        public int CommentCount { get; set; }
        public int VisitorCount { get; set; }

        public string NameVehice { get { return string.Format($"{NameProducent} {NameModel}"); }}
    }
}