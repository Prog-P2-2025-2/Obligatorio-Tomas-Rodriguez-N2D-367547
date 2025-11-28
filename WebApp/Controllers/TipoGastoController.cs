using Dominio;
using Microsoft.AspNetCore.Mvc;
using WebApp.Filtros;

namespace WebApp.Controllers
{
    [Logueado]
    public class TipoGastoController : Controller
    {


        private Sistema _sistema = Sistema.Instancia();

        
        [HttpGet]
        [GerenteAdmin]
        public IActionResult AltaTipoGasto() 
        {
            ViewBag.TiposGastos = _sistema.TiposGastos();
            return View(new TipoGasto());
        }
        [HttpPost]
        public IActionResult AltaTipoGasto(TipoGasto tipoGasto) {
            try
            {
                _sistema.AltaTipoGasto(tipoGasto);
                return RedirectToAction("index", "Usuario", new { mensaje = $"Se dio de alta el Tipo de gasto:{tipoGasto.Nombre}, descripcion:{tipoGasto.Descripcion}" });
            }
            catch (Exception e)
            {
                ViewBag.mensaje = e.Message;
                return View(tipoGasto);
            }
        }
        [HttpGet]
        [GerenteAdmin]
        public IActionResult ListaTipoGasto(string mensaje)
        {
            ViewBag.TiposGastos = _sistema.TiposGastos();
            ViewBag.mensaje = mensaje;
            return View();
        }

        [HttpGet]
        public IActionResult EliminarTipoGasto(int idTipoGasto)
        {

            if (_sistema.TipoGastoEnUso(idTipoGasto))
            {
                return RedirectToAction("ListaTipoGasto", "TipoGasto", new { mensaje = $"No se puede elimina porque esta en uso" });
               
            }
            TipoGasto unTipoGasto =_sistema.EliminarTipoGasto(idTipoGasto);
            return RedirectToAction("index", "Usuario", new { mensaje = $"Se elimino correctamente el Tipo de Gasto {unTipoGasto.Nombre}" });
        }
    }
}
