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
            ViewBag.MontoTotal = _sistema.MontoTotal(unU);
            ViewBag.MontoTotalAplicado = _sistema.MontoTotalConRecargosODescuento(unU);
            ViewBag.ListaUsuarioDelEquipo = _sistema.ListarUsuarioDelEquipo(idUsuario);

            return View(unU);
        }

    }
}
