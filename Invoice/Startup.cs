using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(Invoice.Startup))]
namespace Invoice
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
