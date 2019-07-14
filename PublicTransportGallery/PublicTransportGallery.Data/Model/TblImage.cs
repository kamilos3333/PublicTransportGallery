using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PublicTransportGallery.Data.Model
{
    public class TblImage
    {
        public TblImage()
        {
            this.TblComments = new HashSet<TblComment>();
            this.TblThumbnails = new HashSet<TblThumbnail>();
        }
        public TblImage(string fileName, string Id)
        {
            Name = fileName;
            DateAdd = DateTime.Now;
            this.Id = Id;
        }

        [Key]
        public int ImageId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ModelId { get; set; }
        public DateTime DateAdd { get; set; }
        public string Id { get; set; }

        public virtual ICollection<TblComment> TblComments { get; set; }
        public virtual ICollection<TblThumbnail> TblThumbnails { get; set; }
        public virtual TblModel TblModel { get; set; }
        public ApplicationDbContext.ApplicationUser users { get; set; }
    }
}
