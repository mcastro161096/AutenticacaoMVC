using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;

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
