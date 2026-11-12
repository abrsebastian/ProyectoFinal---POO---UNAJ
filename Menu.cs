using System.Net.WebSockets;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;
using tp;

public class Menu
{
    private Agencia agencia = new Agencia("Alquileres-UNAJ");
    bool continuar;
    string deseaContinuar = "";

    public void Iniciar()
    {
        List<Vehiculo> listaVehiculos = new List<Vehiculo>();
        int opcion = 0;

		Console.WriteLine("Bienvenido a Alquileres UNAJ.");
        System.Console.WriteLine("Presione una tecla para continuar");
		Console.ReadKey(true);

		do
		{
            System.Console.WriteLine("Elija una de las opciónes");
		    System.Console.WriteLine("1. Registrar un vehiculo a la agencia");
		    System.Console.WriteLine("2. Eliminar un vehiculo");
		    System.Console.WriteLine("3. Registrar un cliente");
		    System.Console.WriteLine("4. Realizar un alquiler");
		    System.Console.WriteLine("5. Mostrar listado de vehiculos");
		    System.Console.WriteLine("6. Mostrar historial de alquileres");
		    System.Console.WriteLine("7. Mostrar vehiculos que permiten seguro adicional unicamente");
		    System.Console.WriteLine("8. Salir");

            try
            {
                opcion = Convert.ToInt32(Console.ReadLine());
                
                switch (opcion)
                {
                    case 1:
                    	 SeleccionarTipoDeVehiculo();
					break;
                    case 2:
                        BuscarYEliminarVehiculo();
                    break;
                    case 3:
                        BuscarYRegistrarCliente();
                    break;
                    case 4:
                        AlquilarUnVehiculo();
                    break;
                    case 5:
                        MostrarListadoCompleto();
                    break;
                    case 6:
                        MostrarHistorialAlquileres();
                    break;
                    case 7:
                        agencia.MostrarAutosConSeguroAdicional();
                    break;
                    case 8:
                        System.Console.WriteLine("Saliendo del sistema...");
                    break;
                    default: System.Console.WriteLine("Opcion ingresada no valida");
                    break;

		        }
            }
            catch (FormatException)
            {
                System.Console.WriteLine("ERROR. Debe ingresarse un numero del 1 al 8");
                Console.ReadKey(true);
                opcion = 0;
            }
			
		}
			while(opcion != 8);

    }

    public void MostrarListadoCompleto()
    {
        agencia.MostrarVehiculos();
    }

    public void MostrarHistorialAlquileres()
    {
        agencia.MostrarHistorialAlquileres();
    }
    public void AlquilarUnVehiculo()
    {
        int dniIngresado = 0;
        string patenteIngresada = "";
        int diasIngresados = 0;
        bool validarDNI = false;
        bool validarPatente = false;
        bool validarDias = false;
        deseaContinuar = "";
        continuar = false;

        do
        {
            System.Console.WriteLine("REALIZAR UN ALQUILER");

            Cliente clienteAlquiler = null;
            bool clienteValido = false;


            while (!clienteValido)
            {
                try
                {
                    System.Console.WriteLine("Ingrese DNI");
                    dniIngresado = Convert.ToInt32(Console.ReadLine());

                    clienteAlquiler = agencia.BuscarCliente(dniIngresado);

                    if(clienteAlquiler != null)
                    {
                        System.Console.WriteLine("Cliente Encontrado:");
                        clienteAlquiler.MostrarDatosCliente();
                        clienteValido = true;
                    }
                    else
                    {
                        System.Console.WriteLine("No se ha encontrado cliente con ese DNI");
                        System.Console.WriteLine("¿Desea registrarlo? (s/n)");
                        deseaContinuar = Console.ReadLine().ToLower();

                        while(deseaContinuar != "s" && deseaContinuar != "n")
                        {
                            System.Console.WriteLine("Opción no valida, ingrese (s/n)");
                            deseaContinuar = Console.ReadLine();
                        }

                        if(deseaContinuar == "s")
                        {
                            BuscarYRegistrarCliente();

                            clienteAlquiler = agencia.BuscarCliente(dniIngresado);
                            if(clienteAlquiler != null)
                            {
                                clienteValido = true;
                            }
                            else
                            {
                                System.Console.WriteLine("El cliente registrado tiene un DNI distinto al buscado anteriormente.");
                                System.Console.WriteLine("Por favor, ingrese el DNI con el que desea realizar el alquiler:");
                            }
                        }
                        else
                        {
                            System.Console.WriteLine("Operación de alquiler cancelada");
                            return;
                        }
                    }
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("ERROR. Este campo tiene que ser completado con numeros enteros");
                }
            }

            Vehiculo vehiculoAlquiler = null;
            bool vehiculoValido = false;

            
            System.Console.WriteLine("LISTA DE AUTOS");
            agencia.MostrarAutos();
            System.Console.WriteLine("------------------------------------");
            System.Console.WriteLine("LISTA DE MOTOS");
            agencia.MostrarMotos();
            System.Console.WriteLine("------------------------------------");
            System.Console.WriteLine("LISTA DE CAMIONETAS");
            agencia.MostrarCamionetas();
            System.Console.WriteLine("------------------------------------");

            

            while (!vehiculoValido)
            {
                System.Console.WriteLine("Ingrese la patente del vehiculo que desea alquilar o presione X para salir");
                patenteIngresada = Console.ReadLine().ToUpper();

                if (patenteIngresada == "")
                {
                    System.Console.WriteLine("ERROR. La patente no puede estar vacía. Reintente:");
                }
                else
                {
                    vehiculoAlquiler = agencia.BuscarVehiculo(patenteIngresada);

                    if (vehiculoAlquiler != null)
                    {
                        System.Console.WriteLine("¡Vehículo seleccionado con éxito!");
                        vehiculoValido = true;
                    }
                    else
                    {
                    System.Console.WriteLine("No existe ningún vehículo registrado con la patente '" + patenteIngresada + "'. Reintente:");
                    }
                   
                }
                if(patenteIngresada == "X")
                {
                    System.Console.WriteLine("Volviendo al menu principal");
                    return;
                }
            }

            validarDias = false;

            while (!validarDias)
            {
                try
                {
                    
                    System.Console.WriteLine("Ingrese la cantidad de Dias que quiere alquilar el vehiculo");
                    diasIngresados = Convert.ToInt32(Console.ReadLine());

                    if(diasIngresados > 0)
                    {
                        validarDias = true;
                    }
                    else
                    {
                        System.Console.WriteLine("ERROR. La cantidad de dias debe ser mayor a cero");
                    }
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("ERROR. Este campo debe estars completo con numeros enteros");
                }
            }

            try
            {
                agencia.RealizarAlquiler(dniIngresado, patenteIngresada, diasIngresados);
            }
            catch (VehiculoNoDisponibleException)
            {
                System.Console.WriteLine("ERROR: El vehículo seleccionado no está disponible en este momento.");
            }
            
            System.Console.WriteLine("¿Desea realizar otra operacion? (s/n)");
            DeseaContinuar();
          }
        while(continuar); 




    }
    public void BuscarYRegistrarCliente()
    {
        bool validarDNI = false;
        bool validarTelefono = false;
        int dniIngresado = 0;
        int telefonoIngresado = 0;
        string nombreIngresado;
        string apellidoIngresado;


        do
        {

            validarDNI = false;
            validarTelefono = false;

            System.Console.WriteLine("BUSCAR Y REGISTRAR CLIENTE");
            System.Console.WriteLine("Ingrese Nombre");
            nombreIngresado = Console.ReadLine();
            System.Console.WriteLine("Ingrese Apellido");
            apellidoIngresado = Console.ReadLine();

            while (!validarDNI)
            {
                try
                {
                    System.Console.WriteLine("Ingrese DNI");
                    dniIngresado = Convert.ToInt32(Console.ReadLine());

                    Cliente clienteBuscado = agencia.BuscarCliente(dniIngresado);

                    if(clienteBuscado != null)
                    {
                        System.Console.WriteLine("Ya hay un cliente registrado con este DNI");
                        System.Console.WriteLine("Ingrese un DNI Valido");
                        dniIngresado = Convert.ToInt32(Console.ReadLine());
                        break;
                    }
                    else
                    {
                        validarDNI = true;
                    }
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("ERROR. Este campo tiene que ser completado con numeros enteros");
                }
            }

            while (!validarTelefono)
            {
                try
                {
                    System.Console.WriteLine("Ingrese un número de telefono");
                    telefonoIngresado = Convert.ToInt32(Console.ReadLine());

                    validarTelefono = true;
                }
                catch (FormatException)
                {
                    System.Console.WriteLine("Este campo tiene que ser completado con números enteros");
                }
            }

            agencia.RegistrarCliente(nombreIngresado, apellidoIngresado,telefonoIngresado, dniIngresado);

            System.Console.WriteLine("¿Desea registrar otro Cliente? (s/n)");
            DeseaContinuar();

        }
        while(continuar);
        
    }

    public void DeseaContinuar()
    {
        deseaContinuar = Console.ReadLine().ToLower();

            while(deseaContinuar != "s" && deseaContinuar != "n")
            {
                System.Console.WriteLine("La opción ingresada no es valida, ingrese (s/n)");
                 deseaContinuar = Console.ReadLine().ToLower();
            }

            if(deseaContinuar == "s")
            {
                continuar = true;
            }
            else
            {
                continuar = false;
            } 
    }

    public void BuscarYEliminarVehiculo()
    {

        string patenteEliminar = "";
        string confirmar = "";
        deseaContinuar = "";
        continuar = true;

        do
        {
            System.Console.WriteLine("OPCIÓN INGRESADA: ELIMINAR VEHICULO");
            System.Console.WriteLine("Ingrese la patente del vehiculo");
            patenteEliminar = Console.ReadLine().ToUpper();

            if(patenteEliminar == "")
            {
                System.Console.WriteLine("ERROR. Debe ingresar una patente");
                return;
            }
            else
            {
                Vehiculo vehiculoEncontrado = agencia.BuscarVehiculo(patenteEliminar);

                if(vehiculoEncontrado != null)
                {
                    System.Console.WriteLine("VEHICULO ENCONTRADO");
                    System.Console.WriteLine("-----------------------------------");
                    vehiculoEncontrado.MostrarDatos();
                    System.Console.WriteLine("-----------------------------------");

                    while(confirmar != "s" && confirmar != "n")
                    {
                        System.Console.WriteLine("¿Desea eliminar el vehiculo encontrado? (s/n)");
                        confirmar = Console.ReadLine().ToLower();

                        if(confirmar != "s" && confirmar != "n")
                        {
                            System.Console.WriteLine("Opción no valida. Ingrese (s/n)");
                        }
                        if(confirmar == "s")
                        {
                            agencia.EliminarVehiculo(patenteEliminar);
                        }
                        else
                        {
                            System.Console.WriteLine("Operación cancelada...");
                        }

                    }
                }
                else
                {
                    System.Console.WriteLine("No se ha encontrado vehiculo con esos datos");
                }
            }

            System.Console.WriteLine("¿Desea buscar/eliminar otro vehiculo? (s/n)");
            DeseaContinuar();  
        }
        while(continuar);
            
    }

    public void SeleccionarTipoDeVehiculo()
    {
        string tipoVehiculo = "";
        string marcaIngresada;
        string modeloIngresado;
        string patenteIngresada;
        int anioFabricacion = 0;
        float precioIngresado = 0;
        deseaContinuar = "";        
        continuar = true;
        bool anioValido;;
        bool patenteValida;
        bool precioValido;
        do
        {
            System.Console.WriteLine("¿Que tipo de vehiculo quiere registrar?");
			System.Console.WriteLine("a. Auto");
			System.Console.WriteLine("b. Camioneta");
			System.Console.WriteLine("c. Moto");
            System.Console.WriteLine("x. Volver atras");
            System.Console.WriteLine("Seleccione una opción (a/b/c)");

            tipoVehiculo = Console.ReadLine().ToLower();

            if(tipoVehiculo != "a" && tipoVehiculo != "b" && tipoVehiculo != "c" && tipoVehiculo != "x")
            {
                System.Console.WriteLine("La opción ingresada no es válida");
                System.Console.WriteLine("Por favor, ingrese (a/b/c)");
            }
        }
        while(tipoVehiculo != "a" && tipoVehiculo != "b" && tipoVehiculo != "c" && tipoVehiculo != "x");

        switch (tipoVehiculo)
        {
            case "a":
                do
                {   
                    precioValido = false;
                    anioValido = false;
                    patenteValida = false;
                    bool puertasValidas = false;
                    bool esAutomatico = false;
                    int puertasIngresadas = 0;
                    string respuestaAoM = "";

                    System.Console.WriteLine("OPCIÓN INGRESADA: AUTO");

                    System.Console.WriteLine("Ingrese la marca");
                    marcaIngresada = Console.ReadLine();
                    System.Console.WriteLine("Ingrese el modelo");
                    modeloIngresado = Console.ReadLine();
                    System.Console.WriteLine("Ingrese su patente");
                    patenteIngresada = Console.ReadLine().ToUpper();

                    while (!patenteValida)
                    {

                        if(patenteIngresada == "")
                        {
                            System.Console.WriteLine("ERROR. La patente no puede estar vacía. Reintente: ");
                        }
                        else if(agencia.BuscarVehiculo(patenteIngresada) != null)
                        {
                            System.Console.WriteLine("Ya existe un auto registrado con esta patente");
                            System.Console.WriteLine("Ingrese una patente válida:");
                            patenteIngresada = Console.ReadLine().ToUpper();
                        }
                        else
                        {
                            patenteValida = true;
                        }
                    }

                    System.Console.WriteLine("Ingrese el año de alta");

                    while (!anioValido)
                    {
                        try
                        {
                            anioFabricacion = Convert.ToInt32(Console.ReadLine());

                            if(anioFabricacion >= 2016 && anioFabricacion <= 2026)
                            {
                                anioValido = true;           
                            }
                            else
                            {
                                System.Console.WriteLine("El año debe ser entre 2016 y 2026");
                            }
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. en este campo debe ingresar números enteros");
                        }
                    }

                    System.Console.WriteLine("Ingrese la cantidad de Puertas");

                    while (!puertasValidas)
                    {
                        try
                        {
                            puertasIngresadas = Convert.ToInt32(Console.ReadLine());
                            if(puertasIngresadas >= 2 && puertasIngresadas <= 5)
                            {
                                puertasValidas = true;
                            }
                            else
                            {
                                System.Console.WriteLine("ERROR. La cantidad de puertas tiene que ser de 2, 3, 4 o 5. Reintente");
                                puertasIngresadas = Convert.ToInt32(Console.ReadLine());
                            }
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. Este campo requiere numeros enteros entre 2 y 5");
                        }
                    }


                    while(respuestaAoM != "m" && respuestaAoM != "a")
                    {
                        System.Console.WriteLine("¿El auto es de transmisión Manual o Automática? (m/a)");

                        respuestaAoM = Console.ReadLine().ToLower();

                        if(respuestaAoM != "m" && respuestaAoM != "a")
                        {
                            System.Console.WriteLine("La respuesta ingresada no es válida, ingrese (m/a)");
                        }
                        if(respuestaAoM.ToLower() == "a")
                        {
                            esAutomatico = true;
                        }
                        else
                        {
                            esAutomatico = false;
                        }
                    }

                    while (!precioValido)
                    {
                        try
                        {
                            System.Console.WriteLine("Ingrese el precio por día"); 
                            precioIngresado = float.Parse(Console.ReadLine());

                            if(precioIngresado <= 0)
                            {
                                System.Console.WriteLine("El precio no puede tener valores igual o menores a cero");
                            }
                            else if(precioIngresado > 0)
                            {
                                precioValido = true;
                            }
                            
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. Este campo tiene que ser completado con valores numéricos");
                        }
                    }

                    
                    Auto nuevoAuto = new Auto(patenteIngresada, marcaIngresada, modeloIngresado, anioFabricacion, precioIngresado, puertasIngresadas, esAutomatico);
                    agencia.AgregarVehiculo(nuevoAuto);

                    System.Console.WriteLine("¿Desea agregar otro auto? (s/n)");
                    DeseaContinuar();
                }
                while(continuar);
            break;

            case "b":
                do
                {   
                    precioValido = false;
                    anioValido = false;
                    patenteValida = false;
                    string respuesta4x4 = "";
                    int capacidadCarga = 0;
                    bool es4x4 = false;
                    bool validarCarga = false;
                    

                    System.Console.WriteLine("OPCIÓN INGRESADA: CAMIONETA");

                    System.Console.WriteLine("Ingrese la marca");
                    marcaIngresada = Console.ReadLine();
                    System.Console.WriteLine("Ingrese el modelo");
                    modeloIngresado = Console.ReadLine();
                    System.Console.WriteLine("Ingrese su patente");
                    patenteIngresada = Console.ReadLine().ToUpper();

                    while (!patenteValida)
                    {

                        if(patenteIngresada == "")
                        {
                            System.Console.WriteLine("ERROR. La patente no puede estar vacía. Reintente: ");
                        }
                        else if(agencia.BuscarVehiculo(patenteIngresada) != null)
                        {
                            System.Console.WriteLine("Ya existe un auto registrado con esta patente");
                            System.Console.WriteLine("Ingrese una patente válida:");
                            patenteIngresada = Console.ReadLine().ToUpper();
                        }
                        else
                        {
                            patenteValida = true;
                        }
                    }

                    System.Console.WriteLine("Ingrese el año de alta");

                    while (!anioValido)
                    {
                        try
                        {
                            anioFabricacion = Convert.ToInt32(Console.ReadLine());

                            if(anioFabricacion >= 2016 && anioFabricacion <= 2026)
                            {
                                anioValido = true;           
                            }
                            else
                            {
                                System.Console.WriteLine("El año debe ser entre 2016 y 2026");
                            }
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. en este campo debe ingresar números enteros");
                        }
                    }

                    System.Console.WriteLine("Ingrese la capacidad de Carga");

                    while (!validarCarga)
                    {
                        try
                        {
                            capacidadCarga = Convert.ToInt32(Console.ReadLine());
                            if(capacidadCarga >= 600 && capacidadCarga <= 1500)
                            {
                                validarCarga = true;
                            }
                            else
                            {
                                System.Console.WriteLine("ERROR. La carga debe ser entre 600 a 1500 kg");
                                System.Console.WriteLine("Ingrese un valor valido");
                            }
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. Este campo requiere numeros enteros entre 600 a 1500");
                        }
                    }


                    while(respuesta4x4 != "s" && respuesta4x4 != "n")
                    {
                        System.Console.WriteLine("¿La camioneta es 4x4? (s/n)");

                        respuesta4x4 = Console.ReadLine().ToLower();

                        if(respuesta4x4 != "s" && respuesta4x4 != "n")
                        {
                            System.Console.WriteLine("La respuesta ingresada no es válida, ingrese (s/n)");
                            respuesta4x4 = Console.ReadLine().ToLower();
                        }
                        if(respuesta4x4.ToLower() == "s")
                        {
                            es4x4 = true;
                        }
                        else
                        {
                            es4x4 = false;
                        }
                    }

                    while (!precioValido)
                    {
                        try
                        {
                            System.Console.WriteLine("Ingrese el precio por día"); 
                            precioIngresado = float.Parse(Console.ReadLine());

                            if(precioIngresado <= 0)
                            {
                                System.Console.WriteLine("El precio no puede tener valores igual o menores a cero");
                            }
                            else if(precioIngresado > 0)
                            {
                                precioValido = true;
                            }
                            
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. Este campo tiene que ser completado con valores numéricos");
                        }
                    }

                    
                    Camioneta nuevaCamioneta = new Camioneta(patenteIngresada, marcaIngresada, modeloIngresado, anioFabricacion, precioIngresado, capacidadCarga, es4x4);
                    agencia.AgregarVehiculo(nuevaCamioneta);

                    System.Console.WriteLine("¿Desea agregar otra Camioneta? (s/n)");
                    DeseaContinuar();
                }
                while(continuar); 

            break;

            case "c":

                do
                {   
                    precioValido = false;
                    anioValido = false;
                    patenteValida = false;
                    int cilindradaIngresada = 0;
                    bool validarCilindrada = false;
                    

                    System.Console.WriteLine("OPCIÓN INGRESADA: MOTO");

                    System.Console.WriteLine("Ingrese la marca");
                    marcaIngresada = Console.ReadLine();
                    System.Console.WriteLine("Ingrese el modelo");
                    modeloIngresado = Console.ReadLine();
                    System.Console.WriteLine("Ingrese su patente");
                    patenteIngresada = Console.ReadLine().ToUpper();

                    while (!patenteValida)
                    {

                        if(patenteIngresada == "")
                        {
                            System.Console.WriteLine("ERROR. La patente no puede estar vacía. Reintente: ");
                        }
                        else if(agencia.BuscarVehiculo(patenteIngresada) != null)
                        {
                            System.Console.WriteLine("Ya existe un auto registrado con esta patente");
                            System.Console.WriteLine("Ingrese una patente válida:");
                            patenteIngresada = Console.ReadLine().ToUpper();
                        }
                        else
                        {
                            patenteValida = true;
                        }
                    }

                    System.Console.WriteLine("Ingrese el año de alta");

                    while (!anioValido)
                    {
                        try
                        {
                            anioFabricacion = Convert.ToInt32(Console.ReadLine());

                            if(anioFabricacion >= 2016 && anioFabricacion <= 2026)
                            {
                                anioValido = true;           
                            }
                            else
                            {
                                System.Console.WriteLine("El año debe ser entre 2016 y 2026");
                            }
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. en este campo debe ingresar números enteros");
                        }
                    }

                    System.Console.WriteLine("Ingrese la cilindrada");

                    while (!validarCilindrada)
                    {
                        try
                        {
                            cilindradaIngresada = Convert.ToInt32(Console.ReadLine());
                            if(cilindradaIngresada >= 150 && cilindradaIngresada <= 500)
                            {
                                validarCilindrada = true;
                            }
                            else
                            {
                                System.Console.WriteLine("ERROR. La cilindrada debe ser de entre 150cc a 500cc");
                                System.Console.WriteLine("Ingrese un valor valido");
                            }
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. Este campo requiere numeros enteros entre 600 a 1500");
                        }
                    }


                    while (!precioValido)
                    {
                        try
                        {
                            System.Console.WriteLine("Ingrese el precio por día"); 
                            precioIngresado = float.Parse(Console.ReadLine());

                            if(precioIngresado <= 0)
                            {
                                System.Console.WriteLine("El precio no puede tener valores igual o menores a cero");
                            }
                            else if(precioIngresado > 0)
                            {
                                precioValido = true;
                            }
                            
                        }
                        catch (FormatException)
                        {
                            System.Console.WriteLine("ERROR. Este campo tiene que ser completado con valores numéricos");
                        }
                    }

                    
                    Moto nuevaMoto = new Moto(patenteIngresada, marcaIngresada, modeloIngresado, anioFabricacion, precioIngresado, cilindradaIngresada);
                    agencia.AgregarVehiculo(nuevaMoto);

                    System.Console.WriteLine("¿Desea agregar otra Moto? (s/n)");

                    DeseaContinuar();
                }
                while(continuar); 

            break;

            case "x":
                System.Console.WriteLine("Volviendo al menú principal...");
            break;
        }


    }
}