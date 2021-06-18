using AutenticacaoMVC.Iservices;
using AutenticacaoMVC.Models;
using AutenticacaoMVC.Models.ViewModels;
using AutenticacaoMVC.Services;
//using System;
using System.Web;
using System.Web.Mvc;

namespace AutenticacaoMVC.Controllers
{
    public class AutenticacaoController : Controller
    {
        IUsuarioService _usuarioService;
        IAutenticacaoService _autenticacaoService;
        public AutenticacaoController(IUsuarioService usuarioService, IAutenticacaoService autenticacaoService)
        {
            _usuarioService = usuarioService;
            _autenticacaoService = autenticacaoService;
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

                if (_usuarioService.LoginExists(usuario))
                {
                    ModelState.AddModelError("Login", "Esse login já está em uso.");
                    return View(viewModel);
                }

                if (_usuarioService.Add(usuario))
                {
                    return RedirectToAction("Index", "Home");
                }
            }
            return View(viewModel);
        }
        [HttpGet]
        public ActionResult Login(string ReturnUrl)
        {
           var viewModel = new LoginViewModel
            {
                UrlRetorno = ReturnUrl
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Login(LoginViewModel login)
        {
            if (!ModelState.IsValid)
            {
                return View(login);
            }
            var usuario = _usuarioService.Login(login);
            if (usuario != null)
            {
               var identity =  _autenticacaoService.CreateCooKie(usuario);
                Request.GetOwinContext().Authentication.SignIn(identity);
               // if (!String.IsNullOrWhiteSpace(login.UrlRetorno) || Url.IsLocalUrl(login.UrlRetorno))
                //{
                    return Redirect(login.UrlRetorno);
               // }
               // else
               // {
                   // return RedirectToAction("GetAll", "ListarUsuarios");
                //}
            }
            ModelState.AddModelError("Login", "Login ou senha inválidos");
            return View(login);
        }
    }
}