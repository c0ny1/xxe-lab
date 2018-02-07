using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Csharp_xxe.Startup))]
namespace Csharp_xxe
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            //ConfigureAuth(app);
        }
    }
}
