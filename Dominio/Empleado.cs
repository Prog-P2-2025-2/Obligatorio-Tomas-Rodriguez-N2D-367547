using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Empleado : Usuario
    {
        public Empleado(string nombre, string apellido, string contrasenia, DateTime fechaIncorporacion, Equipo unEquipo) : base(nombre, apellido, contrasenia, fechaIncorporacion, unEquipo)
        {
        }
    }
}
