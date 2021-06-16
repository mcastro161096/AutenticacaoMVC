using AutenticacaoMVC.IRepository;
using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models;

namespace AutenticacaoMVC.Services
{
    public class UsuarioService : IUsuarioService
    {
        IUsuarioRepository _usuarioRepository;
        public UsuarioService(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }
        public bool Add(Usuario usuario)
        {
            return _usuarioRepository.Add(usuario);
        }

        public bool LoginExists(Usuario usuario)
        {
           return _usuarioRepository.LoginExists(usuario);
        }
    }
}