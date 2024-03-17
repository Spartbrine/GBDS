class MenuPrincipal
{
    public static void Menu(out int opcion)
    {
        Console.WriteLine("------------------------------");
        Console.WriteLine("Bienvenido al Banco de Sangre");
        Console.WriteLine("------------------------------");
        Console.WriteLine("¿Qué desea hacer hoy?");
        Console.WriteLine("1. Registrar usuario");
        Console.WriteLine("2. Recuperar datos");
        Console.WriteLine("3. Emparejar con un tipo de sangre");
        Console.WriteLine("4. Dar de baja un usuario");
        Console.WriteLine("5. Modificar los datos de un usuario");
        Console.WriteLine("6. Total de donantes por tipo de sangre");
        Console.WriteLine("7. Salir del programa");
        Console.Write("Ingrese su opción: ");
        
        opcion = Convert.ToInt32(Console.ReadLine());
    }
}


      
    /*        Metodos       */
    /*    Registrar usuario */
    /*    Recuperar datos   */
    /*    Match sangre      */
    /*    Baja usuario      */
    /*    Modificar usuario */
    /*    Contador de cada tipo de sangre */
    