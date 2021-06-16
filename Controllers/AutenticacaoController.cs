using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.ViewModels;
using AutenticacaoMVC.Services;
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
                    Senha = HashService.GerarHash(viewModel.Senha)
                };

                if (_usuarioService.Add(usuario))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }
    }
}