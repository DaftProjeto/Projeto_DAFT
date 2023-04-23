using Microsoft.AspNetCore.Mvc;

namespace Projeto_DAFT.Controllers
{
    public class AlunoController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
