using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models;
using System.Security.Claims;

namespace AutenticacaoMVC.Services
{
    public class AutenticacaoService : IAutenticacaoService
    {
        public ClaimsIdentity CreateCooKie(Usuario usuario)
        {
            var identity = new ClaimsIdentity(new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nome),
                new Claim("Login", usuario.Login)
            }, "ApplivationCookie");
            return identity;
        }
    }
}