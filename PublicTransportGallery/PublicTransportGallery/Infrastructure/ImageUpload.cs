using PublicTransportGallery.Helpers;
using System;
using System.IO;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public static class ImageUpload
    {
        public static string InsertImage(HttpPostedFileBase upload)
        {
            string fileName = getFileName(upload);
            SaveToPath(upload, fileName);
            return fileName;
        }

        public static void EditImage(HttpPostedFileBase upload, string fileName)
        {
            SaveToPath(upload, fileName);
        }

        private static void SaveToPath(HttpPostedFileBase upload, string fileName)
        {
            var path = Path.Combine(HttpContext.Current.Server.MapPath(SetFolderPath()), fileName);
            upload.SaveAs(path);
        }
        
        private static string getFileName(HttpPostedFileBase upload)
        {
            return Guid.NewGuid() + Path.GetExtension(upload.FileName);
        }

        private static string SetFolderPath()
        {
            return AppConfig.BusFolderPath;
        }
    }
}