namespace Menu;
using Datos;
using System.Data.SQLite;

public class Operaciones
    {
        MetodosOpc metodos = new MetodosOpc();
        Consulta con = new Consulta();
        int opcion;

        public void Metodo()
        {
            do
            {
                try
                {
                    MenuPrincipal.Menu(out opcion);
                    switch (opcion)
                    {
                        case 1:
                            metodos.RegistrarUsuario();
                            break;

                        case 2:
                            metodos.RecuperarDatos();
                            break;

                        case 3:
                            con.MatchSangre();
                            break;

                        case 4:
                            metodos.BajaUsuario();
                            break;

                        case 5:
                            metodos.ModificarUsuario();
                            break;

                        case 6:
                            con.ContadorDonantes();
                            break;

                        case 7:
                            Console.WriteLine("Saliendo del programa.........");
                            return; 

                        default:
                            Console.WriteLine("Opción no válida. Por favor, seleccione una opción válida.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Opción no válida");
                }
            } while (true);
        }
    }

