using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Agenda.Backend.Startup))]
namespace Agenda.Backend
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
