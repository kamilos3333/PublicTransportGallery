using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class PassengerTransportViewModels
    {
        public int PassengerTransId { get; set; }
        [Display(Name = "Nazwa")]
        public string Name { get; set; }
        [Display(Name = "Skrót")]
        public string ShortName { get; set; }
        [Display(Name = "Adres")]
        public string Address { get; set; }
        [Display(Name = "Miasto")]
        public string CityName { get; set; }

        public IList<VehicleListViewModels> VehicleList { get; set; }
        public IQueryable<bool> VehicleHistory { get; set; }
        public IQueryable<string> VehicleType { get; set; }
    }
}