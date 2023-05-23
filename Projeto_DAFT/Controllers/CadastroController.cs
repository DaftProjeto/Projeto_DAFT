using Microsoft.AspNetCore.Mvc;
using Projeto_DAFT.Entidades;

namespace Projeto_DAFT.Controllers
{
    public class CadastroController : Controller
    {
        private Contexto contexto;

        public CadastroController(Contexto db)
        {
            contexto = db;
        }


        [HttpPost]
        public IActionResult Aluno()
        {
            return RedirectToAction("SalvarUsuario");
        }

        
        public IActionResult SalvarUsuario(UsuarioEntidade dados, AlunoEntidade dados2)
        {
            contexto.Usuario.Add(dados);
            contexto.Aluno.Add(dados2);
            contexto.SaveChanges();
            return RedirectToAction("./Home/");
        }

        public IActionResult EditarUsuario(string id) 
        {
            return View();
        }
    }
}
