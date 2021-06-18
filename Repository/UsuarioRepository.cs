using AutenticacaoMVC.IRepository;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.Context;
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
    }
}