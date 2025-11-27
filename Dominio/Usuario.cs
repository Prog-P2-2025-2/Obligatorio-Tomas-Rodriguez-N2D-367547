using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Usuario
    {
        public int Id { get; set; }
        private static int _ultimoId = 1;
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Contrasenia { get; set; }
        public string Email { get; set; }
        public DateTime FechaIncorporacion { get; set; }
        public Equipo UnEquipo { get; set; }


        public Usuario(string nombre, string apellido, string contrasenia, DateTime fechaIncorporacion, Equipo unEquipo) 
        {
            Id = _ultimoId++;
            Nombre = nombre;
            Apellido = apellido;
            Contrasenia = contrasenia;
            FechaIncorporacion = fechaIncorporacion;
            UnEquipo = unEquipo;

            Validar();

        }
        public void Validar()
        {
            ValidarNombre();
            ValidarApellido();
            ValidarContrasenia();
            ValidarEquipo();
            ValidarFechaIncorporacion();
        }
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("EL NOMBRE NO PUEDE SER VACIO");
            }
        }
        private void ValidarApellido () 
        {
            if (string.IsNullOrEmpty(Apellido))
            {
                throw new Exception("EL APELLIDO NO PUEDE SER VACIO");
            }
        }
        private void ValidarContrasenia()
        {
            if (Contrasenia.Length < 8) {
                throw new Exception("LA CONTRASEÑA DEBE DE TENER COMO MINIMO 8 CARACTERES");            
            }
        }

        private void ValidarEquipo() 
        {
            if (UnEquipo == null) 
            {
                throw new Exception("El equipo no puede ser nulo");
            }
        }
        private void ValidarFechaIncorporacion()
        {                   
            if (FechaIncorporacion == DateTime.MinValue)
            {
                throw new Exception("La fecha de incorporacion no puede estar vacía.");
            }
        }
        
        public string GenerarEmail(List<Usuario> usuarios)
        {
            string emailBaseNombre = Nombre;
            string emailBaseApellido = Apellido;
            string emailGenerado = "";
            string dominio = "@laEmpresa.com";

            if (Nombre.Length >= 3) emailBaseNombre = Nombre.Substring(0, 3);
            if (Apellido.Length >= 3) emailBaseApellido = Apellido.Substring(0, 3);

            emailGenerado += emailBaseNombre + emailBaseApellido + dominio;

            if (ExisteEmail(usuarios, emailGenerado))
            {
                emailGenerado = emailBaseNombre + emailBaseApellido + Id + dominio;
            }
           return emailGenerado;
        }

        private bool ExisteEmail(List<Usuario> usuarios, string mailGenerado) 
        {
            foreach (Usuario item in usuarios) {
                if (item.Email == mailGenerado) { return true; }
            
            }         
            return false;
        }




        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"Nombre: {Nombre}\n";
            respuesta += $"Apellido: {Apellido}\n";
            respuesta += $"Mail: {Email}\n";
            respuesta += $"Equipo: {UnEquipo.Nombre}\n";

            return respuesta;
        }
        public int IdEquipo()
        {
           return UnEquipo.Id;
        }
    }
}
