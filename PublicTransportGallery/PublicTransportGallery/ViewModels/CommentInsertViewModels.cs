using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class CommentInsertViewModels
    {
        [Display(Name = "Dodaj komentarz")]
        public string ContentText { get; set; }
    }

    

}