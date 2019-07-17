using PublicTransportGallery.Helpers;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure
{
    public class ImageThumbnail
    {
        public static void Crop(string fileName, int width, int height)
        {
            string url = Path.Combine(HttpContext.Current.Server.MapPath(AppConfig.ThumbnailFolderPath) + fileName);
            Bitmap sourceImage = new Bitmap(HttpContext.Current.Server.MapPath(AppConfig.BusFolderPath) + fileName);
            using(Bitmap objBitmap = new Bitmap(width, height))
            {
                objBitmap.SetResolution(sourceImage.HorizontalResolution, sourceImage.VerticalResolution);
                using(Graphics objGraphics = Graphics.FromImage(objBitmap))
                {
                    objGraphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
                    objGraphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    objGraphics.DrawImage(sourceImage, 0, 0, width, height);

                    objBitmap.Save(url);
                }
            }
        }
    }
}