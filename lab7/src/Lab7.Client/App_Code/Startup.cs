using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(lab_7_viewer.Startup))]
namespace lab_7_viewer
{
    public partial class Startup {
        public void Configuration(IAppBuilder app) {
        }
    }
}
