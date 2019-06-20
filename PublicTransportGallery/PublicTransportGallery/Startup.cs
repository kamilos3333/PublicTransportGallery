using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(PublicTransportGallery.Startup))]
namespace PublicTransportGallery
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
        
    }
}
