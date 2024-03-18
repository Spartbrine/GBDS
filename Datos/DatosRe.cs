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
        string? id="", resp = "";
        Console.WriteLine("¿Cuenta con el ID del usuario? (S/N)");
            resp = Console.ReadLine().ToLower();
        switch(resp)
        {
            case "s":
                Console.WriteLine("ID del usuario:");
                    id = Console.ReadLine();
                cons.BuscarDatosConID(id);
                
            break;
            case "n":
                DatosBasicos();
                id = cons.BuscarDatosSinID(cons.Name, cons.ApellidoPat, cons.ApellidoMat);    
            break;
        }
        
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
       
        if(cons.TipoSangre == "ab" &&cons.FactorRH == "positivo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' ORDER BY ts.tipo_sangre";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "ab" && cons.FactorRH == "negativo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'NEGATIVO') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'NEGATIVO') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'NEGATIVO') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'NEGATIVO') ORDER BY ts.tipo_sangre";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "a" && cons.FactorRH == "positivo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND (ts.tipo_sangre = 'O' OR ts.tipo_sangre = 'A') ORDER BY ts.tipo_sangre";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "a" && cons.FactorRH == "negativo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND (ts.tipo_sangre = 'O' OR ts.tipo_sangre = 'A' OR ts.tipo_sangre = 'AB') AND ts.factor_rh = 'NEGATIVO' ORDER BY ts.tipo_sangre";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "b" && cons.FactorRH == "positivo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND ts.tipo_sangre = 'O'  OR ts.tipo_sangre = 'B' ORDER BY ts.tipo_sangre";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "b" && cons.FactorRH == "negativo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND (ts.tipo_sangre = 'O' OR ts.tipo_sangre = 'B' OR ts.tipo_sangre = 'AB') AND ts.factor_rh = 'NEGATIVO' ORDER BY ts.tipo_sangre";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "o" && cons.FactorRH == "negativo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'NEGATIVO')";
                cons.MatchSangre(query);
            }
            else if(cons.TipoSangre == "o" && cons.FactorRH == "positivo")
            {
                query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                        FROM Datos_usuario du
                        JOIN Tipo_sangre ts 
                        WHERE ts.estatus = 'DISPONIBLE' AND ts.tipo_sangre = 'O' ORDER BY ts.factor_rh";
                cons.MatchSangre(query);
            }
        cons.RegistroSoli("");
    }
    public void BajaUsuario() //Este metodo debe actualizar el estatus y agregar observaciones
    {
        Regex estatusRgx = new Regex(@"^(Disponible|Baja definitiva|Baja temporal)$", RegexOptions.IgnoreCase); 
        string id = "", resp = "";
        Console.WriteLine("¿Cuenta con el ID del usuario? (S/N)");
            resp = Console.ReadLine().ToLower();
        switch(resp)
        {
            case "s":
                Console.WriteLine("ID del usuario:");
                    id = Console.ReadLine();
                cons.BuscarDatosConID(id);
                
            break;
            case "n":
                DatosBasicos();
                id = cons.BuscarDatosSinID(cons.Name, cons.ApellidoPat, cons.ApellidoMat);    
            break;
        }
        if(id!=null)
        {
            Console.WriteLine("ID del usuario:" + id);
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

            cons.BajaUsuario(id);
        }  
        cons.RegistroSoli(id);

    }
    //En modificaciones al usuario se puede modificar apellidos, nombres, etc? Sí
    // O unicamente debo poder modificar el estatus? no
    public void ModificarUsuario() //Utilizar update
    {
        Regex letras = new Regex( @"^[a-zA-Z]+$");

        
        string id = "", resp = "";
        Console.WriteLine("¿Cuenta con el ID del usuario? (S/N)");
            resp = Console.ReadLine().ToLower();
        switch(resp)
        {
            case "s":
                Console.WriteLine("ID del usuario:");
                    id = Console.ReadLine();
                cons.BuscarDatosConID(id);
                
            break;
            case "n":
                DatosBasicos();
                id = cons.BuscarDatosSinID(cons.Name, cons.ApellidoPat, cons.ApellidoMat);    
            break;
        }
        if(id!=null)
        {
            Console.WriteLine("ID del usuario:" + id);
            MenuModif(id);
        }       
        cons.RegistroSoli(id);

    }
    public void ContadorDonantes() //Usar un count de donantes donde estatus sea disponible 
    {
        cons.ContadorDonantes();
    }

    public void DatosBasicos()
    { //Necesito un regex para que no se puedan ingresar numeros en los nombres, y apellidos

        Regex letrasRgx = new Regex(@"^[a-zA-ZáéíóúüÁÉÍÓÚÜ\s]+$");
        do
        {
            Console.WriteLine("Mencione el nombre del usuario");
                cons.Name = Console.ReadLine();
            if(!letrasRgx.IsMatch(cons.Name)) Console.WriteLine("Texto no válido");
        }while(!letrasRgx.IsMatch(cons.Name));
        do
        {
            Console.WriteLine("Mencione el apellido paterno del usuario");
                cons.ApellidoPat = Console.ReadLine();
            if(!letrasRgx.IsMatch(cons.ApellidoPat)) Console.WriteLine("Texto no válido");
        }while(!letrasRgx.IsMatch(cons.ApellidoPat));
        do
        {
            Console.WriteLine("Mencione el apellido materno del usuario");
                cons.ApellidoMat = Console.ReadLine();
            if(!letrasRgx.IsMatch(cons.ApellidoMat)) Console.WriteLine("Texto no válido");
        }while(!letrasRgx.IsMatch(cons.ApellidoMat));

        
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
            if (cons.Telefono.Length != 10)
            {
                Console.WriteLine("El número de teléfono debe tener exactamente 10 dígitos.");
            }
            if (!numeros.IsMatch(cons.Telefono))
            {
                Console.WriteLine("Por favor, ingrese solo números.");
            }
        }
        while (!numeros.IsMatch(cons.Telefono)|| cons.Telefono.Length != 10);

        Console.WriteLine("Dirección del usuaio:");
            cons.Direccion = Console.ReadLine();
    }
    public void MenuModif(string id)
    {
        Regex numeros = new Regex(@"^\d+$");
        Regex tipoSangre = new Regex(@"^(A|B|O|AB|)$", RegexOptions.IgnoreCase);
        Regex factorRH = new Regex(@"^(positivo|negativo)$", RegexOptions.IgnoreCase); 
        string opcion="", datoActualizado="";
        
        Console.WriteLine("¿Qué apartado desea modificar del usuario?");
            Console.WriteLine("1.- Nombre \n2.- Apellido paterno \n3.- Apellido materno \n 4.-Dirección \n5.- Tipo de sangre \n6.- Factor RH \n7.- Télefono");
                opcion = Console.ReadLine();
//string query = "UPDATE NombreTabla SET NombreColumna = @NuevoValor WHERE Condicion = @Condicion";   
        switch(opcion)
        {
            case "1": //Nombre
                Console.WriteLine("Nombre por el que desea modificar:");
                    datoActualizado = Console.ReadLine();
                cons.ActualizarDato("Datos_usuario","Nombre","ID",datoActualizado, id);    
            break;
            
            case "2": //Apellido paterno
                Console.WriteLine("Apellido paterno por el que desea modificar:");
                    datoActualizado = Console.ReadLine();
                cons.ActualizarDato("Datos_usuario","Apellido_paterno","ID",datoActualizado, id);  
            break;

            case "3": //Apellido materno
                Console.WriteLine("Apellido materno por el que desea modificar:");
                    datoActualizado = Console.ReadLine();
                cons.ActualizarDato("Datos_usuario","Apellido_materno","ID",datoActualizado, id); 
            break;

            case "4": //Direccion
                Console.WriteLine("Dirección por la que desea modificar:");
                    datoActualizado = Console.ReadLine();
                cons.ActualizarDato("Datos_usuario","Direccion","ID",datoActualizado, id); 
            break;

            case "5":   //Tipo de sangre
                    do 
                    {
                        Console.WriteLine("Tipo de sangre por la que desea modificar:");
                            datoActualizado = Console.ReadLine();

                        if (!tipoSangre.IsMatch(datoActualizado))
                        {
                            Console.WriteLine("Por favor, ingrese un tipo de sangre válido.");
                        }
                    }
                    while (!tipoSangre.IsMatch(datoActualizado));
                cons.ActualizarDato("Tipo_sangre","tipo_sangre","id",datoActualizado, id); 
            break;
                
            case "6"://Factor rh
                do 
                {
                    Console.Write("Ingrese el factor Rh (positivo o negativo): ");
                        datoActualizado = Console.ReadLine();

                    if (!factorRH.IsMatch(datoActualizado))
                    {
                        Console.WriteLine("Por favor, ingrese un factor RH válido.");
                    }
                }
                while (!factorRH.IsMatch(datoActualizado));
                cons.ActualizarDato("Tipo_sangre","factor_rh","id",datoActualizado, id); 

            break;

            case "7": //Numeros 
                do
                {
                    Console.WriteLine("Teléfono del usuario:");
                        datoActualizado = Console.ReadLine();

                    if (!numeros.IsMatch(datoActualizado))
                    {
                        Console.WriteLine("Por favor, ingrese solo números.");
                    }
                }
                while (!numeros.IsMatch(datoActualizado));
                cons.ActualizarDato("Datos_usuario","Telefono","ID",datoActualizado, id); 

            break;
        }

        cons.RegistroSoli(id);

    }


}

