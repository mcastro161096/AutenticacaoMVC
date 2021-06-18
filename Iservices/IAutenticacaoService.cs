using AutenticacaoMVC.Models;
using System.Security.Claims;

namespace AutenticacaoMVC.Iservices
{
    public interface IAutenticacaoService
    {
        ClaimsIdentity CreateCooKie(Usuario usuario);
    }
}
