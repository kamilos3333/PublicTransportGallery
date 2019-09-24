using PublicTransportGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace PublicTransportGallery.Services.Validation
{
    public class ValidationService : IValidationService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool CheckIfUserIsAdminImage(string UserId)
        {
            return db.TblImages.Where(a => a.Id == UserId).Any();
        }

        public bool CheckIfUserIsAuthorizateToImage(string UserId, int ImageId)
        {
            if (HttpContext.Current.User.IsInRole("Admin"))
            {
                return true;
            }
            return db.TblImages.Where(x => x.Id == UserId && x.ImageId == ImageId).Any();
        }
    }
}
