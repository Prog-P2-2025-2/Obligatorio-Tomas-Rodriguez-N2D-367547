using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult VerPerfil()
        {
            Usuario unU = _sistema.ObtenerUsuario(1);
            return View(unU);
        }

    }
}
