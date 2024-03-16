namespace Datos;

class MetodosOpc
{
    Consulta cons = new Consulta();
    string? tipoSangre, factorRH;

    public void RegistrarUsuario()
    {
        string? nombre="", apellido1="", apellido2="";
        DatosBasicos(out nombre, out apellido1, out apellido2);


        if(/*Condicion de que el registro haya sido exitoso o no*/ nombre == "pedro")
        {
            Console.WriteLine("El registro a sido completado");
        }

        Console.WriteLine("El registro a fallado. Inténtelo de nuevo.");
    }


    public void RecuperarDatos()
    {
        string? nombre="", apellido1="", apellido2="";
        DatosBasicos(out nombre, out apellido1, out apellido2);


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
            tipoSangre = Console.ReadLine();
        Console.WriteLine("Factor RH del solicitante:");
            factorRH= Console.ReadLine();
        /*A la hora de la busqueda agregar en el query una sentencia and Estatus = Disponible; para que no muestre a los no disponibles*/
        Console.WriteLine("Buscando...");

    }

    public void BajaUsuario()
    {
        string? nombre="", apellido1="", apellido2="";
        DatosBasicos(out nombre, out apellido1, out apellido2);


    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc? Sí
    // O unicamente debo poder modificar el estatus? no
    public void ModificarUsuario()
    {
        string? nombre="", apellido1="", apellido2="";
        DatosBasicos(out nombre, out apellido1, out apellido2);

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

    public void DatosBasicos(out string? nombre, out string? apellido1, out string? apellido2)
    {

        Console.WriteLine("Mencione el nombre del usuario");
            nombre = Console.ReadLine();
        Console.WriteLine("Mencione el apellido paterno del usuario");
            apellido1 = Console.ReadLine();
        Console.WriteLine("Mencione el apellido materno del usuario");
            apellido2 = Console.ReadLine();
    }
}