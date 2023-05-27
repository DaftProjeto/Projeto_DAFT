using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.WebEncoders.Testing;
using Projeto_DAFT.Entidades;
using Projeto_DAFT.Models;
using System.Reflection.Metadata.Ecma335;

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
        public IActionResult Professor()
        {
            return View();
        }
        public IActionResult Administrador()
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

                if(dados.tipo==1)
                {
                    var userC = dados.RA;
                    return RedirectToAction("CreateAluno", new { r = userC, u = id_user});
                }
                else if (dados.tipo==2 || dados.tipo == 3)
                {
                    var userC = dados.Lattes;
                    return RedirectToAction("CreateProfessor", new {r = userC, u = id_user, tipo = dados.tipo});
                }
                else 
                { 
                    return RedirectToAction("Home/Index"); 
                } 
                
               
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

        public ActionResult CreateProfessor(string r, int u, int tipo)
        {

            if (tipo == 2)
            {
                contexto.Database.ExecuteSqlRaw("INSERT INTO PROFESSOR (Matricula, ID_Usuario) VALUES ('" + r + "', " + u + ")");
                contexto.SaveChanges();
                var id_prof = contexto.Professor.OrderBy(x => x.ID).LastOrDefault().ID;
                contexto.Database.ExecuteSqlRaw("INSERT INTO PROF_BANCA (ID_Professor) VALUES (" + id_prof + ");");
                contexto.SaveChanges();
            }
            else if(tipo == 3) 
            {
                contexto.Database.ExecuteSqlRaw("INSERT INTO PROFESSOR (Matricula, ID_Usuario) VALUES ('" + r + "', " + u + ")");
                contexto.SaveChanges();
                var id_prof = contexto.Professor.OrderBy(x => x.ID).LastOrDefault().ID;
                contexto.Database.ExecuteSqlRaw("INSERT INTO PROF_ORIENTADOR (ID_Professor) VALUES (" + id_prof + ");");
                contexto.SaveChanges();
            }
            else
            {
                return RedirectToAction("Home/Index");
            }
            contexto.SaveChanges();
            return RedirectToAction("TipoCadastro");
        }

        [Authorize(AuthenticationSchemes = "CookieAuthentication")]
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
