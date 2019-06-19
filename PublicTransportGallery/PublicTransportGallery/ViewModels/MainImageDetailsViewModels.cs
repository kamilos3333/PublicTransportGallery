using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class MainImageDetailsViewModels
    {
        public ImageDetailsViewModels ImageDetails { get; set; }
        public IEnumerable<TblComment> commentList { get; set; }
        public CommentViewModels comment { get; set; }
    }
}