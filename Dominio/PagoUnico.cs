using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class PagoUnico : Pago
    {
        public DateTime FechaPago{ get; set; }
        public string NroRecibo { get; set; }

        public PagoUnico() { }

        public PagoUnico(DateTime fechaPago, string nroRecibo, MetodoDePago metodoDePago, TipoGasto tipoGasto, Usuario usuario, string descripcion, int monto)
            : base(metodoDePago, tipoGasto, usuario, descripcion, monto)
        {
            FechaPago = fechaPago;
            NroRecibo = nroRecibo;
        }

        public override void Validar()
        {
            base.Validar();
            ValidarFechaPago();
            ValidarNroRecibo();
        }

        private void ValidarFechaPago()
        {    
            if (FechaPago == DateTime.MinValue)
            {
                throw new Exception("La fecha de pago no puede estar vacía.");
            }
        }
        private void ValidarNroRecibo() 
        {
            if (string.IsNullOrEmpty(NroRecibo)) {
                throw new Exception("Numero de recibo no puede ser vacio");
            }        
        }
        public override bool PagoVigenteEsteMes()
        {
            if (FechaPago.Month == DateTime.Now.Month && FechaPago.Year == DateTime.Now.Year)
            {
                return true;
            }


            return false;
        }

        public override DateTime FechaEsteMes()
        {
            return FechaPago;
        }
        public override string MensajePago()
        {   
            return  $"Numero de recibo: {NroRecibo}\n" +
                    $"Fecha de Pago: {FechaPago.ToString("dd/MM/yyyy")}\n";                                       
        }
        public override int CalcularMesesDeFechas() 
        {
            return 0;
        
        }
        public override decimal DescuentoYRecargo()
        {
            decimal montoCalculado = Monto;
            if (MetodoDePago == MetodoDePago.EFECTIVO)
            {
                return Monto - ((decimal)Monto * (decimal)0.15);
            }

            return Monto - ((decimal)Monto * (decimal)0.10);
        }
        public override bool PagoValidoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            if (FechaPago >= fechaInicial && FechaPago <= fechaFinal)
            {
                return true;
            }
           
            return false;
        }
        public override string TipoDePago()
        {
            return "Pago Unico";
        }
    }
}
