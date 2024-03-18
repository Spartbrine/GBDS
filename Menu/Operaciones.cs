namespace Menu;
using Datos;

class Operaciones
{
    MetodosOpc metodos = new MetodosOpc();
    Consulta con = new Consulta();
    int opcion;
    
    public void Metodo()
    {
        bool salida = true;
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
                    case 7:
                        salida = false;
                    break;
                    case 4004: //Esto es para que se hagan pruebas
                        con.Prueba();
                    break;   
                }
            }
            catch(FormatException)
            {
                Console.WriteLine("Opción no válida");
            }
        }while(salida == true);
    }
}


