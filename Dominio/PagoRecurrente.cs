using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public class PagoRecurrente : Pago
    {

        public DateTime FechaInicio { get; set; }
        public DateTime FechaFinal { get; set; }


        public PagoRecurrente(DateTime fechaInicio,DateTime fechaFinal,MetodoDePago metodoDePago, TipoGasto tipoGasto, Usuario usuario, string descripcion, int monto) : base(metodoDePago, tipoGasto, usuario, descripcion, monto)
        {
            FechaInicio = fechaInicio;
            FechaFinal = fechaFinal;
        }
        public override void Validar()
        {
            base.Validar();
            ValidarFechaInicio();
            ValidarFechaFinal();
        }
        private void ValidarFechaInicio()
        {
            if (FechaInicio == default)
            {
                throw new Exception("La fecha de inicio no puede estar vacía.");
            }

        }
        private void ValidarFechaFinal()
        {
            if (FechaFinal == default)
            {
                throw new Exception("La fecha final no puede estar vacía.");
            }

            if (FechaFinal < FechaInicio)
            {
                throw new Exception("La fecha final no puede ser anterior a la fecha de inicio.");
            }

        }
        public override bool PagoVigenteEsteMes() { 
            if (FechaInicio.Month >= DateTime.Now.Month && FechaFinal.Month <= DateTime.Now.Month && FechaFinal.Year >= DateTime.Now.Year) {
                return true;
            }
            
        
            return false;
        }
        public override DateTime Fecha()
        {
            return FechaFinal;
        }

        public override string MensajePago()
        {
            return $"Fecha de inicio: {FechaInicio.ToString("dd/MM/yyyy")}\n" +
                    $"Fecha final: {FechaFinal.ToString("dd/MM/yyyy")}\n";
        }
//        public override DateTime FechaPagoActual() {  
  //          
    //        if (FechaFinal >= DateTime.Now )
      //      return FechaFinal; 
        
        //}
    }
}
