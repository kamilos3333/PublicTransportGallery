using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblImage
    {
        public TblImage()
        {

        }

        public TblImage(int ImageId)
        {
            this.ImageId = ImageId;
        }

        public TblImage(string Name, string Id)
        {
            this.Name = Name;
            this.Id = Id;
            DateAdd = DateTime.Now;
        }

        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int VehicleId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Id { get; set; }

        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblLogVisitorImage> TblLogVisitor { get; set; }
        public virtual TblVehicle TblVehicles { get; set; }
        public ApplicationDbContext.ApplicationUser users { get; set; }
    }
}
