using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(week5_quiz2.Startup))]
namespace week5_quiz2
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
