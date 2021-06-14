using AutenticacaoMVC.IRepository;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.Context;
using System;

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
    }
}