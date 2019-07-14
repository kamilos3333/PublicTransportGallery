using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data.Model
{
    public class TblComment
    {
        [Key]
        public int CommentId { get; set; }
        public string ContentText { get; set; }
        public DateTime DateAdd { get; set; }
        public string Id { get; set; }
        public int ImageId { get; set; }

        public virtual TblImage TblImage { get; set; }
        public ApplicationDbContext.ApplicationUser users { get; set; }
    }
}
