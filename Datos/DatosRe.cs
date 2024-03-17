namespace Datos;
using System.Data.SQLite;
using System.Text.RegularExpressions;
class MetodosOpc
{
    Consulta cons = new Consulta();
    string? tipoSangre, factorRH;

    public void RegistrarUsuario() //COMPLETO
    {
        string? nombre="", apellido1="", apellido2="", telefono="", direccion="", tipoS, factor, estatus, observaciones;
        DatosBasicos(out nombre, out apellido1, out apellido2);
        DatosRestantes(out telefono, out direccion);
        DatosSangre(out tipoS, out factor, out estatus, out observaciones);
        string id = "";
        try
        {
            id = cons.Registro(nombre, apellido1, apellido2, direccion, telefono, factor, tipoS, estatus, observaciones);
            Console.WriteLine("El registro a sido completado");
            cons.RegistroSoli(id);
        }
        catch(SQLiteException ex)
        {
            Console.WriteLine("El registro a fallado. Inténtelo de nuevo." + ex);
        }
        return;
    }
    public void RecuperarDatos() //Este con un select de la tabla Tipo_sangre y Datos_usuario con join
    {
        string? nombre="", apellido1="", apellido2="", id="";
        DatosBasicos(out nombre, out apellido1, out apellido2);
        id = cons.BuscarDatos(nombre, apellido1, apellido2);
        cons.RegistroSoli(id);

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
    public void BajaUsuario() //Este metodo debe actualizar el estatus y agregar observaciones
    {
        string? nombre="", apellido1="", apellido2="";
        DatosBasicos(out nombre, out apellido1, out apellido2);
        Console.WriteLine(nombre + apellido1 + apellido2);  
    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc? Sí
    // O unicamente debo poder modificar el estatus? no
    public void ModificarUsuario() //Utilizar update
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
    public void ContadorDonantes() //Usar un count de donantes donde estatus sea disponible 
    {

    }
    public void DatosBasicos(out string? nombre, out string? apellido1, out string? apellido2)
    { //Necesito un regex para que no se puedan ingresar numeros en los nombres, y apellidos

        Console.WriteLine("Mencione el nombre del usuario");
            nombre = Console.ReadLine();
        Console.WriteLine("Mencione el apellido paterno del usuario");
            apellido1 = Console.ReadLine();
        Console.WriteLine("Mencione el apellido materno del usuario");
            apellido2 = Console.ReadLine();
    }
    public void DatosSangre(out string tipoS, out string factor, out string estatus, out string observaciones) //id (ya debe estar registrado), factor rh, tipo de sangre, estatus y observaciones
    {
        Regex tipoSangre = new Regex(@"^(A|B|O|AB|)$", RegexOptions.IgnoreCase);
        Regex factorRH = new Regex(@"^(positivo|negativo)$", RegexOptions.IgnoreCase); 
        Regex estatusRgx = new Regex(@"^(Disponible|Baja definitiva|Baja temporal)$", RegexOptions.IgnoreCase); 

        do //Tipo de sangre
        {
            Console.WriteLine("Tipo de sangre del usuario");
                tipoS = Console.ReadLine();

            if (!tipoSangre.IsMatch(tipoS))
            {
                Console.WriteLine("Por favor, ingrese un tipo de sangre válido.");
            }
        }
        while (!tipoSangre.IsMatch(tipoS));

        do //Factor rh
        {
            Console.Write("Ingrese el factor Rh (positivo o negativo): ");
                factor = Console.ReadLine();

            if (!factorRH.IsMatch(factor))
            {
                Console.WriteLine("Por favor, ingrese un factor Rh válido.");
            }
        }
        while (!factorRH.IsMatch(factor));

        do //Estatus
        {
            Console.Write("Ingrese el estatus (Disponible, Baja definitiva o Baja temporal): ");
            estatus = Console.ReadLine();

            if (!estatusRgx.IsMatch(estatus))
            {
                Console.WriteLine("Por favor, ingrese un estatus válido.");
            }
        }
        while (!estatusRgx.IsMatch(estatus));

        if (estatus.ToLower().Equals("baja definitiva") || estatus.ToLower().Equals("baja temporal"))
        {
            do
            {
                Console.Write("Ingrese la observación: ");
                    observaciones = Console.ReadLine();
                if(observaciones=="")
                {
                    Console.WriteLine("Necesita poner observaciones");
                }
            }while(observaciones=="");
        }
        else
        {
            observaciones = "Saludable";
        }
    


    }
    public void DatosRestantes(out string telefono, out string direccion)
    {
        Regex numeros = new Regex(@"^\d+$");
        
        do
        {
            Console.WriteLine("Teléfono del usuario:");
                telefono = Console.ReadLine();

            if (!numeros.IsMatch(telefono))
            {
                Console.WriteLine("Por favor, ingrese solo números.");
            }
        }
        while (!numeros.IsMatch(telefono));

        Console.WriteLine("Dirección del usuaio:");
            direccion = Console.ReadLine();
    }

}


// string insertQuery2 = "INSERT INTO Solicitudes (id_solicitante, fecha) VALUES (@IdSolicitante, @Fecha)";
        
//         using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
//         {
//             conexion.Open();

//             using (SQLiteCommand comando = new SQLiteCommand(insertQuery2, conexion))
//             {
//                 // Parámetros para la consulta de inserción
//                 comando.Parameters.AddWithValue("@IdSolicitante", 1); // Ejemplo de ID de solicitante
//                 comando.Parameters.AddWithValue("@Fecha", DateTime.Now);