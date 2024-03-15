namespace Menu;
using Datos;
class Operaciones
{
    Consulta cons = new Consulta();
    MetodosOpc metod = new MetodosOpc();




    
}

class MetodosOpc
{
    public void Registro()
    {
        Console.WriteLine("Mencione el nombre del usuario a registrar (En caso de tener dos mencionarlo igualmente \nEn caso de tener más de 2, solo mencionar 2.)");

        Console.WriteLine("Mencione el apellido paterno del usuario");

        Console.WriteLine("Mencione el apellido materno del usuario");
    
        if(/*Condicion de que el registro haya sido exitoso o no*/)
        {
            Console.WriteLine("El registro a sido completado");
        }

        Console.WriteLine("El registro a fallado. Inténtelo de nuevo.");
    }


    public void RecuperarDatos()
    {
        Console.WriteLine("Mencione el nombre del usuario a recuperar");
        Console.WriteLine("En caso de tener más de uno, solo mencionar el primero");

        Console.WriteLine("Mencione el apellido paterno");

        Console.WriteLine("Mencione el apellido materno");

        if(/* Si la consulta encontro al usuario imprimir todos los datos*/)
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

    public void bajaUsuario()
    {

    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc?
    // O unicamente debo poder modificar el estatus?

}