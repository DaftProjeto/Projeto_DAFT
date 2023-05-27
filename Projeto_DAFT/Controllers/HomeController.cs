using System.Diagnostics;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Projeto_DAFT.Entidades;
using Projeto_DAFT.Models;

namespace Projeto_DAFT.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private Contexto contexto;

        public HomeController(ILogger<HomeController> logger, Contexto db)
        {
            _logger = logger;
            contexto = db;
        }

        

        public IActionResult Index()
        {
            return View();
        }


        [Authorize(AuthenticationSchemes = "CookieAuthentication")]
        public IActionResult Gerenciador_Atividades_Curriculares()
        {
            return View(contexto.Projeto.ToList());
        }




        //LOGIN E LOGOFF
        [HttpPost]
        public async Task<ActionResult> Login(string usuario, string senha)
        {
            UsuarioEntidade usuarioLogado = contexto.Usuario.Where(a => a.Nome == usuario && a.Senha == senha).FirstOrDefault();

            if(usuarioLogado == null) 
            {

                TempData["erro"] = "Usuário e senha inválidos";
                return RedirectToAction("Index");

            }
            
            var claims = new List<Claim>();
            claims.Add(new Claim(ClaimTypes.Name, usuarioLogado.Nome));
            claims.Add(new Claim(ClaimTypes.Sid, usuarioLogado.Id.ToString()));

            var userIdentity = new ClaimsIdentity(claims, "Acesso");
            
            ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);  
            await HttpContext.SignInAsync("CookieAuthentication", principal, new AuthenticationProperties());
            
            return Redirect("/Home");
        }

        public async Task<IActionResult> Logoff()
        {
            await HttpContext.SignOutAsync("CookieAuthentication");
            return Redirect("/Home");
        }

        //LOGIN E LOGOFF





        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }




        public IActionResult RegrasTCC()
        {
            return View();
        }

        public IActionResult RegrasAnteprojeto()
        {
            return View();
        }

    }
}