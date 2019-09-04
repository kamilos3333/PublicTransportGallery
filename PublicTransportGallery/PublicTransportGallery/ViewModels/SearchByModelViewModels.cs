using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace PublicTransportGallery.ViewModels
{
    public class SearchByModelViewModels
    {
        public SearchByModelViewModels()
        {

        }

        public SearchByModelViewModels(IList<TblProducent> producentList, IList<TblTypeTransport> typeList)
        {
            ProducentList = producentList;
            TypeList = typeList;
        }

        public SearchByModelViewModels(IList<TblProducent> producentList, IList<TblTypeTransport> typeList, IQueryable<TblImage> imageList) : this(producentList, typeList)
        {
            ImageList = imageList;
        }

        public IList<TblProducent> ProducentList { get; set; }
        
        [Display(Name = "Wybierz producenta")]
        public int ProducentId { get; set; }
        
        [Display(Name = "Wybierz model")]
        public int? ModelId { get; set; }

        public IList<TblTypeTransport> TypeList { get; set; }

        [Display(Name = "Wybierz typ pojazdu")]
        public int? TypeId { get; set; }

        public IQueryable<TblImage> ImageList { get; set; }
        
    }
}