using Microsoft.AspNet.Identity;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Threading.Tasks;
using Uzuri_Swimwear.Model;

[assembly: OwinStartupAttribute(typeof(Uzuri_Swimwear.Startup))]

namespace Uzuri_Swimwear
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}