using PublicTransportGallery.Data.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Comment
{
    public interface ICommentService
    {
        IList<TblComment> getAllCommentsByImageId(int id);
        void deleteComments(TblComment comment);
    }
}
