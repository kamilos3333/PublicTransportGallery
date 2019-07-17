using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Helpers
{
    public class AppConfig
    {
        private static string _imagesBusFolderPath = ConfigurationManager.AppSettings["BusFolder"];
        private static string _imagesThumbnailFolderPath = ConfigurationManager.AppSettings["ThumbnailFolder"];

        public static string BusFolderPath
        {
            get
            {
                return _imagesBusFolderPath;
            }
        }

        public static string ThumbnailFolderPath
        {
            get
            {
                return _imagesThumbnailFolderPath;
            }
        }
    }
}