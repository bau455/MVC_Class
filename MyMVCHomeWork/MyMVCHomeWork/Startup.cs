using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(MyMVCHomeWork.Startup))]
namespace MyMVCHomeWork
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
