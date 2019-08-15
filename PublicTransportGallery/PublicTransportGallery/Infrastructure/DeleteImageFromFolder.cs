using PublicTransportGallery.Helpers;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public static class DeleteImageFromFolder
    {
        public static void DeleteImage(string fileName)
        {
            try
            {
                string fullPathMainPhoto = HttpContext.Current.Server.MapPath((AppConfig.BusFolderPath) + fileName);
                string fullPathThumbPhoto = HttpContext.Current.Server.MapPath((AppConfig.ThumbnailFolderPath) + fileName);


                if (System.IO.File.Exists(fullPathMainPhoto) && System.IO.File.Exists(fullPathThumbPhoto))
                {
                    System.IO.File.Delete(fullPathMainPhoto);
                    System.IO.File.Delete(fullPathThumbPhoto);
                }
            }
            catch(Exception ex)
            {
                Debug.WriteLine($"Image {fileName} hasn't been deleted. {ex}"); 
            }
        }
    }
}