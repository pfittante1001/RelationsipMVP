using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(RelationshipMVC.Startup))]
namespace RelationshipMVC
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
