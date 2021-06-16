using AutenticacaoMVC.Models;

namespace AutenticacaoMVC.Iservices
{
    public interface IUsuarioService
    {
        bool Add(Usuario usuario);

        bool LoginExists(Usuario usuario);
    }
}
