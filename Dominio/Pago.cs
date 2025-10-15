using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Pago
    {
        public int Id { get; set; }
        private static int _ultimoId = 0;
        public MetodoDePago MetodoDePago { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }

        public Pago(MetodoDePago metodoDePago, TipoGasto tipoGasto, Usuario usuario, string descripcion, int monto)
        {
            Id = _ultimoId++;
            MetodoDePago = metodoDePago;
            TipoGasto = tipoGasto;
            Usuario = usuario;
            Descripcion = descripcion;
            Monto = monto;
            
        }
        public virtual void Validar()
        {
            ValidarTipoGasto();
            ValidarDescripcion();
            ValidarMonto();
            ValidarUsuario();

        }
        private void ValidarTipoGasto()
        {
            if (TipoGasto == null)
            {
                throw new Exception("Tipo de gasto no puede ser nulo");
            }
        }
        private void ValidarUsuario()
        {
            if (Usuario == null)
            {
                throw new Exception("Usuario no puede ser nulo");
            }
        }
        private void ValidarMonto() 
        {
            if (Monto <= 0) 
            {
                throw new Exception("El monto no puede ser menor o igual a 0 ");
            }
        }
        private void ValidarDescripcion()
        {
            if (string.IsNullOrEmpty(Descripcion))
            {
                throw new Exception("La descripcion no puede ser vacia");
            }
        }
        public abstract string MensajePago();

        public override string ToString()
        {
            return $"Metodo: {MetodoDePago}\n" +
                    $"Nombre: {MensajePago()}\n";
        }

        
    }
}
