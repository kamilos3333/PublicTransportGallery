using PublicTransportGallery.CustomValidation;
using PublicTransportGallery.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class UploadImageViewModels
    {
        public UploadImageViewModels()
        {
        }

        public UploadImageViewModels(IList<TblProducent> producentList)
        {
            ProducentList = producentList;
        }

        public IList<TblProducent> ProducentList { get; set; }
        
        [Display(Name = "Wybierz producenta")]
        public int ProducentId { get; set; }
        
        [Required]
        [Display(Name = "Wybierz model")]
        public int ModelId { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Dodaj zdjęcie")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".png" }, MaxContentLength = 1024 * 1024 * 2, ErrorMessage = "Niepoprawny format pliku")]
        public HttpPostedFileBase Image { get; set; }
        
        [Display(Name = "Opis zdjęcia")]
        public string Description { get; set; }
        
    }

}