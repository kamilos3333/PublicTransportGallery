using PublicTransportGallery.CustomValidation;
using PublicTransportGallery.Data.Model;
using PublicTransportGallery.Services.ModelsDto;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class ImageEditViewModels
    {
        public int ImageId { get; set; }

        public IList<TblVoivodeship> VoivodeshipList { get; set; }

        [Display(Name = "Wybierz województwo *")]
        public string WOJ { get; set; }

        public IList<TblCity> CityList { get; set; }

        [Required]
        [Display(Name = "Wybierz miasto *")]
        public int CityId { get; set; }

        public IList<TblPassengerTransport> PassangerTransportList { get; set; }

        [Required]
        [Display(Name = "Wybierz przwoźnika*")]
        public int PassengerTransId { get; set; }

        public IList<VehicleDropDown> VehicleList { get; set; }

        [Required]
        [Display(Name = "Wybierz pojazd*")]
        public int VehicleId { get; set; }

        [DataType(DataType.Upload)]
        [Display(Name = "Dodaj zdjęcie")]
        [File(AllowedFileExtensions = new string[] { ".jpg", ".png" }, MaxContentLength = 1024 * 1024 * 2, ErrorMessage = "Niepoprawny format pliku")]
        public HttpPostedFileBase Image { get; set; }

        [Display(Name = "Opis zdjęcia")]
        [StringLength(150, ErrorMessage = "Tekst nie może być dłuższy niż {1} znaków")]
        public string Description { get; set; }
    }
}