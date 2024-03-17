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
    private string connectionString = @"Data Source=../BancoSangre;Version=3;";
    
    public void Registro()
    {
        using(SQLiteConnection conexion = new SQLiteConnection(connectionString))
        {
            conexion.Open();
        }
    }
    
     public void MatchSangre()
        {
            Console.Write("Tipo de sangre solicitante: ");
            string tipoSangre = Console.ReadLine();
            Console.Write("Factor RH del solicitante (+ o -): ");
            string factorRH = Console.ReadLine();

            string query = $"SELECT ts.id, ts.factor_rh, ts.tipo_sangre, du.Nombre, du.Apellido_paterno, du.Apellido_materno, du.Telefono, du.Direccion " +
                           $"FROM Datos_usuario du " +
                           $"JOIN Tipo_sangre ts " +
                           $"WHERE ts.estatus = 'Disponible' " +
                           $"AND (ts.tipo_sangre = '{tipoSangre}' AND ts.factor_rh = '{factorRH}');";

            using (SQLiteConnection conexion = new SQLiteConnection(this.connectionString))
            {
                conexion.Open();
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    using (SQLiteDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"ID: {reader["ID"]}, Nombre: {reader["Nombre"]}, Apellido: {reader["Apellido_paterno"]}");
                        }
                    }
                }
            }
        }

        public void AddBloodGroups()
        {
            string[] tiposSangre = { "A", "B", "AB", "O" };
            string[] factoresRH = { "+", "-" };

            using (SQLiteConnection conexion = new SQLiteConnection(this.connectionString))
            {
                conexion.Open();

                // Insertar los 8 grupos sanguíneos
                foreach (var tipo in tiposSangre)
                {
                    foreach (var factorRH in factoresRH)
                    {
                        string query = $"INSERT INTO Tipo_sangre(tipo_sangre, factor_rh, estatus) VALUES('{tipo}', '{factorRH}', 'Disponible');";
                        using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                        {
                            comando.ExecuteNonQuery();
                        }
                    }
                }
            }
        }
        public void ContadorDonantes()
        {
            string query = "SELECT tipo_sangre, factor_rh, COUNT(*) as total_donantes FROM Tipo_sangre GROUP BY tipo_sangre, factor_rh;";
            
            using (SQLiteConnection conexion = new SQLiteConnection(this.connectionString))
            {
                conexion.Open();
                
                using (SQLiteCommand comando = new SQLiteCommand(query, conexion))
                {
                    using (SQLiteDataReader reader = comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Console.WriteLine($"Tipo de sangre: {reader["tipo_sangre"]}, Factor RH: {reader["factor_rh"]}, Total de donantes: {reader["total_donantes"]}");
                        }
                    }
                }
            }
        }

}