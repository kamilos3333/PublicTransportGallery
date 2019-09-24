using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class CommentListViewModels
    {
        public CommentListViewModels()
        {
        }

        public CommentListViewModels(string ContentText, string Username, int ImageId, DateTime DateAdd)
        {
            this.ContentText = ContentText;
            this.Username = Username;
            this.ImageId = ImageId;
            this.DateAdd = DateAdd;
        }

        public int CommentId { get; set; }
        public string ContentText { get; set; }
        public string Username { get; set; }
        public int ImageId { get; set; }
        public DateTime DateAdd { get; set; }
    }
}