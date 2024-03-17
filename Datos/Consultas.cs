namespace Datos;
using System.Data.SQLite;
class Consulta : DatosCli
{
    public override string Name { get => base.Name; set => base.Name = value; }
    public override string ApellidoMat { get => base.ApellidoMat; set => base.ApellidoMat = value; }
    public override string ApellidoPat { get => base.ApellidoPat; set => base.ApellidoPat = value; }
    public override string Estatus { get => base.Estatus; set => base.Estatus = value; }
    public override string Direccion { get => base.Direccion; set => base.Direccion = value; }
    public override string FactorRH { get => base.FactorRH; set => base.FactorRH = value; }
    public override string TipoSangre { get => base.TipoSangre; set => base.TipoSangre = value; }
    public override int Telefono { get => base.Telefono; set => base.Telefono = value; }
    public override string Desc { get => base.Desc; set => base.Desc = value; }
    string connectionString = @"Data Source=BancoSangre.sqlite;Version=3;";
    string query = "", query2 = "", query3="";
    public string Registro(string nombre, string apellido1, string apellido2, string direccion, string telefono, string factor, string tipoS, string estatus, string obser) //El registro necesita comprobar que los nombres y apellidos no estan registrados 
    {
        int id =ContadorIDS();
        query = "INSERT INTO Datos_usuario (ID,Nombre, Apellido_paterno, Apellido_materno, Telefono, Direccion) VALUES (@id, @nombre, @apellido1, @apellido2, @telefono, @direccion)";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using(SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", id); //El id se debe de obtener contando el total de registros +1 y ese va ser el nuevo id
                comando.Parameters.AddWithValue("@nombre", nombre.ToUpper());
                comando.Parameters.AddWithValue("@apellido1", apellido1.ToUpper());
                comando.Parameters.AddWithValue("@apellido2", apellido2.ToUpper());
                comando.Parameters.AddWithValue("@telefono", telefono.ToUpper());
                comando.Parameters.AddWithValue("@direccion", direccion.ToUpper());
                    int filasInsertadas = comando.ExecuteNonQuery();
                Console.WriteLine($"Se inserto {filasInsertadas} la fila en la tabla.");
                Console.WriteLine($"El ID de su usuario es: {id}");

            }
        }

        RegistroSangre(id, factor, tipoS, estatus, obser);

        return Convert.ToString(id);
    }
    public void RegistroSangre(int id, string factor, string tipoS, string estatus, string obser)
    {
        query = "INSERT INTO Tipo_sangre (id, factor_rh, tipo_sangre, estatus, Observaciones) VALUES (@id, @factor, @tipoS, @estatus, @obser)";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using(SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", id); //El id se debe de obtener contando el total de registros +1 y ese va ser el nuevo id
                comando.Parameters.AddWithValue("@factor", factor.ToUpper());
                comando.Parameters.AddWithValue("@tipoS", tipoS.ToUpper());
                comando.Parameters.AddWithValue("@estatus", estatus.ToUpper());
                comando.Parameters.AddWithValue("@obser", obser.ToUpper());
                    int filasInsertadas = comando.ExecuteNonQuery();
                Console.WriteLine($"Se inserto {filasInsertadas} la fila en la tabla.");

            }
        }
    }
    public void RegistroSoli(string usuarioId)
    {
        int numSoli=0, filas=0;
        string query = "INSERT INTO Solicitudes (id, id_solicitante, fecha) VALUES (@idSolicitud, @idUsuario, @fecha)";
            numSoli = ContadorSoli();
        // Crear y abrir la conexión
        using (SQLiteConnection connection = new SQLiteConnection(connectionString))
        {
            connection.Open();

            // Crear el comando SQL con parámetros
            using (SQLiteCommand command = new SQLiteCommand(query, connection))
            {
                // Agregar parámetros
                command.Parameters.AddWithValue("@idSolicitud", numSoli);
                command.Parameters.AddWithValue("@idUsuario", usuarioId);
                command.Parameters.AddWithValue("@fecha", DateTime.Now);

                // Ejecutar la consulta
                 filas = command.ExecuteNonQuery();

                // Verificar si la inserción fue exitosa
                if (filas > 0)
                {
                    Console.WriteLine("Solicitud agregada correctamente.");
                }
                else
                {
                    Console.WriteLine("No se pudo agregar la solicitud.");
                }
            }
        }
    }
    public string BuscarDatos(string nombreUsuario, string apellidoPaterno, string apellidoMaterno)
    {
        string id = "";
        query = @"
            SELECT du.ID, du.Nombre, du.Apellido_paterno, du.Apellido_materno, ts.factor_rh, ts.tipo_sangre, ts.estatus, ts.Observaciones, du.Telefono, du.Direccion
            FROM Datos_usuario du
            JOIN Tipo_sangre ts ON du.ID = ts.id
            WHERE du.Nombre = @NombreUsuario AND du.Apellido_paterno = @ApellidoPaterno AND du.Apellido_materno = @ApellidoMaterno"; 

        using (SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();

            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@NombreUsuario", nombreUsuario);
                comando.Parameters.AddWithValue("@ApellidoPaterno", apellidoPaterno);
                comando.Parameters.AddWithValue("@ApellidoMaterno", apellidoMaterno); // Agrega el parámetro para el apellido materno

                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        Console.WriteLine("Datos del usuario encontrado:");
                        Console.WriteLine($"ID: {reader["ID"]}");
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_RH"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Estatus: {reader["Estatus"]}");
                        Console.WriteLine($"Observaciones: {reader["Observaciones"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");

                        id = Convert.ToString(reader["ID"]);
                    }
                    else
                    {
                        Console.WriteLine("Usuario no encontrado.");
                    }
                }
            }
        }

        return id;
    }
    //COMPLETO
    public void MatchSangreABPositivo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' OR ts.tipo_sangre = 'O' OR ts.tipo_sangre = 'A' OR ts.tipo_sangre = 'AB' OR ts.tipo_sangre = 'B'";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //COMPLETO
    public void MatchSangreABNegativo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //INCOMPLETO
    public void MatchSangreAPositivo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //INCOMPLETO
    public void MatchSangreANegativo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //INCOMPLETO
    public void MatchSangreBPositivo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //INCOMPLETO
    public void MatchSangreBNegativo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //INCOMPLETO
    public void MatchSangreONegativo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    //INCOMPLETO
    public void MatchSangreOPositivo()
    {
        bool donadoresEncontrados = false;
        query = @"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion 
                    FROM Datos_usuario du
                    JOIN Tipo_sangre ts 
                    WHERE ts.estatus = 'Disponible' AND (ts.tipo_sangre = 'O' AND ts.factor_rh = 'Negativo') OR (ts.tipo_sangre = 'A' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'AB' AND ts.factor_rh = 'negativo') OR (ts.tipo_sangre = 'B' AND ts.factor_rh = 'negativo')";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                using (SQLiteDataReader reader = comando.ExecuteReader())
                {
                    while(reader.Read())
                    {
                        if (!donadoresEncontrados)
                        {
                            Console.WriteLine("\nDonador(es) encontrado(s):");
                            donadoresEncontrados = true;
                        }
                        Console.WriteLine($"Nombre: {reader["Nombre"]}");
                        Console.WriteLine($"Apellido Paterno: {reader["Apellido_paterno"]}");
                        Console.WriteLine($"Apellido Materno: {reader["Apellido_materno"]}");
                        Console.WriteLine($"Factor RH: {reader["Factor_rh"]}");
                        Console.WriteLine($"Tipo de Sangre: {reader["Tipo_sangre"]}");
                        Console.WriteLine($"Télefono: {reader["Telefono"]}");
                        Console.WriteLine($"Dirección: {reader["Direccion"]}");
                    }
                }
            }
        }
    }
    public int ContadorIDS()
    {
        int id = 0;
         query = "SELECT COUNT(*) FROM Datos_usuario";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                id = Convert.ToInt32(comando.ExecuteScalar());
                Console.WriteLine($"El total de datos en la tabla Tipo_sangre es: {id}");
            }
        }
        return id + 1;
    }
    public int ContadorSoli()
    {
        int totSoli = 0;
         query = "SELECT COUNT(*) FROM Solicitudes";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                totSoli = Convert.ToInt32(comando.ExecuteScalar());
                Console.WriteLine($"El total de datos en la tabla solicitudes es: {totSoli}");
            }
        }
        return totSoli + 1;
    }
    
    public void Prueba() //Parte para visualizar datos y pruebas 
    {
        query = "SELECT * FROM Datos_usuario";

        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using(SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                    Console.WriteLine("Datos de la tabla Datos_usuario");
                    Console.WriteLine("|ID\t|Nombre                   |Apellido Paterno    |Apellido Materno    |");
                   using(SQLiteDataReader reader = comando.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"|{reader["ID"]}\t|{reader["Nombre"].ToString().PadRight(25)}|{reader["Apellido_paterno"].ToString().PadRight(20)}|{reader["Apellido_materno"].ToString().PadRight(20)}|");                        
                        }
                    }
            
            }

            query2 = "SELECT * FROM Tipo_sangre";
            using(SQLiteCommand comando2 = new SQLiteCommand(query2, conexion))
            {
                Console.WriteLine("Datos de la tabla Tipo_sangre");
                Console.WriteLine("|ID   |Factor RH |Tipo sangre|Estatus        |Observaciones                 |");

                using(SQLiteDataReader reader = comando2.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"|{reader["id"].ToString().PadRight(5)}|{reader["factor_rh"].ToString().PadRight(10)}|{reader["tipo_sangre"].ToString().PadRight(11)}|{reader["estatus"].ToString().PadRight(15)}|{reader["Observaciones"].ToString().PadRight(30)}|");
                        }
                    }
            }
            query3 = "SELECT * FROM Solicitudes";
            using(SQLiteCommand comando2 = new SQLiteCommand(query3, conexion))
            {
                Console.WriteLine("Datos de la tabla solicitudes");
                Console.WriteLine("|ID   |ID Solicitante|Fecha     |");

                using(SQLiteDataReader reader = comando2.ExecuteReader())
                    {
                        while(reader.Read())
                        {
                            Console.WriteLine($"|{reader["id"].ToString().PadRight(5)}|{reader["id_solicitante"].ToString().PadRight(14)}|{reader["fecha"].ToString().PadRight(10)}|");                        
                        }
                    }
            }
        }
    }
}