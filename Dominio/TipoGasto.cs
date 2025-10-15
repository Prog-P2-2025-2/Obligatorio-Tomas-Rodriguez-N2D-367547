using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class TipoGasto
    {
        public int Id { get; set; }
        private static int _ultimoId = 0;
        public string Nombre { get; set; }
        public string Descripcion { get; set; }


        public TipoGasto(string nombre, string descripcion) {
            Id = _ultimoId++;
            Nombre = nombre;
            Descripcion = descripcion;
            Validar();
        }
        public void Validar()
        {
            ValidarNombre();  
            ValidarDescripcion();
        }

        private void ValidarNombre() {
            if (string.IsNullOrEmpty(Nombre))
            {
                throw new Exception("El nombre deL tipo de pago no puede ser vacio");
            }
        }
        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcion deL tipo de pago no puede ser vacio");
            }
        }

        public override string ToString()
        {
            return $"Nombre: {Nombre}\n" +
                   $"Descipcion: {Descripcion}\n"; ;
        }
        public override bool Equals(object obj)
        {
            TipoGasto unTipoGasto = obj as TipoGasto;
            return unTipoGasto != null && unTipoGasto.Nombre == Nombre;
        }
    }
}
