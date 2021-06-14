using Microsoft.Owin;
using Owin;
using System;
using System.Threading.Tasks;
using Microsoft.Owin.Security.Cookies;

[assembly: OwinStartup(typeof(AutenticacaoMVC.Startup))]

namespace AutenticacaoMVC
{
    public class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            app.UseCookieAuthentication(new CookieAuthenticationOptions
            { 
                 AuthenticationType = "AplicationCookie",
                 LoginPath = new PathString("/Autenticacao/Login")
            });
        }
    }
}
