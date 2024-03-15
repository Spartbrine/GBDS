namespace Datos;
using MySql.Data.MySqlClient;
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

    protected string conexion = "server=localhost;user=root;password=;database=nombre_de_la_base_de_datos";
    public (string, string, string, string, string, string,string, int ) Datos() //Este metodo va recuperar todos los datos
    {
        
        return (Name, ApellidoPat, ApellidoMat, Direccion, TipoSangre, FactorRH, Estatus, Telefono);
    }

    public void RecuDatos()
    {
        //La tabla se llama DatosPersonales
        //El query sería algo así "SELECT {dato a recuperar (nombre de la columna)} FROM DatosPersonales WHERE {el identificador}" 
        // En caso de querer buscarlo con nombre y apellidos sería:
        // "SELECT {dato a recuperar} FROM DatosPersonales WHERE Nombre = @Name and Apellido1 = @ApellidoPat and Apellido2 = @ApellidoMat
        
        //La variable {dato a recuperar(osea la columna) se llama Colum}
        //Aqui se va tomar la query, la conexion y se ejecutaran las operaciones necesarias
        

    }

    public string columRecu(string datoRecu) //No se si ponerlo con numeros (Para opciones, sea tipo 1.- nombre, 2.- Apellido paterno, etc.)
    { /*En caso de ponerlo con numeros la logica debe estar en Operaciones*/
        string colum=""; //Esta parte de colum es para asignarle la columna a buscar en la base de datos
        //En este caso la bd solo tiene una entidad (una tabla), por lo que el FROM no va cambiar
        //Estaría bien buscar mediante ID unicamente?
        //Y en caso de perder la ID?
        //Y si es por nombre, puede ser solo con uno?
        switch(datoRecu.ToLower())
        {
            case "nombre":

            break;
            
            case "apellido 1":
            
            break;
            
            case "apellido 2":
            
            break;
            
            case "direccion":
            
            break;
            
            case "telefono":
            
            break;
            
            case "grupo sanguineo":
            
            break;
            
            case "factor rh":
            
            break;
        }

        return colum;
    }

}