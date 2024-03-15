namespace Menu;
using Datos;
class Operaciones
{
    MetodosOpc metodos = new MetodosOpc();
    int opcion = 0;
    public void Metodo()
    {
        do{
            try
            {
                opcion = MenuPrincipal.Menu();
                break;
            }
            catch(FormatException)
            {
                Console.WriteLine("Dato no válido");
            }
        }while(true);
    }


    
}

class MetodosOpc
{
    Consulta cons = new Consulta();
    string nombre="";
    public void RegistrarUsuario()
    {
        Console.WriteLine("Mencione el nombre del usuario a registrar (En caso de tener dos mencionarlo igualmente \nEn caso de tener más de 2, solo mencionar 2.)");
            nombre = Console.ReadLine();
        Console.WriteLine("Mencione el apellido paterno del usuario");

        Console.WriteLine("Mencione el apellido materno del usuario");
    
        if(/*Condicion de que el registro haya sido exitoso o no*/ nombre == "pedro")
        {
            Console.WriteLine("El registro a sido completado");
        }

        Console.WriteLine("El registro a fallado. Inténtelo de nuevo.");
    }


    public void RecuperarDatos()
    {
        Console.WriteLine("Mencione el nombre del usuario a recuperar");
        Console.WriteLine("En caso de tener más de uno, solo mencionar el primero");
            nombre = Console.ReadLine();
        Console.WriteLine("Mencione el apellido paterno");

        Console.WriteLine("Mencione el apellido materno");

        if(/* Si la consulta encontro al usuario imprimir todos los datos*/nombre == "Pedro")
        {

        }
        else //Caso de que algún dato este mal o haya habido erorres.
        {
            Console.WriteLine("Ocurrió un error al buscar el usuario. \nInténtelo de nuevo.");
        }
    

    }

    public void MatchSangre() //En caso de buscar compatibilidad
    {
        Console.Write("Tipo de sangre a buscar:");

        Console.Write("Factor RH necesario:");
        /*A la hora de la busqueda agregar en el query una sentencia and Estatus = Disponible; para que no muestre a los no disponibles*/
        Console.WriteLine("Buscando...");
    }

    public void BajaUsuario()
    {

    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc? Sí
    // O unicamente debo poder modificar el estatus? no
    public void ModificarUsuario()
    {
        Console.WriteLine("¿Qué usuario desea modificar?");

        Console.WriteLine("¿Qué apartado desea modificar del usuario?");

        if(/* Caso de que la modificación haya sido correcta*/ nombre == "Pedro")
        {

        }
        else
        {

        }
    }
}