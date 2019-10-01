using PublicTransportGallery.CustomValidation;
using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class EditVehiceViewModels
    {
        public int VehicleId { get; set; }

        public IList<TblProducent> ProducentList { get; set; }

        [Display(Name = "Wybierz producenta *")]
        public int ProducentId { get; set; }

        public IList<TblModel> ModelList { get; set; }

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

        public IList<TblVoivodeship> VoivodeshipList { get; set; }

        [Display(Name = "Wybierz województwo *")]
        public string WOJ { get; set; }

        public IList<TblCity> CityList { get; set; }

        [Required]
        [Display(Name = "Wybierz miasto *")]
        public int CityId { get; set; }

        public IList<TblPassengerTransport> PassangerTranspotList { get; set; }

        [Required]
        [Display(Name = "Wybierz przwoźnika*")]
        public int PassengerTransId { get; set; }

        [Display(Name = "Model historyczny")]
        public bool History { get; set; }
    }
}