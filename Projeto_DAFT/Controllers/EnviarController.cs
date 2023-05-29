using Microsoft.AspNetCore.Mvc;
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
            return View();
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
            proj.Caminho = "Usuarios/" + aux.Nome+ "/Arquivos/"+ proj.Caminho;
            contexto.Projeto.Add(proj);
            contexto.SaveChanges();
            return Redirect("/Home/Gerenciador_Ativades_Curriculares");
        }
    }
}
