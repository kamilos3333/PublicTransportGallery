using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblTypeTransport
    {
        public TblTypeTransport()
        {
            this.TblModels = new HashSet<TblModel>();
        }

        [Key]
        public int TypeId { get; set; }
        public string Name { get; set; }

        public virtual ICollection<TblModel> TblModels { get; set; }
    }
}
