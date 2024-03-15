namespace Datos;
abstract class DatosCli
{
    protected string factorRH, nombre, apellido1, apellido2, direccion, estatus, grupoSanguineo;
    protected int telefono;
    public virtual string TipoSangre
    {
        get{return grupoSanguineo;} set{grupoSanguineo=value;}
    }

    public virtual string FactorRH
    {
        get{return factorRH;} set{factorRH=value;}
    }
    public virtual string Name
    {
        get{return nombre;} set{nombre=value;}
    }
    public virtual string Direccion
    {
        get{return direccion;} set{direccion=value;}
    }
    public virtual string ApellidoPat
    {
        get{return apellido1;} set{apellido2=value;}
    }
    public virtual string ApellidoMat
    {
        get{return apellido2;} set{apellido2= value;}
    }
    public virtual string Estatus
    {
        get{return estatus;} set{estatus=value;}
    }
    public virtual int Telefono
    {
        get{return telefono;} set{telefono=value;}
    }
    
}

