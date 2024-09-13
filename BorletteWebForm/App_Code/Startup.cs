using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(BorletteWebForm.Startup))]
namespace BorletteWebForm
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
            ConfigureAuth(app);
        }
    }
}
