using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Helpers
{
    public static class HistoryBoolHelper
    {
        public static MvcHtmlString HistoryHelper(this HtmlHelper htmlHelper, bool yesNo)
        {
            var text = yesNo ? "Pojazd historyczny" : "Aktualna flota";
            return new MvcHtmlString(text);
        }
    }
}