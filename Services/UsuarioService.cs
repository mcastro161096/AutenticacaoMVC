using AutenticacaoMVC.IRepository;
using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.ViewModels;
using System.Collections.Generic;

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

        public IEnumerable<Usuario> GetAll()
        {
            return _usuarioRepository.GetAll();
        }

        public Usuario Login(LoginViewModel login)
        {
           return _usuarioRepository.Login(login);
        }

        public bool LoginExists(Usuario usuario)
        {
           return _usuarioRepository.LoginExists(usuario);
        }

        public bool AlterarSenha(Usuario usuario)
        {
            return _usuarioRepository.AlterarSenha(usuario);
        }
    }
}