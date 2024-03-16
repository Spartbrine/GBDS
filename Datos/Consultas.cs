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
    string connectionString = @"Data Source=../;Version=3;";
    
    public void Registro()
    {

    }

}