using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_DAFT.Entidades;

namespace Projeto_DAFT.Controllers
{
    public class EnviarController : Controller
    {
        private Contexto contexto;

        public EnviarController(Contexto db)
        {
            contexto = db;
        }
        public IActionResult EnviarAnteprojeto()
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;

            var Nome = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;

            //var aux = contexto.Usuario.Find(Nome);

            List<ProfessorEntidade> model = contexto.Professor.Include(a => a.Usuario).ToList();
            return View(model);
        }

        public IActionResult EnviarTCC()
        {
            return View();
        }

        public IActionResult EnviarTCCPage2()
        {
            return View();
        }


        [HttpPost]
        public ActionResult EnvioProjeto(ProjetoEntidade proj)
        {
            var aux = contexto.Usuario.Find(proj.AlunoId);
            proj.Caminho = "Usuarios/" + aux.Id + "_Aluno"  + "/Arquivos/"+ proj.Caminho;
            contexto.Projeto.Add(proj);
            contexto.SaveChanges();
            return Redirect("/Home/Gerenciador_Atividades_Curriculares");
        }
    }
}
