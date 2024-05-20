using Microsoft.AspNetCore.Mvc;

namespace RegistroAduaneroDeBarcos.Web.Controllers;

    public class InicioController : Controller
    {
        public IActionResult Bienvenida()
        {
            return View();
        }
    }

