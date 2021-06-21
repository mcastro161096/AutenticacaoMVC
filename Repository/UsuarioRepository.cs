using AutenticacaoMVC.IRepository;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.Context;
using AutenticacaoMVC.Models.ViewModels;
using AutenticacaoMVC.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AutenticacaoMVC.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        AutenticacaoMVCContext db = new AutenticacaoMVCContext();

        public bool Add(Usuario usuario)
        {
            try
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
        }

        public IEnumerable<Usuario> GetAll()
        {
            return db.Usuarios.ToList();
        }

        public Usuario Login(LoginViewModel login)
        {
            var senhacriptografada = HashService.GerarHash(login.Senha);
            var usuario = db.Usuarios.FirstOrDefault(l => l.Login == login.Login && l.Senha == senhacriptografada);
            
            return usuario;
        }

        public bool LoginExists(Usuario usuario)
        {
            if (db.Usuarios.Count(x => x.Login == usuario.Login) > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool AlterarSenha(Usuario usuario)
        {
            try
            {
                usuario.Senha = HashService.GerarHash(usuario.Senha);
                db.Entry(usuario).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch (Exception)
            {

                return false;
            }
            
        }

    }
}