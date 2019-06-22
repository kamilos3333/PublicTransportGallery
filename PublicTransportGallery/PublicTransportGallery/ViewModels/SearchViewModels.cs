using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PublicTransportGallery.ViewModels
{
    public class SearchViewModels
    {
        public IList<TblProducent> ProducentList { get; set; }

        [Required]
        [Display(Name = "Wybierz producenta")]
        public int ProducentId { get; set; }
        
        [Display(Name = "Wybierz model")]
        public int? ModelId { get; set; }

        public IQueryable<TblImage> ImageList { get; set; }
    }
}