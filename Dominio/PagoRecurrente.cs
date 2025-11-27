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
        public override bool PagoVigenteEsteMes() { 
            if (FechaFinal.Year > DateTime.Now.Year) {
                return true;
            }
            if (FechaFinal.Year == DateTime.Now.Year &&  FechaFinal.Month >= DateTime.Now.Month) 
            {
                return true;
            }
            
        
            return false;
        }

        public override DateTime FechaEsteMes()
        {

            return new DateTime(DateTime.Now.Year, DateTime.Now.Month, FechaFinal.Day);
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
        public override string MensajePago()
        {           
            return $"Fecha de inicio: {Descripcion}" +
                $"Fecha de inicio: {FechaInicio.ToString("dd/MM/yyyy")}" +
                    $"Fecha final: {FechaFinal.ToString("dd/MM/yyyy")}";
        }
        public override bool PagoValidoFecha(DateTime fechaInicial, DateTime fechaFinal)
        {
            if (FechaInicio <= fechaFinal && FechaFinal >= fechaInicial)
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
