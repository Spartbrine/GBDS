namespace Datos;
abstract class DatosCli //Con la separación de achivos tiene más sentido utilizar abstract
{
    protected string factorRH, nombre, apellido1, apellido2, direccion, estatus, grupoSanguineo, descripcion;
    protected string telefono;
    public virtual string Desc
    {
        get{return descripcion;} set{descripcion=value;}
    }
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
        get{return apellido1;} set{apellido1=value;}
    }
    public virtual string ApellidoMat
    {
        get{return apellido2;} set{apellido2= value;}
    }
    public virtual string Estatus
    {
        get{return estatus;} set{estatus=value;}
    }
    public virtual string Telefono
    {
        get{return telefono;} set{telefono=value;}
    }
    
}

