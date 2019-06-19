using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using PublicTransportGallery.CustomValidation;

namespace PublicTransportGallery.ViewModels
{
    public class ImageUploadViewModels
    {
        public IList<TblProducent> ProducentList { get; set; }
        
        [Display(Name = "Wybierz producenta")]
        public int ProducentId { get; set; }
        
        [Required]
        [Display(Name = "Wybierz model")]
        public int ModelId { get; set; }

        [DataType(DataType.Upload)]
        [Required]
        [Display(Name = "Dodaj zdjęcie")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".png" }, MaxContentLength = 1024 * 1024 * 2, ErrorMessage = "Niepoprawny format pliku")]
        public HttpPostedFileBase Image { get; set; }
        
        [Display(Name = "Opis zdjęcia")]
        public string Description { get; set; }
    }
}