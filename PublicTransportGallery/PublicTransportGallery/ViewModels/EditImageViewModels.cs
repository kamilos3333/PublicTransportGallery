using PublicTransportGallery.CustomValidation;
using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class EditImageViewModels
    {
        public EditImageViewModels()
        {
        }

        public EditImageViewModels(IList<TblProducent> producentList, IList<TblModel> modelList)
        {
            ProducentList = producentList;
            ModelList = modelList;
        }

        public IList<TblProducent> ProducentList { get; set; }
        public IList<TblModel> ModelList { get; set; }

        public int ImageId { get; set; }

        [Required]
        [Display(Name = "Wybierz producenta")]
        public int ProducentId { get; set; }

        [Required]
        [Display(Name = "Wybierz model")]
        public int ModelId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Dodaj zdjęcie")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".png" }, MaxContentLength = 1024 * 1024 * 2, ErrorMessage = "Niepoprawny format pliku")]
        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Opis zdjęcia")]
        [StringLength(150, ErrorMessage = "Tekst nie może być dłuższy niż {1} znaków")]
        public string Description { get; set; }
    }
}