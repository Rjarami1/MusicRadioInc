using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MusicRadioInc.Startup))]
namespace MusicRadioInc
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
