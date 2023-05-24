using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using Projeto_DAFT.Entidades;
using Projeto_DAFT.Models;


namespace Projeto_DAFT.Controllers
{
    public class CadastroController : Controller
    {
        private Contexto contexto;

        public CadastroController(Contexto db)
        {
            contexto = db;
        }


        // 
        public IActionResult Aluno()
        {
            return View();
        }

        [HttpPost]
        public IActionResult SalvarUsuario(UsuarioViewModel dados)
        {
            try
            {
                dados.Permissao = 0;
                contexto.Usuario.Add(dados);
                contexto.SaveChanges();

                //var id_user = contexto.Usuario.Id;
                var id_user = contexto.Usuario.OrderBy(x=>x.Id).LastOrDefault().Id;
                var val_RA = dados.RA;

                return RedirectToAction("CreateAluno", new { r=val_RA, u=id_user } );
            }
            catch(Exception ex)
            {
                TempData["erro"] = ex.Message+"  Inner: "+ex.InnerException;
                return RedirectToAction("Aluno");
            
            }
            
        }

        public ActionResult CreateAluno(string r, int u)
        {
            contexto.Database.ExecuteSqlRaw("INSERT INTO ALUNO (RA, ID_USUARIO) VALUES ('"+r+"', "+ u +")");
            contexto.SaveChanges();
            return RedirectToAction("TipoCadastro");
        }

        public IActionResult EditarUsuario(string id) 
        {
            return View();
        }

        public IActionResult TipoCadastro()
        {
            return View();
        }
    }
}
