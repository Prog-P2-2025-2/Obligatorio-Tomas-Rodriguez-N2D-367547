using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public abstract class Pago : IComparable<Pago>
    {
        public int Id { get; set; }
        private static int _ultimoId = 1;
        public MetodoDePago MetodoDePago { get; set; }
        public TipoGasto TipoGasto { get; set; }
        public Usuario Usuario { get; set; }
        public string Descripcion { get; set; }
        public int Monto { get; set; }

        public Pago()
        {
            
        }

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
            ValidarMetodoDePago();

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
        private void ValidarMetodoDePago()
        {
            if (!Enum.IsDefined(typeof(MetodoDePago), MetodoDePago))
            {
                throw new Exception("El método de pago no es válido o está vacío");
            }
        }
        public abstract string MensajePago();
        public abstract bool PagoVigenteEsteMes();
        public abstract DateTime FechaEsteMes();
        public abstract decimal DescuentoYRecargo();
        public abstract int CalcularMesesDeFechas();
        public override string ToString()
        {
            
            return $"Metodo de Pago: {MetodoDePago}\n" +
                   $"Descripcion: {Descripcion}\n" +
                   $"Monto a pagar: {Monto}\n" +
                   $"Numero de recibo: {TipoGasto.Nombre}\n" +
                   $"{MensajePago()}\n";
        }
        public int CompareTo(Pago? other) {

            if (other == null)
            {
                return -1;
            }
            return Monto.CompareTo(other.Monto) * -1;


        }
    }
}
