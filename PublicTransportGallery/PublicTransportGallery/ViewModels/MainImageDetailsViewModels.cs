using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class MainImageDetailsViewModels
    {
        //public string ImageName { get; set; }
        //public string Producent { get; set; }
        //public string Model { get; set; }
        //public string ModelVehice { get { return Producent + " " + Model; } }
        //public DateTime? DateAdd { get; set; }
        //public string Description { get; set; }
        //public string User { get; set; }
        //public int YearProduction { get; set; }
        //public int? YearEndProduction { get; set; }
        public ImageDetailsViewModels ImageDetails { get; set; }
        public IEnumerable<TblComment> commentList { get; set; }
        public CommentViewModels comment { get; set; }
    }
}