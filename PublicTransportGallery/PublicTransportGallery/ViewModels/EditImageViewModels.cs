using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class EditImageViewModels
    {
        public int ImageId { get; set; }

        [Display(Name = "Opis zdjęcia")]
        [StringLength(150, ErrorMessage = "Tekst nie może być dłuższy niż {1} znaków")]
        public string Description { get; set; }
    }
}