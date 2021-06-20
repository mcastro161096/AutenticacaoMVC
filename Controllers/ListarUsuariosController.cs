using AutenticacaoMVC.Iservices;
using System.Web.Mvc;

namespace AutenticacaoMVC.Controllers
{
    public class ListarUsuariosController : Controller
    {
        IUsuarioService _usuarioService;
        public ListarUsuariosController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize]
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult GetAll()
        {
            var usuarios = _usuarioService.GetAll();
            return View(usuarios);
        }
    }
}