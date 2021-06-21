using System.Web.Mvc;

namespace AutenticacaoMVC.Controllers
{
    public class PerfilController : Controller
    {
        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }
    }
}