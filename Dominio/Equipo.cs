using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class Equipo
    {
        public int Id { get; set; }
        private static int _ultimoId = 0;
        public string Nombre { get; set; }
        public Equipo(string nombre)
        {

            Id = _ultimoId++;
            Nombre = nombre;
            Validar();
        }

        public void Validar()
        {
            ValidarNombre();

        }
        private void ValidarNombre()
        {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre del equipo no puede ser vacio");
            }

        }


        public override bool Equals(object obj)
        {
            Equipo unE = obj as Equipo;
            return unE != null && unE.Nombre == Nombre;
        }
        public override string ToString()
        {
            string respuesta = string.Empty;
            respuesta += $"-Id:{Id} Nombre{Nombre}";
            return respuesta;
        }

    }
}
