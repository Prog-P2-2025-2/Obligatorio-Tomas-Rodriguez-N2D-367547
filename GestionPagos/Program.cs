using Dominio;

namespace GestionPagos
{
    internal class Program
    {

        private static Sistema _sistema = new Sistema();

        static void Main(string[] args)
        {
           

            int opcion = 0;
            do
            {
                try
                {
                    opcion = PedirNro("" +
                                      "" +
                                      "Ingrese opción\n" +
                                      "1-ListarUsuarios\n" +
                                      "2-AltaUsuario\n" +
                                      "3-Mostrar Usuarios de Equipo\n" +
                                      "4-Dado un correo de usuario listar todos los pagos que realizó ese usuario\n" +
                                      "5-Salir\n"
                                      );
                    switch (opcion)
                    {
                        case 1:
                            ListarUsuario();
                            break;
                        case 2:
                            AltaUsuario();
                            break;
                        case 3:
                            ListarUsuarioPorEquipo();
                            break;
                        case 4:
                            ListarPagoPorEmailDeUsuario();
                            break;
                        default:
                            break;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);

                }
            } while (opcion != 5);
        }
        
        private static int PedirNro(string mensaje)
        {
            try
            {
                Console.WriteLine(mensaje);
                int nro = int.Parse(Console.ReadLine());
                return nro;
            }
            catch (Exception)
            {
                throw new Exception("Debe ingresar solo números");
            }
        }

        private static string PedirContrasenia(string contrasenia)
        {
            Console.WriteLine(contrasenia);
            string texto = Console.ReadLine();
            if (string.IsNullOrEmpty(texto)) throw new Exception($"{contrasenia} vacia");
            if (texto.Length < 8) throw new Exception($"{contrasenia} es menor a 8 carecteres");
            return texto;
        }

        private static string PedirString(string mensaje)
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();
            if (string.IsNullOrEmpty(texto)) throw new Exception($"{mensaje} vacio, debes de completar el campo para continuar");

            return texto;
        }

        private static DateTime PedirFecha(string mensaje)
        {
            try
            {
                int dia = PedirNro("DIA");
                int mes = PedirNro("MES");
                int año = PedirNro("AÑO");
                return new DateTime(año, mes, dia);
            }
            catch (Exception)
            {
                throw new Exception("Fecha no valida");
            }           
        }

        private static void ListarUsuario() {
            List<Usuario> aux = _sistema.Usuarios();

            if (aux.Count == 0) {
                MensajeError("No hay usuarios creados");
                return;
            }           
                MensajeTitulo("Listado Usuarios");
                foreach (Usuario item in aux) 
                {
                    Console.WriteLine(item);
                }                
        }
        private static void AltaUsuario()
        {
            try
            {
                string nombre = PedirString("Nombre");
                string apellido = PedirString("Apellido");
                string contrasenia = PedirContrasenia("Contraseña");
                DateTime fecha = PedirFecha("Fecha");
                ListarTodosLosEquipos();
                string equipo = PedirString("Nombre del Equipo o id");               
                Equipo unE = _sistema.ObtenerEquipo(equipo);
                if(int.TryParse(equipo, out _)) { unE = _sistema.ObtenerEquipo(int.Parse(equipo)); }
                _sistema.AltaUsuario(new Usuario(nombre, apellido, contrasenia, fecha, unE));
               MensajeTitulo($"El Usuario {nombre} {apellido} se creo correctamente");
            }
            catch (Exception e)
            {                
                MensajeError(e.Message);
            }           
        }
        private static void ListarUsuarioPorEquipo()
        {
            ListarTodosLosEquipos();
            string nombre = PedirString("Nombre del equipo o el id");
            List<String> aux = _sistema.ListaUsuarioPorEquipo(nombre);
            if (aux.Count == 0)
            {
               MensajeError("No hay usuarios creados");
                return;
            }           
                MensajeTitulo("Listado Usuarios por equipo");
                foreach (String item in aux)
                {
                    Console.WriteLine(item);
                }           
        }
        private static void ListarTodosLosEquipos()
        {
            List<Equipo> aux = _sistema.ListarEquipos();
            if (aux.Count == 0) { MensajeError("No hay equipos, crea uno"); }          
                MensajeTitulo("Listado de Equipos");
                foreach (Equipo item in aux)
                {
                    Console.WriteLine(item);
                }
        }
        private static void ListarPagoPorEmailDeUsuario()
        {
            string email = PedirString("Email del usuario para listar sus pagos");
            List<PagoUnico> auxPagoUnico = _sistema.ListarPagosUnicoPorMail(email);
            List<PagoRecurrente> auxPagoRecurrente = _sistema.ListarPagosRecurrentePorMail(email);
            if (auxPagoUnico.Count == 0 && auxPagoRecurrente.Count == 0)
            {
                MensajeError("El usuario no tiene pagos");
                return;
            }
            if (auxPagoUnico.Count > 0)
            {
                MensajeTitulo("Listado de pagos unicos");
                foreach (PagoUnico item in auxPagoUnico)
                {
                    Console.WriteLine(item);
                }
            }
            if (auxPagoRecurrente.Count > 0)
            {
                MensajeTitulo("Listado de pagos Recurrente");
                foreach (PagoRecurrente item in auxPagoRecurrente)
                {
                    Console.WriteLine(item);
                }
            }          
        }

        private static void MensajeTitulo(string mensaje) 
        {
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine($"----------------{mensaje}---------------");
            Console.WriteLine("-----------------------------------------");
        }

        private static void MensajeError(string mensaje)
        {
            Console.WriteLine("-------------------ERROR-----------------");
            Console.WriteLine($"----------------{mensaje}---------------");
            Console.WriteLine("-------------------ERROR-----------------");
        }


    }
}
