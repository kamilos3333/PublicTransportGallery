using PublicTransportGallery.CustomValidation;
using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.ViewModels
{
    public class CreateVehicleViewModels
    {
        public IList<TblProducent> ProducentList { get; set; }

        [Display(Name = "Wybierz producenta *")]
        public int ProducentId { get; set; }

        [Required]
        [Display(Name = "Wybierz model *")]
        public int ModelId { get; set; }
        
        public IEnumerable<int> YearOfGetList { get; set; }

        [Display(Name = "Rok wprowadzenia")]
        [Year("YearOfRemove", ErrorMessage = "Rok wprowadznia nie może być wcześniejszy niż rok wycofania")]
        public int? YearOfGet { get; set; }
        
        public IEnumerable<int> YearOfRemoveList { get; set; }

        [Display(Name = "Rok wycofania")]
        public int? YearOfRemove { get; set; }

        public IList<TblVoivodeship> VoivodeshiList { get; set; }

        [Display(Name = "Wybierz województwo *")]
        public string WOJ { get; set; }

        [Required]
        [Display(Name = "Wybierz miasto *")]
        public int CityId { get; set; }

        [Required]
        [Display(Name = "Wybierz przwoźnika*")]
        public int PassengerTransId { get; set; }

        [Display(Name = "Model historyczny")]
        public bool History { get; set; }
    }
}