using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class CommentViewModels
    {
        public CommentViewModels(int ImageId)
        {
            this.ImageId = ImageId;
        }

        public int ImageId {get; set;}
        public IList<CommentListViewModels> CommentList { get; set; }
        public CommentInsertViewModels CommentModel { get; set; }
    }
}