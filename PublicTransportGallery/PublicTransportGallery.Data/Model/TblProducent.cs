using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublicTransportGallery.Data.Model
{
    public class TblProducent
    {
        public TblProducent()
        {
            this.TblModels = new HashSet<TblModel>();
        }

        [Key]
        public int ProducentId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public virtual ICollection<TblModel> TblModels { get; set; }
    }
}
