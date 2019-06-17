using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class ImageDetailsViewModels
    {
        public string ImageName { get; set; }

        public string Producent { get; set; }

        public string Model { get; set; }

        public string ModelVehice { get { return Producent + " " + Model; } }

        [Display(Name = "Data dodania:")]
        public DateTime? DateAdd { get; set; }

        public string Description { get; set; }

        [Display(Name = "Autor:")]
        public string User { get; set; }

        [Display(Name = "Lata produkcji:")]
        public int YearProduction { get; set; }

        public int? YearEndProduction { get; set; }
    }
}