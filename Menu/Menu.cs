namespace Menu;
class MenuPrincipal
{
    public static void Menu(out int opcion)
    {
        
        Console.WriteLine("---Bienvenido al banco de sangre---");
        Console.WriteLine("¿Qué desea hacer hoy? \n1.- Registrar usuario \n2.- Recuperar datos \n3.- Emparejar con un tipo de sangre \n4.- Cambiar estatus de un usuario \n5.- Modificar los datos de un usuario \n6.- Total de donantes por tipo de sangre \n7.-Salir");
            opcion= Convert.ToInt32(Console.ReadLine());    
        
    }
}

    /*        Metodos       */
    /*    Registrar usuario */ //Completo
    /*    Recuperar datos   */ //Completo
    /*    Match sangre      */ //Proceso
    /*    Baja usuario      */ //Completo (Lo cambie por cambiar estatus, porque puede pasar de baja temporal a disponible)
    /*    Modificar usuario */ //Completo
    /*    Contador de cada tipo de sangre */ //Completo