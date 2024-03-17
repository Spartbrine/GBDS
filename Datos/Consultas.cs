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
    public void Registro(string nombre, string apellido1, string apellido2) //El registro necesita comprobar que los nombres y apellidos no estan registrados 
    {
        int id =ContadorIDS();
        query = "INSERT INTO Datos_usuario (ID,Nombre, Apellido_paterno, Apellido_materno) VALUES (@id, @nombre, @apellido1, @apellido2)";
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
            using(SQLiteCommand comando = new SQLiteCommand(query, conexion))
            {
                comando.Parameters.AddWithValue("@id", id); //El id se debe de obtener contando el total de registros +1 y ese va ser el nuevo id
                comando.Parameters.AddWithValue("@nombre", nombre);
                comando.Parameters.AddWithValue("@apellido1", apellido1);
                comando.Parameters.AddWithValue("@apellido2", apellido2);
                    int filasInsertadas = comando.ExecuteNonQuery();
                Console.WriteLine($"Se inserto {filasInsertadas} la fila en la tabla.");
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
        return id;
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