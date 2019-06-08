using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Helpers
{
    public static class UrHelpers
    {
        public static string BusImgPath(this UrlHelper helper, string nameBusFolder)
        {
            var BusImgFolder = AppConfig.BusFolderPath;
            var path = Path.Combine(BusImgFolder, nameBusFolder);
            var pathFolder = helper.Content(path);

            return pathFolder;
        }
    }
}