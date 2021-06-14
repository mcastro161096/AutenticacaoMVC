using AutenticacaoMVC.Models;

namespace AutenticacaoMVC.IRepository
{
    public interface IUsuarioRepository
    {
         bool Add(Usuario usuario);
    }
}
