using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Gerente : Usuario
    {
       
        public Gerente(string nombre, string apellido, string contrasenia, DateTime fechaIncorporacion, Equipo unEquipo) : base(nombre, apellido, contrasenia, fechaIncorporacion, unEquipo)
        {
        
        }
        public override string TipoUsuario()
        {
            return "Gerente";
        }
    }
}