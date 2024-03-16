namespace Datos;
class MetodosOpc
{
    Consulta cons = new Consulta();
    string? nombre="", apellido1="", apellido2="";
    public void RegistrarUsuario()
    {
        Console.WriteLine("Mencione el nombre del usuario a registrar. (En caso de tener más de dos, mencionar solo el primero) ");
            nombre = Console.ReadLine();
        Console.WriteLine("Mencione el apellido paterno del usuario");
            apellido1 = Console.ReadLine();
        Console.WriteLine("Mencione el apellido materno del usuario");
            apellido2 = Console.ReadLine();

        if(/*Condicion de que el registro haya sido exitoso o no*/ nombre == "pedro")
        {
            Console.WriteLine("El registro a sido completado");
        }

        Console.WriteLine("El registro a fallado. Inténtelo de nuevo.");
    }


    public void RecuperarDatos()
    {
        Console.WriteLine("Mencione el nombre del usuario a recuperar");
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
        Console.Write("Tipo de sangre solicitante:");

        Console.WriteLine("Factor RH del solicitante:");

        /*A la hora de la busqueda agregar en el query una sentencia and Estatus = Disponible; para que no muestre a los no disponibles*/
        Console.WriteLine("Buscando...");
    }

    public void BajaUsuario()
    {
        Console.WriteLine("Nombre del usuario a dar de baja:");
        
        Console.WriteLine("Apellido paterno del usuario a dar de baja:");

        Console.WriteLine("Apellido materno del usuario a dar de baja:");

    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc? Sí
    // O unicamente debo poder modificar el estatus? no
    public void ModificarUsuario()
    {
        Console.WriteLine("Nombre del usuario a modificar:");

        Console.WriteLine("¿Qué apartado desea modificar del usuario?");

        if(/* Caso de que la modificación haya sido correcta*/ nombre == "Pedro")
        {

        }
        else
        {

        }
    }

    public void ContadorDonantes()
    {

    }
}