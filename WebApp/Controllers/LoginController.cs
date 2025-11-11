using Dominio;
using Microsoft.AspNetCore.Mvc;
using System.Text;

namespace WebApp.Controllers
{
    public class LoginController : Controller
    {
        private Sistema _sistema = Sistema.Instancia();

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(string email , string contrasenia)
        {
            try
            {
                Usuario unU = _sistema.ObtenerUsuario(email, contrasenia);
                if (unU is Gerente)
                {
                    HttpContext.Session.SetString("rol", "gerente");
                    HttpContext.Session.SetInt32("id", unU.Id);
                    return Redirect("~/Usuario/index");
                }
                if (unU is Empleado)
                {
                    HttpContext.Session.SetString("rol", "empleado");
                    HttpContext.Session.SetInt32("id", unU.Id);

                    return Redirect("~/Usuario/index");

                }
            }
            catch (Exception)
            {

                ViewBag.mensaje = "Usuario o contraseña incorrecta";
            }



            return View();
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Login");
        }

       



    }

}
