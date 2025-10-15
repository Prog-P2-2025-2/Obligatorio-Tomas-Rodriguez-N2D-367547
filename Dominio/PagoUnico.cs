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

        public override string MensajePago()
        {
            return $"Fecha de Pago: {FechaPago}\n"+
                    $"Numero de recibo: {NroRecibo}\n";
        }
       
       


    }
}
