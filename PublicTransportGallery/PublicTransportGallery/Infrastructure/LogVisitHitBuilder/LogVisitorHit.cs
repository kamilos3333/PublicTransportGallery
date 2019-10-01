using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.Infrastructure.LogVisitHitBuilder
{
    public static class LogVisitorHit
    {
        public static bool LogVisit(int ImageId)
        {
            if(HttpContext.Current.Session["HistoryURL"] == null)
            {
                List<int> HistoryURL = new List<int>();
                HistoryURL.Add(ImageId);
                HttpContext.Current.Session["HistoryURL"] = HistoryURL;
            }
            else
            {
                List<int> HistoryURL = (List<int>)HttpContext.Current.Session["HistoryURL"];
                if(HistoryURL.Exists(x => x == ImageId))
                {
                    return false;
                }
                else
                {
                    HistoryURL.Add(ImageId);
                    HttpContext.Current.Session["HistoryURL"] = HistoryURL;
                }
            }
            return true;
        }
    }
}