using System.Collections.Generic;

namespace PublicTransportGallery.ViewModels
{
    public class MainImageDetailsViewModels
    {
        public MainImageDetailsViewModels(ImageDetailsViewModels ImageDetails, List<CommentListViewModels> Comments)
        {
            this.ImageDetails = ImageDetails;
            this.Comments = Comments;
        }

        public ImageDetailsViewModels ImageDetails { get; set; }
        public CommentInsertViewModels InsertComment { get; set; }
        public List<CommentListViewModels> Comments { get; set; }
    }
}