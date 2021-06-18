using AutenticacaoMVC.Models;
using System.Collections.Generic;

namespace AutenticacaoMVC.IRepository
{
    public interface IUsuarioRepository
    {
        bool Add(Usuario usuario);

        IEnumerable<Usuario> GetAll();

        bool LoginExists(Usuario usuario);
    }
}
