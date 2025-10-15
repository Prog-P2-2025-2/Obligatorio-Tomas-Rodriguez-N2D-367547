using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Dominio
{
    public class Sistema
    {
        private List<Pago> _pagos = new List<Pago>();
        private List<Usuario> _usuarios = new List<Usuario>();
        private List<Equipo> _equipos = new List<Equipo>();
        private List<TipoGasto> _tiposGastos = new List<TipoGasto>();
        public Sistema() { }
    
        public void PreCarga()
        {
            PreCargaEquipo();
            PreCargaUsuario();
            PreCargaTipoPago();
            PreCargaPagos();

        }

        private void PreCargaUsuario() 
        {
            AltaUsuario(new Usuario("Juan", "Perez", "123456789", new DateTime (2025, 10, 20), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Lucía", "Gómez", "123456789", new DateTime(2025, 9, 15), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Lucía", "Gómez", "123456789", new DateTime(2025, 9, 15), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Lucía", "Gómez", "123456789", new DateTime(2025, 9, 15), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Ca", "Rodríguez", "123456789", new DateTime(2025, 8, 10), ObtenerEquipo(3)));
            AltaUsuario(new Usuario("Sofía", "Fernández", "123456789", new DateTime(2025, 7, 5), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Martín", "Silva", "123456789", new DateTime(2025, 6, 25), ObtenerEquipo(2)));
        }
        private void PreCargaEquipo() 
        {
            AltaEquipo(new Equipo("EQUIPO 1"));
            AltaEquipo(new Equipo("EQUIPO 2"));
            AltaEquipo(new Equipo("EQUIPO 3"));
            AltaEquipo(new Equipo("EQUIPO 4"));
            AltaEquipo(new Equipo("EQUIPO 5"));

        }
        private void PreCargaTipoPago()
        {
            AltaTipoGasto(new TipoGasto("AUTO", "Pago de nafta, arreglos, mantenimiento del vehículo"));
            AltaTipoGasto(new TipoGasto("COMIDA", "Gastos únicos por almuerzos, cenas o salidas gastronómicas"));
            AltaTipoGasto(new TipoGasto("ENTRADA CINE", "Compra de entradas para películas o espectáculos"));
            AltaTipoGasto(new TipoGasto("REGALO", "Obsequios para eventos o personas"));
            AltaTipoGasto(new TipoGasto("REPARACIÓN PC", "Arreglo puntual de equipos informáticos"));
            AltaTipoGasto(new TipoGasto("NETFLIX", "Suscripción mensual a plataforma de streaming"));
            AltaTipoGasto(new TipoGasto("GYM", "Membresía mensual de gimnasio"));
            AltaTipoGasto(new TipoGasto("CELULAR", "Pago mensual del plan de telefonía móvil"));
            AltaTipoGasto(new TipoGasto("LICENCIA SOFTWARE", "Suscripción mensual a software como Adobe o Microsoft"));
            AltaTipoGasto(new TipoGasto("ELECTRODOMÉSTICO", "Compra en cuotas de electrodomésticos"));
        }
        private void PreCargaPagos() 
        {
            AltaPago(new PagoUnico(new DateTime(2025,10,20),"A23S",MetodoDePago.EFECTIVO, ObtenerTipoGasto(0),ObtenerUsuario(0),"COSO", 200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 10, 20), new DateTime(2025, 10, 21), MetodoDePago.DEBITO, ObtenerTipoGasto(0), ObtenerUsuario(0), "COSO COSO", 1000));

        }

        public void AltaUsuario(Usuario usuario)
        {
            if (usuario == null) 
            {
                throw new Exception("El Usuario no puede ser nulo");
            }
            //if (_usuarios.Contains(usuario)) { 
            
              //  throw new Exception ("EL usuario ya existe");
            //}
            usuario.Email = usuario.GenerarEmail(_usuarios);
            usuario.Validar();
            _usuarios.Add(usuario);

        }

        public void AltaEquipo(Equipo equipo)
        {
            if (equipo == null)
            {
                throw new Exception("El Equipo no puede ser nulo");
            }
            equipo.Validar();
            if (_equipos.Contains(equipo)) { 

              throw new Exception ("EL equipo ya existe");
            }
            _equipos.Add(equipo);
        }

        public void AltaTipoGasto(TipoGasto tipoGasto)
        {
            if (tipoGasto == null)
            {
                throw new Exception("El tipo de gato no puede ser nulo");
            }
            tipoGasto.Validar();
            if (_tiposGastos.Contains(tipoGasto)) 
            {
                throw new Exception("El tipo de gasto ya existe");
            }
            _tiposGastos.Add(tipoGasto);
        }

        public void AltaPago(Pago pago)
        {
            if (pago== null)
            {
                throw new Exception("El pago no puede ser nulo");
            }
            pago.Validar();
            _pagos.Add(pago);
        }

        public Equipo ObtenerEquipo(int id)
        {
            foreach (Equipo item in _equipos)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public TipoGasto ObtenerTipoGasto(int id)
        {
            foreach (TipoGasto item in _tiposGastos)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }
        public Equipo ObtenerEquipo(string nombre)
        {
            foreach (Equipo item in _equipos)
            {
                if (item.Nombre == nombre)
                {
                    return item;
                }
            }
            return null;
        }
        public Usuario ObtenerUsuario(string email) 
        {
            foreach(Usuario item in _usuarios) {

                if (item.Email == email)
                {
                    return item;
                }          
            }
            return null;
        }
        public Usuario ObtenerUsuario(int id)
        {
            foreach (Usuario item in _usuarios)
            {
                if (item.Id == id)
                {
                    return item;
                }
            }
            return null;
        }

        public List<Usuario> Usuarios() 
        {
            return _usuarios;
        }

        public List<string> ListaUsuarioPorEquipo(string nombre)
        {
            Equipo unE = ObtenerEquipo(nombre);
            List<string> aux = new List<string>();
            if (unE == null)
            {
                throw new Exception("ESE ESQUIPO NO EXISTE");
            }
            foreach (Usuario item in _usuarios)
            {
                if (unE.Nombre == item.UnEquipo.Nombre)
                {
                    aux.Add(MensajeListadoUsuarioPorEquipo(item));
                }
            }
            return aux;
        }
        public List<Equipo> ListarEquipos()
        {
            return _equipos;
        }
        public string MensajeListadoUsuarioPorEquipo(Usuario usuario)
        {
            return $"Nombre: {usuario.Nombre}\n" +
                   $"Email: {usuario.Email}\n";
        }

      public List<Pago> ListarPagosPorEmailDeUsuario(string email)
       {
            Usuario unU = ObtenerUsuario(email);
            List<Pago> aux = new List<Pago>();

            foreach(Pago item in _pagos)
            {
                if(unU.Email == item.Usuario.Email)
                {
                    aux.Add(item);
                }
            }

            return aux;
        }


        public List<PagoUnico> ListarPagosUnicoPorMail(string email)
        {
            Usuario unU = ObtenerUsuario(email);
            List<PagoUnico> aux = new List<PagoUnico>();

            if (unU == null) throw new Exception("El usuario con ese mail no existe");


            foreach(Pago item in _pagos)
            {
                if (item is PagoUnico)
                {
                    if (unU.Email == item.Usuario.Email)
                    {
                        aux.Add((PagoUnico)item);
                    }

                }
            }

            return aux;
        }
        public List<PagoRecurrente> ListarPagosRecurrentePorMail(string email)
        {
            Usuario unU = ObtenerUsuario(email);
            List<PagoRecurrente> aux = new List<PagoRecurrente>();

            foreach (Pago item in _pagos)
            {
                if (item is PagoRecurrente)
                {
                    if (unU.Email == item.Usuario.Email)
                    {
                        aux.Add((PagoRecurrente)item);
                    }

                }
            }

            return aux;
        }
    }
}
