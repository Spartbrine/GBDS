namespace Datos;
using System.Data.SQLite;
using System.Text.RegularExpressions;
class MetodosOpc
{
    Consulta cons = new Consulta();
    

    //COMPLETO
    public void RegistrarUsuario() 
    {
        DatosBasicos();
        DatosRestantes();
        DatosSangre();
        string id = "";
        try
        {
            id = cons.Registro();
            Console.WriteLine("El registro a sido completado");
            cons.RegistroSoli(id);
        }
        catch(SQLiteException ex)
        {
            Console.WriteLine("El registro a fallado. Inténtelo de nuevo." + ex);
        }
        return;
    }
   //COMPLETO
    public void RecuperarDatos() //Este con un select de la tabla Tipo_sangre y Datos_usuario con join
    {
        string? id="";
        DatosBasicos();
        id = cons.BuscarDatos(cons.Name, cons.ApellidoPat, cons.ApellidoMat);
        cons.RegistroSoli(id);

    }
    public void MatchSangre() //En caso de buscar compatibilidad
    {
        string query ="";
        Console.Write("Tipo de sangre solicitante:");
            cons.TipoSangre = Console.ReadLine().ToLower();
        Console.WriteLine("Factor RH del solicitante:");
            cons.FactorRH = Console.ReadLine().ToLower();
        /*A la hora de la busqueda agregar en el query una sentencia and Estatus = Disponible; para que no muestre a los no disponibles*/
        Console.WriteLine("Buscando...");
        switch(cons.TipoSangre)
        {
            case "ab":
                switch(cons.FactorRH)
                {
                    case "positivo":
                    query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' OR ts.tipo_sangre = 'O' OR ts.tipo_sangre = 'A' OR ts.tipo_sangre = 'AB' OR ts.tipo_sangre = 'B'";
                        cons.MatchSangre(query);
                    break;
                    case "negativo":
                        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
                        cons.MatchSangre(query);
                    break;
                }
            break;
        }

    }
    public void BajaUsuario() //Este metodo debe actualizar el estatus y agregar observaciones
    {
        DatosBasicos();
        Console.WriteLine(cons.Name, cons.ApellidoPat, cons.ApellidoMat);  
    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc? Sí
    // O unicamente debo poder modificar el estatus? no
    public void ModificarUsuario() //Utilizar update
    {
        string id = "";
        DatosBasicos();
        id = cons.BuscarDatos(cons.Name, cons.ApellidoPat, cons.ApellidoMat);
        if(id!="")
        {
            Console.WriteLine(id);
            Console.WriteLine("¿Qué apartado desea modificar del usuario?");
        }        
    }
    public void ContadorDonantes() //Usar un count de donantes donde estatus sea disponible 
    {

    }

    public void DatosBasicos()
    { //Necesito un regex para que no se puedan ingresar numeros en los nombres, y apellidos

        Console.WriteLine("Mencione el nombre del usuario");
            cons.Name = Console.ReadLine();
        Console.WriteLine("Mencione el apellido paterno del usuario");
            cons.ApellidoPat = Console.ReadLine();
        Console.WriteLine("Mencione el apellido materno del usuario");
            cons.ApellidoMat = Console.ReadLine();
    }
    public void DatosSangre() //id (ya debe estar registrado), factor rh, tipo de sangre, estatus y observaciones
    {
        Regex tipoSangre = new Regex(@"^(A|B|O|AB|)$", RegexOptions.IgnoreCase);
        Regex factorRH = new Regex(@"^(positivo|negativo)$", RegexOptions.IgnoreCase); 
        Regex estatusRgx = new Regex(@"^(Disponible|Baja definitiva|Baja temporal)$", RegexOptions.IgnoreCase); 

        do //Tipo de sangre
        {
            Console.WriteLine("Tipo de sangre del usuario");
                cons.TipoSangre = Console.ReadLine();

            if (!tipoSangre.IsMatch(cons.TipoSangre))
            {
                Console.WriteLine("Por favor, ingrese un tipo de sangre válido.");
            }
        }
        while (!tipoSangre.IsMatch(cons.TipoSangre));

        do //Factor rh
        {
            Console.Write("Ingrese el factor Rh (positivo o negativo): ");
                cons.FactorRH = Console.ReadLine();

            if (!factorRH.IsMatch(cons.FactorRH))
            {
                Console.WriteLine("Por favor, ingrese un factor Rh válido.");
            }
        }
        while (!factorRH.IsMatch(cons.FactorRH));

        do //Estatus
        {
            Console.Write("Ingrese el estatus (Disponible, Baja definitiva o Baja temporal): ");
            cons.Estatus = Console.ReadLine();

            if (!estatusRgx.IsMatch(cons.Estatus))
            {
                Console.WriteLine("Por favor, ingrese un estatus válido.");
            }
        }
        while (!estatusRgx.IsMatch(cons.Estatus));

        if (cons.Estatus.ToLower().Equals("baja definitiva") || cons.Estatus.ToLower().Equals("baja temporal"))
        {
            do
            {
                Console.Write("Ingrese la observación: ");
                    cons.Desc = Console.ReadLine();
                if(cons.Desc=="")
                {
                    Console.WriteLine("Necesita poner observaciones");
                }
            }while(cons.Desc=="");
        }
        else
        {
            cons.Desc = "Saludable";
        }
    


    }
    public void DatosRestantes()
    {
        Regex numeros = new Regex(@"^\d+$");
        
        do
        {
            Console.WriteLine("Teléfono del usuario:");
                cons.Telefono = Console.ReadLine();

            if (!numeros.IsMatch(cons.Telefono))
            {
                Console.WriteLine("Por favor, ingrese solo números.");
            }
        }
        while (!numeros.IsMatch(cons.Telefono));

        Console.WriteLine("Dirección del usuaio:");
            cons.Direccion = Console.ReadLine();
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