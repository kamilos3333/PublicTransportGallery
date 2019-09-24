using PublicTransportGallery.Data;
using PublicTransportGallery.Data.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
            db.TblComments.Remove(comment);
            db.SaveChanges();
        }

        public IList<TblComment> getAllCommentsByImageId(int id)
        {
            return db.TblComments.Where(a => a.ImageId == id).Include("users").OrderByDescending(a => a.DateAdd).ToList();
        }

        public void Save() {
           db.SaveChanges();
        }

        public int GetCommentCount(int id)
        {
            return db.TblComments.Where(a => a.ImageId == id).Count();
        }

        public TblComment GetCommentById(int id)
        {
            return db.TblComments.FirstOrDefault(x => x.CommentId == id);
        }

        public IList<TblComment> getAllComments()
        {
            return db.TblComments.ToList();
        }
    }
}
