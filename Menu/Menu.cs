namespace Menu;
class MenuPrincipal
{
    public static int Menu()
    {
        int opcion=0;
        Console.WriteLine("---Bienvenido al banco de sangre");
        Console.WriteLine("¿Qué desea hacer hoy? \n1.- Registrar usuario \n2.-Recuperar datos \n3.-Emparejar con un tipo de sangre \n4.-Dar de baja un usuario \n5.-Modificar los datos de un usuario");
            opcion= Convert.ToInt32(Console.ReadLine());    
        return opcion;
    }
}


      
    /*        Metodos       */
    /*    Registrar usuario */
    /*    Recuperar datos   */
    /*    Match sangre      */
    /*    Baja usuario      */
    /*    Modificar usuario */
    