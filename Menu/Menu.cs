namespace Menu;
class MenuPrincipal
{
    public static void Menu(out int opcion)
    {
        
        Console.WriteLine("---Bienvenido al banco de sangre---");
        Console.WriteLine("¿Qué desea hacer hoy? \n1.- Registrar usuario \n2.-Recuperar datos \n3.-Emparejar con un tipo de sangre \n4.-Dar de baja un usuario \n5.-Modificar los datos de un usuario \n6.- Total de donante por tipo de sangre");
            opcion= Convert.ToInt32(Console.ReadLine());    
        
    }
}


      
    /*        Metodos       */
    /*    Registrar usuario */
    /*    Recuperar datos   */
    /*    Match sangre      */
    /*    Baja usuario      */
    /*    Modificar usuario */
    /*    Contador de cada tipo de sangre */
    