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
        public Sistema() {

            PreCarga();
        }
    
        public void PreCarga()
        {
            PreCargaEquipo();
            PreCargaUsuario();
            PreCargaTipoPago();
            PreCargaPagos();

        }

        private void PreCargaUsuario() 
        {
            AltaUsuario(new Usuario("Juan", "Perez", "123456789", new DateTime(2025, 10, 20), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Al", "Gomez", "234567890", new DateTime(2025, 10, 21), ObtenerEquipo(1)));
            AltaUsuario(new Usuario("Luis", "Li", "345678901", new DateTime(2025, 10, 22), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Zo", "Xu", "456789012", new DateTime(2025, 10, 23), ObtenerEquipo(3)));
            AltaUsuario(new Usuario("Ana", "Yu", "567890123", new DateTime(2025, 10, 24), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Ed", "Ng", "678901234", new DateTime(2025, 10, 25), ObtenerEquipo(1)));
            AltaUsuario(new Usuario("Camila", "Rodriguez", "789012345", new DateTime(2025, 10, 26), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Bo", "Ma", "890123456", new DateTime(2025, 10, 27), ObtenerEquipo(3)));
            AltaUsuario(new Usuario("Eva", "Romero", "901234567", new DateTime(2025, 10, 28), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Jo", "Al", "012345678", new DateTime(2025, 10, 29), ObtenerEquipo(1)));
            AltaUsuario(new Usuario("Maximiliano", "Torres", "112345678", new DateTime(2025, 10, 30), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Lu", "Fernandez", "122345678", new DateTime(2025, 10, 31), ObtenerEquipo(3)));
            AltaUsuario(new Usuario("Leonardo", "Diaz", "132345678", new DateTime(2025, 11, 1), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Micaela", "Lopez", "142345678", new DateTime(2025, 11, 2), ObtenerEquipo(1)));
            AltaUsuario(new Usuario("Tomas", "Sanchez", "152345678", new DateTime(2025, 11, 3), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Yul", "Kovacs", "162345678", new DateTime(2025, 11, 4), ObtenerEquipo(3)));
            AltaUsuario(new Usuario("Ra", "Ju", "172345678", new DateTime(2025, 11, 5), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Kai", "Morales", "182345678", new DateTime(2025, 11, 6), ObtenerEquipo(1)));
            AltaUsuario(new Usuario("Noelia", "Luna", "192345678", new DateTime(2025, 11, 7), ObtenerEquipo(2)));
            AltaUsuario(new Usuario("Teo", "Bonilla", "202345678", new DateTime(2025, 11, 8), ObtenerEquipo(3)));
            AltaUsuario(new Usuario("Is", "Re", "212345678", new DateTime(2025, 11, 9), ObtenerEquipo(0)));
            AltaUsuario(new Usuario("Fabrizio", "Zunino", "222345678", new DateTime(2025, 11, 10), ObtenerEquipo(1)));
        }
        private void PreCargaEquipo() 
        {
            AltaEquipo(new Equipo("Administracion"));
            AltaEquipo(new Equipo("Desarrollo"));
            AltaEquipo(new Equipo("Marketing"));
            AltaEquipo(new Equipo("Soporte Tecnico"));
        }
        private void PreCargaTipoPago()
        {
            AltaTipoGasto(new TipoGasto("COMIDA", "Gastos únicos por almuerzos, cenas o salidas gastronómicas"));
            AltaTipoGasto(new TipoGasto("TRANSPORTE", "Gastos relacionados con viajes en taxi, ómnibus, combustible o estacionamiento"));
            AltaTipoGasto(new TipoGasto("AFTERS", "Gastos grupales por salidas recreativas, fiestas o eventos sociales"));
            AltaTipoGasto(new TipoGasto("EQUIPAMIENTO", "Compras de hardware, mobiliario o herramientas necesarias para el trabajo"));
            AltaTipoGasto(new TipoGasto("SUSCRIPCIONES", "Pagos mensuales por servicios como Netflix, Spotify, software o plataformas online"));
            AltaTipoGasto(new TipoGasto("CAPACITACIÓN", "Cursos, talleres o certificaciones para mejorar habilidades del equipo"));
            AltaTipoGasto(new TipoGasto("REGALOS", "Obsequios para clientes, empleados o eventos especiales"));
            AltaTipoGasto(new TipoGasto("MARKETING", "Publicidad, diseño gráfico, redes sociales o campañas promocionales"));
            AltaTipoGasto(new TipoGasto("MANTENIMIENTO", "Reparaciones, limpieza o ajustes técnicos en equipos o instalaciones"));
            AltaTipoGasto(new TipoGasto("VIÁTICOS", "Gastos de alojamiento, comida y transporte durante viajes laborales"));

        }
        private void PreCargaPagos() 
        {
            AltaPago(new PagoUnico(new DateTime(2025, 01, 12), "REC-0001", MetodoDePago.EFECTIVO, ObtenerTipoGasto(0), ObtenerUsuario(0), "Almuerzo ejecutivo", 1200));
            AltaPago(new PagoUnico(new DateTime(2025, 02, 05), "REC-0002", MetodoDePago.DEBITO, ObtenerTipoGasto(1), ObtenerUsuario(1), "Taxi a reunión", 800));
            AltaPago(new PagoUnico(new DateTime(2025, 03, 18), "REC-0003", MetodoDePago.CREDITO, ObtenerTipoGasto(2), ObtenerUsuario(2), "After team", 1500));
            AltaPago(new PagoUnico(new DateTime(2025, 04, 10), "REC-0004", MetodoDePago.EFECTIVO, ObtenerTipoGasto(3), ObtenerUsuario(3), "Mouse ergonómico", 3200));
            AltaPago(new PagoUnico(new DateTime(2025, 05, 22), "REC-0005", MetodoDePago.DEBITO, ObtenerTipoGasto(4), ObtenerUsuario(4), "Suscripción Canva", 4500));
            AltaPago(new PagoUnico(new DateTime(2025, 06, 03), "REC-0006", MetodoDePago.CREDITO, ObtenerTipoGasto(5), ObtenerUsuario(5), "Curso de liderazgo", 18000));
            AltaPago(new PagoUnico(new DateTime(2025, 07, 14), "REC-0007", MetodoDePago.EFECTIVO, ObtenerTipoGasto(6), ObtenerUsuario(6), "Regalo aniversario", 2500));
            AltaPago(new PagoUnico(new DateTime(2025, 08, 26), "REC-0008", MetodoDePago.DEBITO, ObtenerTipoGasto(7), ObtenerUsuario(7), "Publicidad en redes", 10000));
            AltaPago(new PagoUnico(new DateTime(2025, 09, 07), "REC-0009", MetodoDePago.CREDITO, ObtenerTipoGasto(8), ObtenerUsuario(8), "Reparación notebook", 6200));
            AltaPago(new PagoUnico(new DateTime(2025, 10, 19), "REC-0010", MetodoDePago.EFECTIVO, ObtenerTipoGasto(9), ObtenerUsuario(9), "Viáticos viaje interior", 7800));
            AltaPago(new PagoUnico(new DateTime(2025, 11, 01), "REC-0011", MetodoDePago.DEBITO, ObtenerTipoGasto(0), ObtenerUsuario(10), "Cena de equipo", 5400));
            AltaPago(new PagoUnico(new DateTime(2025, 12, 13), "REC-0012", MetodoDePago.CREDITO, ObtenerTipoGasto(1), ObtenerUsuario(11), "Combustible", 3200));
            AltaPago(new PagoUnico(new DateTime(2025, 01, 25), "REC-0013", MetodoDePago.EFECTIVO, ObtenerTipoGasto(2), ObtenerUsuario(12), "Entrada evento social", 2100));
            AltaPago(new PagoUnico(new DateTime(2025, 02, 16), "REC-0014", MetodoDePago.DEBITO, ObtenerTipoGasto(3), ObtenerUsuario(13), "Silla gamer", 8900));
            AltaPago(new PagoUnico(new DateTime(2025, 03, 28), "REC-0015", MetodoDePago.CREDITO, ObtenerTipoGasto(4), ObtenerUsuario(14), "Suscripción Figma", 3600));
            AltaPago(new PagoUnico(new DateTime(2025, 04, 09), "REC-0016", MetodoDePago.EFECTIVO, ObtenerTipoGasto(5), ObtenerUsuario(15), "Taller de comunicación", 12000));
            AltaPago(new PagoUnico(new DateTime(2025, 05, 21), "REC-0017", MetodoDePago.DEBITO, ObtenerTipoGasto(6), ObtenerUsuario(16), "Obsequio cliente", 4100));
            AltaPago(new PagoUnico(new DateTime(2025, 06, 02), "REC-0018", MetodoDePago.CREDITO, ObtenerTipoGasto(7), ObtenerUsuario(17), "Diseño de banner", 7200));
            AltaPago(new PagoUnico(new DateTime(2025, 07, 13), "REC-0019", MetodoDePago.EFECTIVO, ObtenerTipoGasto(8), ObtenerUsuario(18), "Mantenimiento impresora", 3100));
            AltaPago(new PagoUnico(new DateTime(2025, 08, 24), "REC-0020", MetodoDePago.DEBITO, ObtenerTipoGasto(9), ObtenerUsuario(19), "Alojamiento por viaje", 34200));
            AltaPago(new PagoUnico(new DateTime(2025, 09, 05), "REC-0021", MetodoDePago.CREDITO, ObtenerTipoGasto(0), ObtenerUsuario(20), "Desayuno reunión", 1250));
            AltaPago(new PagoUnico(new DateTime(2025, 10, 17), "REC-0022", MetodoDePago.EFECTIVO, ObtenerTipoGasto(1), ObtenerUsuario(21), "Estacionamiento", 600));
            AltaPago(new PagoUnico(new DateTime(2025, 11, 29), "REC-0023", MetodoDePago.DEBITO, ObtenerTipoGasto(2), ObtenerUsuario(0), "Concierto integración", 22000));
            AltaPago(new PagoUnico(new DateTime(2025, 12, 10), "REC-0024", MetodoDePago.CREDITO, ObtenerTipoGasto(3), ObtenerUsuario(1), "Disco SSD", 12900));
            AltaPago(new PagoUnico(new DateTime(2025, 01, 03), "REC-0025", MetodoDePago.EFECTIVO, ObtenerTipoGasto(4), ObtenerUsuario(2), "Herramienta SaaS", 58000));
            AltaPago(new PagoUnico(new DateTime(2025, 02, 14), "REC-0026", MetodoDePago.DEBITO, ObtenerTipoGasto(5), ObtenerUsuario(3), "Certificación nube", 45000));
            AltaPago(new PagoUnico(new DateTime(2025, 03, 26), "REC-0027", MetodoDePago.CREDITO, ObtenerTipoGasto(6), ObtenerUsuario(4), "Regalo cliente", 4100));
            AltaPago(new PagoUnico(new DateTime(2025, 04, 07), "REC-0028", MetodoDePago.EFECTIVO, ObtenerTipoGasto(7), ObtenerUsuario(5), "Google Ads", 16000));
            AltaPago(new PagoUnico(new DateTime(2025, 05, 19), "REC-0029", MetodoDePago.DEBITO, ObtenerTipoGasto(8), ObtenerUsuario(6), "Servicio técnico", 7200));
            AltaPago(new PagoUnico(new DateTime(2025, 06, 30), "REC-0030", MetodoDePago.CREDITO, ObtenerTipoGasto(9), ObtenerUsuario(7), "Viaje internacional", 89000));
            AltaPago(new PagoUnico(new DateTime(2025, 07, 11), "REC-0031", MetodoDePago.EFECTIVO, ObtenerTipoGasto(0), ObtenerUsuario(8), "Catering reunión", 9800));
            AltaPago(new PagoUnico(new DateTime(2025, 08, 22), "REC-0032", MetodoDePago.DEBITO, ObtenerTipoGasto(1), ObtenerUsuario(9), "Boletería interurbana", 2100));
            AltaPago(new PagoUnico(new DateTime(2025, 09, 03), "REC-0033", MetodoDePago.CREDITO, ObtenerTipoGasto(2), ObtenerUsuario(10), "Evento social", 13500));
            AltaPago(new PagoUnico(new DateTime(2025, 10, 14), "REC-0034", MetodoDePago.EFECTIVO, ObtenerTipoGasto(3), ObtenerUsuario(11), "Soporte hardware", 4700));
            AltaPago(new PagoUnico(new DateTime(2025, 11, 25), "REC-0035", MetodoDePago.DEBITO, ObtenerTipoGasto(4), ObtenerUsuario(12), "Analítica web", 7200));
            AltaPago(new PagoUnico(new DateTime(2025, 12, 06), "REC-0036", MetodoDePago.CREDITO, ObtenerTipoGasto(5), ObtenerUsuario(13), "Taller liderazgo", 19800));
            AltaPago(new PagoUnico(new DateTime(2025, 01, 17), "REC-0037", MetodoDePago.EFECTIVO, ObtenerTipoGasto(6), ObtenerUsuario(14), "Canasta regalo", 5400));
            AltaPago(new PagoUnico(new DateTime(2025, 02, 08), "REC-0038", MetodoDePago.DEBITO, ObtenerTipoGasto(7), ObtenerUsuario(15), "Video promocional", 42000));
            AltaPago(new PagoUnico(new DateTime(2025, 04, 18), "REC-0040", MetodoDePago.EFECTIVO, ObtenerTipoGasto(9), ObtenerUsuario(20), "Viáticos para conferencia", 8700));
            AltaPago(new PagoUnico(new DateTime(2025, 05, 30), "REC-0041", MetodoDePago.DEBITO, ObtenerTipoGasto(0), ObtenerUsuario(21), "Almuerzo de cierre de proyecto", 3100));
            AltaPago(new PagoUnico(new DateTime(2025, 06, 11), "REC-0042", MetodoDePago.CREDITO, ObtenerTipoGasto(1), ObtenerUsuario(5), "Transporte a evento externo", 1900));

            AltaPago(new PagoRecurrente(new DateTime(2025, 01, 10), new DateTime(2025, 06, 10), MetodoDePago.DEBITO, ObtenerTipoGasto(4), ObtenerUsuario(0), "Suscripción Adobe Creative Cloud", 1800));
            AltaPago(new PagoRecurrente(new DateTime(2025, 02, 01), new DateTime(2025, 12, 01), MetodoDePago.CREDITO, ObtenerTipoGasto(5), ObtenerUsuario(1), "Curso mensual de inglés técnico", 2500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 03, 15), new DateTime(2025, 09, 15), MetodoDePago.EFECTIVO, ObtenerTipoGasto(9), ObtenerUsuario(2), "Viáticos mensuales por proyecto", 3200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 04, 05), new DateTime(2025, 07, 05), MetodoDePago.DEBITO, ObtenerTipoGasto(0), ObtenerUsuario(3), "Almuerzo mensual con cliente", 1500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 05, 20), new DateTime(2025, 11, 20), MetodoDePago.CREDITO, ObtenerTipoGasto(1), ObtenerUsuario(4), "Transporte mensual oficina", 900));
            AltaPago(new PagoRecurrente(new DateTime(2025, 06, 01), new DateTime(2025, 12, 01), MetodoDePago.EFECTIVO, ObtenerTipoGasto(2), ObtenerUsuario(5), "After mensual de integración", 2000));
            AltaPago(new PagoRecurrente(new DateTime(2025, 07, 10), new DateTime(2025, 10, 10), MetodoDePago.DEBITO, ObtenerTipoGasto(3), ObtenerUsuario(6), "Alquiler de equipamiento", 3500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 08, 15), new DateTime(2025, 12, 15), MetodoDePago.CREDITO, ObtenerTipoGasto(6), ObtenerUsuario(7), "Regalos corporativos mensuales", 1200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 09, 01), new DateTime(2025, 12, 01), MetodoDePago.EFECTIVO, ObtenerTipoGasto(7), ObtenerUsuario(8), "Publicidad mensual en redes", 5000));
            AltaPago(new PagoRecurrente(new DateTime(2025, 10, 05), new DateTime(2025, 12, 05), MetodoDePago.DEBITO, ObtenerTipoGasto(8), ObtenerUsuario(9), "Mantenimiento mensual de equipos", 2800));
            AltaPago(new PagoRecurrente(new DateTime(2025, 01, 20), new DateTime(2025, 07, 20), MetodoDePago.CREDITO, ObtenerTipoGasto(4), ObtenerUsuario(10), "Suscripción a plataforma de diseño", 1600));
            AltaPago(new PagoRecurrente(new DateTime(2025, 02, 10), new DateTime(2025, 08, 10), MetodoDePago.EFECTIVO, ObtenerTipoGasto(5), ObtenerUsuario(11), "Taller mensual de habilidades blandas", 2200));
            AltaPago(new PagoRecurrente(new DateTime(2025, 03, 01), new DateTime(2025, 06, 01), MetodoDePago.DEBITO, ObtenerTipoGasto(9), ObtenerUsuario(12), "Viáticos mensuales por capacitaciones", 3100));
            AltaPago(new PagoRecurrente(new DateTime(2025, 04, 12), new DateTime(2025, 10, 12), MetodoDePago.CREDITO, ObtenerTipoGasto(0), ObtenerUsuario(13), "Catering mensual para reuniones", 1800));
            AltaPago(new PagoRecurrente(new DateTime(2025, 05, 05), new DateTime(2025, 09, 05), MetodoDePago.EFECTIVO, ObtenerTipoGasto(1), ObtenerUsuario(14), "Transporte mensual interdepartamental", 950));
            AltaPago(new PagoRecurrente(new DateTime(2025, 06, 18), new DateTime(2025, 12, 18), MetodoDePago.DEBITO, ObtenerTipoGasto(2), ObtenerUsuario(15), "Eventos mensuales de equipo", 2700));
            AltaPago(new PagoRecurrente(new DateTime(2025, 07, 01), new DateTime(2025, 10, 01), MetodoDePago.CREDITO, ObtenerTipoGasto(3), ObtenerUsuario(16), "Alquiler de sala de reuniones", 4000));
            AltaPago(new PagoRecurrente(new DateTime(2025, 08, 20), new DateTime(2025, 12, 20), MetodoDePago.EFECTIVO, ObtenerTipoGasto(6), ObtenerUsuario(17), "Regalos mensuales para clientes", 1100));
            AltaPago(new PagoRecurrente(new DateTime(2025, 09, 10), new DateTime(2025, 12, 10), MetodoDePago.DEBITO, ObtenerTipoGasto(7), ObtenerUsuario(18), "Campaña mensual de marketing", 4800));
            AltaPago(new PagoRecurrente(new DateTime(2025, 10, 01), new DateTime(2025, 12, 01), MetodoDePago.CREDITO, ObtenerTipoGasto(8), ObtenerUsuario(19), "Servicio técnico mensual", 2500));
            AltaPago(new PagoRecurrente(new DateTime(2025, 01, 05), new DateTime(2025, 06, 05), MetodoDePago.EFECTIVO, ObtenerTipoGasto(9), ObtenerUsuario(20), "Viáticos mensuales por visitas", 3300));
            AltaPago(new PagoRecurrente(new DateTime(2025, 02, 22), new DateTime(2025, 08, 22), MetodoDePago.DEBITO, ObtenerTipoGasto(0), ObtenerUsuario(21), "Almuerzo mensual con proveedores", 1700));
            AltaPago(new PagoRecurrente(new DateTime(2025, 03, 30), new DateTime(2025, 09, 30), MetodoDePago.CREDITO, ObtenerTipoGasto(1), ObtenerUsuario(2), "Transporte mensual para capacitaciones", 1000));
            AltaPago(new PagoRecurrente(new DateTime(2025, 04, 15), new DateTime(2025, 12, 15), MetodoDePago.EFECTIVO, ObtenerTipoGasto(2), ObtenerUsuario(3), "Eventos mensuales de integración", 2600));
            AltaPago(new PagoRecurrente(new DateTime(2025, 05, 01), new DateTime(2025, 10, 01), MetodoDePago.DEBITO, ObtenerTipoGasto(3), ObtenerUsuario(4), "Alquiler mensual de proyectores", 3900));


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
                throw new Exception("El Equipo no existe");
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
                if (item.Nombre.ToLower().Replace(" ", "") == nombre.ToLower().Replace(" ", ""))
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
            if (int.TryParse(nombre, out _)) { unE = ObtenerEquipo(int.Parse(nombre)); }


            List<string> aux = new List<string>();
            if (unE == null)
            {
                throw new Exception("El equipo no existe");
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

            if (unU == null) throw new Exception("El usuario con ese mail no existe");


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
