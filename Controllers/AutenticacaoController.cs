using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.ViewModels;
using System.Web.Mvc;

namespace AutenticacaoMVC.Controllers
{
    public class AutenticacaoController : Controller
    {
        IUsuarioService _usuarioService;
        public AutenticacaoController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpGet]
        public ActionResult Cadastrar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Cadastrar(CadastroUsuarioViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(viewModel);
            }
            else
            {
                Usuario usuario = new Usuario
                {
                    Nome = viewModel.Nome,
                    Login = viewModel.Login,
                    Senha = viewModel.Senha
                };
                
                _usuarioService.Add(usuario);
            }
            return RedirectToAction("Index", "Home");
        }
    }
}