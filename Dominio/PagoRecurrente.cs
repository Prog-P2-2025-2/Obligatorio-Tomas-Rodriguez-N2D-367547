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

        public PagoRecurrente(){}
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

            if (FechaFinal < FechaInicio && FechaFinal != new DateTime())
            {
                throw new Exception("La fecha final no puede ser anterior a la fecha de inicio.");
            }

        }
        public override string MensajePago()
        {
            return $"Fecha de inicio: {Descripcion}" +
                $"Fecha de inicio: {FechaInicio.ToString("dd/MM/yyyy")}" +
                    $"Fecha final: {FechaFinal.ToString("dd/MM/yyyy")}";
        }
        public override bool PagoVigenteEsteMes() {
          
            DateTime mesInicio = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);

           
            DateTime mesFin = mesInicio.AddMonths(1).AddDays(-1);

            if (this.FechaFinal == new DateTime())
            {
                if (this.FechaInicio >= mesInicio && this.FechaInicio <= mesFin)
                {
                    return true;
                }

                return false;
            }

            if (this.FechaInicio <= mesFin && this.FechaFinal >= mesInicio)
            {
                return true;
            }

            return false;
        }

        public override DateTime FechaEsteMes()
        {

            return FechaInicio;
        }
        public override int CalcularMesesDeFechas()
        {
            int meses = (FechaFinal.Year - FechaInicio.Year) * 12 +
            (FechaFinal.Month - FechaInicio.Month);

            if (FechaFinal.Day < FechaInicio.Day)
            {
                meses--;
            }

            return meses;
        }
        public override decimal DescuentoYRecargo() 
        {

           
            if (CalcularMesesDeFechas() >= 10 )
            {
                return (decimal)Monto * (decimal)1.1;
            }
            if(CalcularMesesDeFechas() >6 && CalcularMesesDeFechas() <= 9)
            {
                return (decimal)Monto * (decimal)1.05;
            }
            if (CalcularMesesDeFechas() < 5)
            {
                return (decimal)Monto * (decimal)1.03;
            }
            return (decimal)Monto * (decimal)1.03;
        }
    
        public override bool PagoValidoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            if (FechaInicio >= fechaInicial && FechaFinal <= fechaFinal)
            {
                return true;
            }
            
            if (FechaFinal == new DateTime() && FechaInicio >= fechaInicial)
            {
                return true;
            }
            return false;
        }
        public override string TipoDePago()
        {
            return "Pago Recurrente";
        }
    }
}
