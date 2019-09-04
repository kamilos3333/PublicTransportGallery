using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PublicTransportGallery.Services.Validation
{
    public interface IValidationService
    {
        bool CheckIfUserIsAdminImage(string UserId);
    }
}
