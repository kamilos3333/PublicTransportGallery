using PublicTransportGallery.CustomValidation;
using PublicTransportGallery.Data.Model;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class UploadImageViewModels
    {
        public IList<TblVoivodeship> VoivodeshiList { get; set; }

        [Display(Name = "Wybierz województwo *")]
        public string WOJ { get; set; }

        [Required]
        [Display(Name = "Wybierz miasto *")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Wybierz przwoźnika*")]
        public int PassengerTransId { get; set; }

        [Required]
        [Display(Name = "Wybierz pojazd*")]
        public int VehicleId { get; set; }

        [Required]
        [DataType(DataType.Upload)]
        [Display(Name = "Dodaj zdjęcie")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".png" }, MaxContentLength = 1024 * 1024 * 2, ErrorMessage = "Niepoprawny format pliku")]
        public HttpPostedFileBase Image { get; set; }
        
        [Display(Name = "Opis zdjęcia")]
        [StringLength(150, ErrorMessage = "Tekst nie może być dłuższy niż {1} znaków")]
        public string Description { get; set; }
        
    }

}