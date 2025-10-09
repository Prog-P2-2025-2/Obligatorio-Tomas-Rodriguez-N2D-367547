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
    }
}
