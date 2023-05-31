using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Projeto_DAFT.Entidades;
using Projeto_DAFT.Models;

namespace Projeto_DAFT.Controllers
{
    public class EnviarController : Controller
    {
        private Contexto contexto;

        public EnviarController(Contexto db)
        {
            contexto = db;
        }
        public IActionResult EnviarAnteprojeto(int id)
        {
            var claimsIdentity = User.Identity as System.Security.Claims.ClaimsIdentity;

            var Nome = claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Name)?.Value;
            var Id = int.Parse(claimsIdentity.FindFirst(System.Security.Claims.ClaimTypes.Sid)?.Value);

            //var aux = contexto.Usuario.Find(Nome);

            //FUNCIONANDO
            //List<ProfessorEntidade> model = contexto.Professor.Include(a => a.Usuario).ToList();

            //var usuario = contexto.Aluno.Find(Nome);
            //var usuario = contexto.Aluno.Where(a=>a.Usuario.Nome == Nome);

            var usuario = contexto.Aluno.Include(a => a.Usuario).FirstOrDefault(a=>a.UsuarioId == Id);

            EnviarViewModel model = new EnviarViewModel
            {
                Aluno = usuario,
                Usuario = usuario.Usuario,
                ListaProfessor = contexto.Professor.Include(a=>a.Usuario).ToList()
            };
            
            //contexto.Professor.Include(a => a.Usuario).ToList(), contexto.Aluno.Include(a => a.Usuario).ToList()
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
