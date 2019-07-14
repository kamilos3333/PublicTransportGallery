using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using PublicTransportGallery.Services.Image;
using PublicTransportGallery.ViewModels;
using System.Web;
using System.Web.Mvc;

namespace PublicTransportGallery.Controllers
{
    public class UserController : Controller
    {
        private readonly IImageService imageService;
        public UserController(IImageService imageService)
        {
            this.imageService = imageService;
        }

        public ActionResult DetailsUser(string Username)
        {
            var getUser = UserManager.FindByName(Username);
            if (getUser == null)
            {
                return HttpNotFound();
            }
            var model = new DetailsUserViewModels(imageService.DetailsUser(getUser.Id));

            return View(model);
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }
    }
}