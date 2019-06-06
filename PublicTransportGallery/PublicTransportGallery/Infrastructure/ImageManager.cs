using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public class ImageManager : IImageManager
    {
        public string InsertImage(HttpPostedFileBase upload)
        {
            var filename = Guid.NewGuid() + Path.GetExtension(upload.FileName);
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath("~/Photos"), filename);
            upload.SaveAs(path);
            return filename;
        }
    }
}