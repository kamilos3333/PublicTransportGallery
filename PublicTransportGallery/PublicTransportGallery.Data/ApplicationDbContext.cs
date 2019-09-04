using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using PublicTransportGallery.Data.Model;
using System.Data.Entity;
using System.Security.Claims;
using System.Threading.Tasks;

namespace PublicTransportGallery.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationDbContext.ApplicationUser>
    {
        public DbSet<TblTypeTransport> TblTypeTransports { get; set; }
        public DbSet<TblProducent> TblProducents { get; set; }
        public DbSet<TblModel> TblModels { get; set; }
        public DbSet<TblImage> TblImages { get; set; }
        public DbSet<TblComment> TblComments { get; set; }
        public DbSet<TblThumbnail> TblThumbnails { get; set; }
        public DbSet<TblLogVisitorImage> TblLogVisitorImages { get; set; }
        public DbSet<TblVoivodeship> TblVoivodeships { get; set; }
        public DbSet<TblCity> TblCities { get; set; }
        public DbSet<TblPassengerTransport> TblPassengerTransports { get; set; }
        public DbSet<TblVehicle> TblVehicles { get; set; }

        public class ApplicationUser : IdentityUser
        {
            public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
            {
                // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
                var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
                // Add custom user claims here
                return userIdentity;
            }
        }

        public ApplicationDbContext()
            : base("DefaultConnection", throwIfV1Schema: false)
        {
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
    }
}
