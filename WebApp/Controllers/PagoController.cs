using Dominio;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Controllers
{
    public class PagoController : Controller
    {
        private Sistema _sistema = Sistema.Instancia();
        
        public IActionResult VerPagoCargados(int id)
        {
            
           // ViewBag.PagosUnicos = _sistema.ListarPagosUnicosPorIdDeUsuario(id);
           // ViewBag.PagosRecurrentes = _sistema.ListarPagosRecurrentePorIdDeUsuario(id);
           ViewBag.Pagos = _sistema.ListarPagosPorIdDeUsuario(id);
            return View();
        }
    }
}
