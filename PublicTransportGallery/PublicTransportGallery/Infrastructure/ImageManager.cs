using PublicTransportGallery.Helpers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public static class ImageManager
    {
        public static string InsertImage(HttpPostedFileBase upload)
        {
            var filename = Guid.NewGuid() + Path.GetExtension(upload.FileName);
            var path = Path.Combine(System.Web.HttpContext.Current.Server.MapPath(AppConfig.BusFolderPath), filename);
            upload.SaveAs(path);
            return filename;
        }
    }
}