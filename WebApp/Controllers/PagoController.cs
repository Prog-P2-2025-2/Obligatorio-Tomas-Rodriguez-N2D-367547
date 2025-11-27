using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;

namespace WebApp.Controllers
{
    public class PagoController : Controller
    {
        private Sistema _sistema = Sistema.Instancia();
        

        public IActionResult VerPagoCargadosEsteMes(int idUsuario)
        {
           ViewBag.Pagos = _sistema.ListarPagosDeEsteMesPorIdUsuairo(idUsuario);
           return View();
        }
        public IActionResult VerPagosDeEquipo(int idUsuario)
        {
            ViewBag.Equipo = _sistema.ObtenerEquipoDeUsuario(idUsuario);
            ViewBag.PagosDelEquipo = _sistema.ListarPagosPorEquipo(idUsuario);
            return View();
        }
        public IActionResult BuscarPagos(DateTime fechaInicial, DateTime fechaFinal, int idUsuario)
        {
            ViewBag.PagosDelEquipo = _sistema.BuscarPagosPorFechas(fechaInicial, fechaFinal, idUsuario);
            return View("VerPagosDeEquipo");
        }
        [HttpGet]
        public IActionResult PagoUnico() {
        ViewBag.TiposGastos = _sistema.TiposGastos();
        return View(new PagoUnico());
        }

        [HttpPost]
        public IActionResult PagoUnico(PagoUnico pagoUnico, int idTipoGasto, MetodoDePago metodoDePago, int idUsuario) {

            try
            {
                
                pagoUnico.TipoGasto = _sistema.ObtenerTipoGasto(idTipoGasto);
                pagoUnico.Usuario = _sistema.ObtenerUsuario(idUsuario);
                pagoUnico.MetodoDePago = metodoDePago;
                if (pagoUnico.TipoGasto == null)
                {
                    throw new Exception("No existe el cargo");
                }

                _sistema.AltaPago(pagoUnico);
                return RedirectToAction("index", "Usuario", new { mensaje = $"Se cargo el pago unico {pagoUnico.Descripcion} y monto {pagoUnico.Monto}" });
            }
            catch (Exception e)
            {
                ViewBag.TiposGastos = _sistema.TiposGastos();
                ViewBag.mensaje = e.Message;
                return View(pagoUnico);
                
            }
        
        }

        [HttpGet]
        public IActionResult PagoRecurrente() {

            ViewBag.TiposGastos = _sistema.TiposGastos();
            return View(new PagoRecurrente());

        }
        [HttpPost]
        public IActionResult PagoRecurrente(PagoRecurrente pagoRecurrente, int idTipoGasto, MetodoDePago metodoDePago, int idUsuario)
        {
            try
            {

                pagoRecurrente.TipoGasto = _sistema.ObtenerTipoGasto(idTipoGasto);
                pagoRecurrente.Usuario = _sistema.ObtenerUsuario(idUsuario);
                pagoRecurrente.MetodoDePago = metodoDePago;
                if (pagoRecurrente.TipoGasto == null)
                {
                    throw new Exception("No existe el cargo");
                }
                _sistema.AltaPago(pagoRecurrente);
                return RedirectToAction("index", "Usuario", new { mensaje = $"Se cargo el pago recurrente {pagoRecurrente.Descripcion}" });
            }
            catch (Exception e)
            {
                ViewBag.TiposGastos = _sistema.TiposGastos();
                ViewBag.mensaje = e.Message;
                return View(pagoRecurrente);

            }


        }


    }
}
