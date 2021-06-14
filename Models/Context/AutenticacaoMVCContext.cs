using System.Data.Entity;

namespace AutenticacaoMVC.Models.Context
{
    public class AutenticacaoMVCContext : DbContext
    {
        public AutenticacaoMVCContext() : base("Usuarios")
        {

        }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}