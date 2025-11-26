using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class UsuarioController : Controller
    {
        private Sistema _sistema = Sistema.Instancia();

        public IActionResult Index(string mensaje)
        {
            ViewBag.mensaje=mensaje;
            return View();
        }

        public IActionResult VerPerfil(int idUsuario)
        {
            Usuario unU = _sistema.ObtenerUsuario(idUsuario);
           // int montoTotalEsteMes = _sistema.MontoTotalPorUsuario();

            return View(unU);
        }

    }
}
