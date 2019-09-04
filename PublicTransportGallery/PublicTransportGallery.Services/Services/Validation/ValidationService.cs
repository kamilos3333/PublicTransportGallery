using PublicTransportGallery.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Validation
{
    public class ValidationService : IValidationService
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public bool CheckIfUserIsAdminImage(string UserId)
        {
            return db.TblImages.Where(a => a.Id == UserId).Any();
        }
    }
}
