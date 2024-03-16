namespace Menu;
using Datos;
class Operaciones
{
    MetodosOpc metodos = new MetodosOpc();
    int opcion;
    public void Metodo()
    {
        do{
            try
            {
                MenuPrincipal.Menu(out opcion);
                switch(opcion)
                {
                    case 1:
                        metodos.RegistrarUsuario();
                    break;

                    case 2:
                        metodos.RecuperarDatos();
                    break;
                    
                    case 3:
                        metodos.MatchSangre();
                    break;
                    
                    case 4:
                        metodos.BajaUsuario();
                    break;
                    
                    case 5:
                        metodos.ModificarUsuario();
                    break;
                    case 6:
                        metodos.ContadorDonantes();
                    break;
                }
                break;
            }
            catch(FormatException)
            {
                Console.WriteLine("Opción no válida");
            }
        }while(true);
    }
}

