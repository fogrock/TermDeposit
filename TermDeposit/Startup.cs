using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(TermDeposit.Startup))]
namespace TermDeposit
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
        }
    }
}
