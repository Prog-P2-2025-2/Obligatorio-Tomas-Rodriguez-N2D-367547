using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
