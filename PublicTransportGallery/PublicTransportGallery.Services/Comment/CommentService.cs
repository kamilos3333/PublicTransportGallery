using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PublicTransportGallery.Data.Domain;

namespace PublicTransportGallery.Services.Comment
{
    public class CommentService : ICommentService
    {
        DatabaseEntities db = new DatabaseEntities();

        public void deleteComments(TblComment comment)
        {
            throw new NotImplementedException();
        }

        public IList<TblComment> getAllCommentsByImageId(int id)
        {
            return db.TblComments.Where(a => a.ImageId == id).ToList();
        }
    }
}
