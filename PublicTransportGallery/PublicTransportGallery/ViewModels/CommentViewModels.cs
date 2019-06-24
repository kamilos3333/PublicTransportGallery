using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class CommentViewModels
    {
        public string ContentText { get; set; }
        public string Username { get; set; }
        public int ImageId { get; set; }
        public DateTime DateAdd { get; set; }
    }
}