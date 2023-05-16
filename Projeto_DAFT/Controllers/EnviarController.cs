using Microsoft.AspNetCore.Mvc;

namespace Projeto_DAFT.Controllers
{
    public class EnviarController : Controller
    {
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
    }
}
