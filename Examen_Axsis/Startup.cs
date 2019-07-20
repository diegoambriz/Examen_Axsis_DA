using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Examen_Axsis.Startup))]
namespace Examen_Axsis
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
