using Microsoft.AspNetCore.Mvc;

namespace Projeto_DAFT.Controllers
{
    public class AdminController : Controller
    {
        public IActionResult Cadastro()
        {
            return View();
        }
    }
}
