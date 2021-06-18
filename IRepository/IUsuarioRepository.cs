using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.ViewModels;
using System.Collections.Generic;

namespace AutenticacaoMVC.IRepository
{
    public interface IUsuarioRepository
    {
        bool Add(Usuario usuario);

        IEnumerable<Usuario> GetAll();

        Usuario Login(LoginViewModel login);

        bool LoginExists(Usuario usuario);
    }
}
