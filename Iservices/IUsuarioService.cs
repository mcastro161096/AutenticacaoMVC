using AutenticacaoMVC.Models;
using System.Collections.Generic;

namespace AutenticacaoMVC.Iservices
{
    public interface IUsuarioService
    {
        bool Add(Usuario usuario);

        IEnumerable<Usuario> GetAll();

        bool LoginExists(Usuario usuario);
    }
}
