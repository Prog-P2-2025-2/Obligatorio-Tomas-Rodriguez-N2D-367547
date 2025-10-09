using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio
{
    public abstract class Pago
    {
        public int Id { get; set; }
        private static int _ultimoId = 0;
        public MetodoDePago MetodoDePago{ get; set; }
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

       
    }
}
