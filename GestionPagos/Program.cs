using Dominio;

namespace GestionPagos
{
    internal class Program
    {

        private static Sistema _sistema = new Sistema();
        
        static void Main(string[] args)
        {
            _sistema.PreCarga();
            try
            {
                int opcion = 0;
                do
                {
                    opcion = PedirNro("" +
                                      "" +
                                      "Ingrese opción\n" +
                                      "1-ListarUsuarios\n" +
                                      "2-AltaUsuario\n" +
                                      "3-Mostrar Usuarios de Equipo\n"+
                                      "4-Dado un correo de usuario listar todos los pagos que realizó ese usuario\n"



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
                while (opcion != 5);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
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
        private static string PedirString(string mensaje)
        {
            Console.WriteLine(mensaje);
            string texto = Console.ReadLine();
            if (string.IsNullOrEmpty(texto)) throw new Exception($"{mensaje} vacio, debes de complet el campo para continuar");

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
                throw new Exception("No hay usuarios creados");

            }
            else
            {
                MensajeTitulo("Listado Usuarios");
                foreach (Usuario item in aux) 
                {
                    Console.WriteLine(item);
                }

            }        
        }
        private static void AltaUsuario()
        {

            try
            {
                string nombre = PedirString("Nombre");
                string apellido = PedirString("Apellido");
                string contrasenia = PedirString("Contraseña");
                DateTime fecha = PedirFecha("Fecha");
                ListarTodosLosEquipos();
                string equipo = PedirString("Equipo");
                
                Equipo unE = _sistema.ObtenerEquipo(equipo);

                _sistema.AltaUsuario(new Usuario(nombre, apellido, contrasenia, fecha, unE));

                MensajeTitulo($"El Usuario ${nombre} ${apellido} se creo correctamente");

            }
            catch (Exception e)
            {
                
                MensajeError(e.Message);


            }
           
        }
        private static void ListarUsuarioPorEquipo()
        {
            string nombre = PedirString("NOMBRE DEL EQUIPO");
            List<String> aux = _sistema.ListaUsuarioPorEquipo(nombre);

            if (aux.Count == 0)
            {
                throw new Exception("No hay usuarios creados");

            }
            else
            {
                MensajeTitulo("Listado Usuarios por equipo");
                foreach (String item in aux)
                {
                    Console.WriteLine(item);
                }

            }
        }
        private static void ListarTodosLosEquipos()
        {
            List<Equipo> aux = _sistema.ListarEquipos();

            if (aux.Count == 0) { throw new Exception("No hay equipos, crea uno"); }

            else {
                MensajeTitulo("Listado Usuarios por equipo");
                foreach (Equipo item in aux)
                {
                    Console.WriteLine(item);
                }

            }

        }
        private static void ListarPagoPorEmailDeUsuario()
        {
            string email = PedirString("Email del usuario para listar sus pagos");
            List<PagoUnico> auxPagoUnico = _sistema.ListarPagosUnicoPorMail(email);
            List<PagoRecurrente> auxPagoRecurrente = _sistema.ListarPagosRecurrentePorMail(email);

            if (auxPagoUnico.Count == 0 && auxPagoRecurrente.Count == 0)
            {
                throw new Exception("El usuario no tiene pagos");

            }
            else
            {
                MensajeTitulo("Listado de pagos unicos");
                foreach (PagoUnico item in auxPagoUnico)
                {
                    Console.WriteLine(item);
                }

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
