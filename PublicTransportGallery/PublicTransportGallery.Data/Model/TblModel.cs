using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublicTransportGallery.Data.Model
{
    public class TblModel
    {
        public TblModel()
        {
            this.TblImages = new HashSet<TblImage>();
        }

        [Key]
        public int ModelId { get; set; }
        public int ProducentId { get; set; }
        public string NameModel { get; set; }
        public int TypeId { get; set; }
        public int YearProduction { get; set; }
        public System.Nullable<int> YearProductionEnd { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblImage> TblImages { get; set; }
        public virtual TblProducent TblProducent { get; set; }
        public virtual TblTypeTransport TblTypeTransport { get; set; }
    }
}
