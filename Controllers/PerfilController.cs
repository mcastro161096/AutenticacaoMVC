using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Web.Mvc;

namespace AutenticacaoMVC.Controllers
{
    public class PerfilController : Controller
    {
        IUsuarioService _usuarioService;
        public PerfilController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [Authorize]
        public ActionResult AlterarSenha()
        {
            return View();
        }
        [Authorize]
        [HttpPost]
        public ActionResult AlterarSenha(AlterarSenhaViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            var identity = User.Identity as ClaimsIdentity;
            var login = identity.Claims.FirstOrDefault(c => c.Type == "Login").Value;
            LoginViewModel loginViewModel = new LoginViewModel
            {
                Login = login,
                Senha = viewModel.SenhaAtual
            };
            var usuario = _usuarioService.Login(loginViewModel);
            if (usuario == null)
            {
                ModelState.AddModelError("SenhaAtual", "Senha incorreta");
                return View();
            }
            usuario.Senha = viewModel.NovaSenha;
            _usuarioService.AlterarSenha(usuario);

            return RedirectToAction("Index", "ListarUsuarios");
        }
    }
}