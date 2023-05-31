using System.Diagnostics;
using System.Runtime.Intrinsics.X86;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ActionConstraints;
using Microsoft.EntityFrameworkCore;
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

        public IActionResult Entrar()
        {
            return View();
        }
        public IActionResult ListarRegras()
        {
            return View(contexto.Regra.ToList());
        }

        public IActionResult RegrasAnteprojeto()
        {
            return View(contexto.Regra.Where(a=>a.Id != 8).ToList());
        }

        /*
         * 
         * COISAS Q TEM Q IR NO GERENCIADOR
         * @foreach (var item in Model)
            {
                <tr>
                    <td>@item.Curso</td>
                    <td>@item.Curso</td>
                    <td>@item.Curso</td>
                    <td>@item.Titulo</td>
                    <td>@item.Data_Envio</td>
                    <td><a data-target="#ModalAgendamento" data-toggle="modal" class="botaoImg"><img src="/Imagens/Aguardando icon.png" style="width:20px;" id="imgagen" /></a></td>
                    <td><a data-target="#ModalAprovado" data-toggle="modal" class="botaoImg"><img src="/Imagens/Aguardando icon.png" style="width:20px;" id="imgapro" /></a></td>
                    <td>

                        <a data-target="#myModal" data-toggle="modal">
                            <image type="button" src="/Imagens/eye.png" style="width:20px;height:30px;width:25px;float:right;margin-right:10px;" id="eyes" />
                        </a>
                    </td>
                    <td></td>
                </tr>
            }
        */


        [Authorize(AuthenticationSchemes = "CookieAuthentication")]
        public IActionResult Gerenciador_Atividades_Curriculares()
        {

            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;

            var Nome = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            //return View();
            //var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;
            //var Nome = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
            var Id = 2;
            //ProjetoEntidade model = contexto?.Projeto.Where(a => a.Id == Id).Include(a => a.Aluno).Include(a => a.Orientador).FirstOrDefault();
            List<ProjetoEntidade> model = contexto.Projeto.Where(a => a.Aluno.Usuario.Nome == @Nome).Include(a => a.Aluno).Include(a => a.Aluno.Usuario).Include(a => a.Professor).ToList();
            //model.Aluno.Usuario.Nome = "Teste";
            return View(model);

            /*
                @foreach (var modal in Model)
                {
                    modal.
                }
            */


            //var aux = contexto.Database.ExecuteSqlRaw("SELECT TITULO, CURSO FROM PROJETO WHERE ID = 1");
            //return View(aux);
            //return View(contexto.Projeto.Include(a => a.Aluno).ToList());
            /*return View(contexto.Database.ExecuteSqlRaw("" +
               "SELECT p.Titulo, p.Curso, p.Tipo, p.Turno, p.Caminho, p.Data_Envio," +
               "a.Nome, a.RA, po.Nome, s.Ano" +
               " FROM PROJETO p" +
               "INNER JOIN ALUNO a on p.ID_Aluno = a.ID" +
               "INNER JOIN PROF_ORIENTADOR po on p.ID_Orientador = po.ID" +
               "INNER JOIN SEMESTRE s ON p.ID_Semestre = s.ID" +
               "INNER JOIN USUARIO u ON a.ID_Usuario = u.ID AND po.ID_Usuario = u.ID"
           ));*/
        }

        /*public ActionResult geraDados(int id)
        {
            var resultado = contexto.Projeto.
            Select(x => new ProjetoViewModel()
            {
                Titulo = x.Titulo.ToString(),

            }).ToList();
            return RedirectToAction("Index");
        }*/



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


        [HttpPost]
        public ActionResult SalvarProjeto(ProjetoViewModel dados)
        { 
            //contexto.Projeto.Add(dados);
            //contexto.SaveChanges();
            return View("/Home/Gerenciador_Atividades_Curriculares");
        }








        


        public IActionResult AltRegras()
        {
            return View(contexto.Regra.ToList());
        }



        



        public IActionResult CriarRegra()
        {
            return View();
        }

        public IActionResult Create(RegraEntidade collection)
        {
            try

            {

                contexto.Regra.Add(collection);

                contexto.SaveChanges();

                return RedirectToAction(nameof(AltRegras));

            }

            catch

            {

                return View();

            }

        }


        [HttpGet]
        public IActionResult AlterarRegra(int id)
        {
            //var aux = contexto.Regra.Where(x=> x.Id == id).ToList();
            return View(contexto.Regra.Where(x => x.Id == id).ToList());

        }

        [HttpGet]
        public IActionResult SalvarAlteracao(int id, IFormCollection collection)
        {

            //contexto.Regra.Update(aux);
            return View("Home/ListarRegras");
        }

        [HttpGet]
        public ActionResult RemoverRegra(int id)

        {
            contexto.Regra.Remove(contexto.Regra.Where(a => a.Id == id).FirstOrDefault());
            contexto.SaveChanges();
            return View("/Home/ListarRegras");
        }
    }
}