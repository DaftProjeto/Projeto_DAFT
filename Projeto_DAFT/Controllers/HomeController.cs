﻿using System.Diagnostics;
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


        [Authorize(AuthenticationSchemes = "CookieAuthentication")]
        public IActionResult Gerenciador_Atividades_Curriculares()
        {
            var aux = contexto.Database.ExecuteSqlRaw("SELECT TITULO, CURSO FROM PROJETO WHERE ID = 1");
            return View(aux);
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