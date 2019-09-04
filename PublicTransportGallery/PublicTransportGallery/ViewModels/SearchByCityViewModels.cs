using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class SearchByCityViewModels
    {
        public IList<TblVoivodeship> VoivodeshipsList { get; set; }

        [Display(Name = "Wybierz województwo")]
        public string WOJ { get; set; }

        [Display(Name = "Wybierz miasto")]
        public int CityId { get; set; }

        public IQueryable<TblPassengerTransport> PassengerTransportsList { get; set; }
    }
}