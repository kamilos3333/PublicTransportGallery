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

        public int ProducentId { get; set; }

        public int ModelId { get; set; }
        
        [Display(Name = "Opis zdjęcia")]
        [StringLength(150, ErrorMessage = "Tekst nie może być dłuższy niż {1} znaków")]
        public string Description { get; set; }
    }
}