using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PublicTransportGallery.Services.Comment
{
    public class CommentService : ICommentService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public void insertComments(TblComment comment)
        {
            db.TblComments.Add(comment);
        }

        public void deleteComments(TblComment comment)
        {
            throw new NotImplementedException();
        }

        public IList<TblComment> getAllCommentsByImageId(int id)
        {
            return db.TblComments.Where(a => a.ImageId == id).OrderByDescending(a => a.DateAdd).ToList();
        }

        public void Save() {
           db.SaveChanges();
        }
    }
}
