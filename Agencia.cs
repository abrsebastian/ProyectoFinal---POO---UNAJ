using System;
using System.Collections.Generic;

namespace tp
{
	public class Agencia
	{
		private string nombre;
		private List<Vehiculo> vehiculos;
		private HashSet<Cliente> clientes;
		private List<Alquiler> alquileres;
		
		public Agencia (string nombre)
		{
			this.nombre=nombre;
			this.vehiculos = new List<Vehiculo>();
			this.clientes = new HashSet<Cliente>();
			this.alquileres = new List<Alquiler>();
		}

		public void MostrarAutos()
    {
        int contador = 0;

        foreach (Vehiculo v in vehiculos)
        {
            if (v.tipo == "Auto")
            {
                v.MostrarDatos();
                System.Console.WriteLine("---------------------------------------------");
                contador++;
            }
        }

        if (contador == 0)
        {
            System.Console.WriteLine("No hay autos registrados.");
        }
    }

    public void MostrarCamionetas()
    {
        int contador = 0;

        foreach (Vehiculo v in vehiculos)
        {
            if (v.tipo ==  "Camioneta")
            {
                v.MostrarDatos();
                System.Console.WriteLine("---------------------------------------------");
                contador++;
            }
        }

        if (contador == 0)
        {
            System.Console.WriteLine("No hay camionetas registradas.");
        }
    }

    public void MostrarMotos()
    {
        int contador = 0;

        foreach (Vehiculo v in vehiculos)
        {
            if (v.tipo == "Moto")
            {
                v.MostrarDatos();
                System.Console.WriteLine("---------------------------------------------");
                contador++;
            }
        }

        if (contador == 0)
        {
            System.Console.WriteLine("No hay motos registradas.");
        }
    }

	public void AgregarVehiculo(Vehiculo v)
	{
		if(v != null)
		{
			vehiculos.Add(v);
			System.Console.WriteLine("Vehiculo registrado con éxito");
		}
	}

	public void MostrarVehiculos()
	{

		if(vehiculos.Count == 0)
		{
			System.Console.WriteLine("No hay vehiculos registrados en la agencia");
		}
		else
		{
			foreach (Vehiculo v in vehiculos)
			{
				v.MostrarDatos();
			}
		}
	}

	public void EliminarVehiculo(string buscarPatente)
	{
		Vehiculo vehiculoEncontrado = null;
		foreach(Vehiculo v in vehiculos)
		{
			if(v.Patente.ToUpper() == buscarPatente)
			{
				vehiculoEncontrado = v;
				vehiculos.Remove(v);

				System.Console.WriteLine("El vehiculo {0} ha sido removido de la lista." + v.MostrarDatos);
				break;
			}
		}
		if(vehiculoEncontrado == null)
		{
			System.Console.WriteLine("No se ha encontrado un vehiculo con esos datos");
			return;
		}
	}

	public void RegistrarCliente(string nombre, string apellido, int telefono, int dni)
	{
		Cliente nuevoCliente = new Cliente(nombre,apellido,dni, telefono);
		clientes.Add(nuevoCliente);

		System.Console.WriteLine("Cliente agregado con éxito.");
	}

	public Cliente BuscarCliente(int dni)
	{
		foreach(Cliente c in clientes)
		{
			if(c.Dni == dni)
			{
				return c;
			}
		}
		
		return null;
	}

	public Vehiculo BuscarVehiculo(string patente)
	{
	foreach(Vehiculo v in vehiculos)
	{
		if(v.Patente.ToUpper() == patente)
			{
				return v;
			}
		}
		return null;
	}
	public void MostrarAutosConSeguroAdicional()
	{	
		int contador = 0;
		foreach(Vehiculo v in vehiculos)
		{
			if (v.TieneSeguroAdicional())
			{
				v.MostrarDatos();
				System.Console.WriteLine("------------------------------");
				contador++;
			}
		}
		if(contador == 0)
		{
			System.Console.WriteLine("No hay autos con seguro adicional");
		}
	}
	public void RealizarAlquiler(int dni, string patente, int dias)
	{
		Cliente clienteEncontrado = BuscarCliente(dni);
		
		if(clienteEncontrado == null)
		{
			System.Console.WriteLine("Cliente no encontrado");
			return;
		}
		Vehiculo vehiculoEncontrado = BuscarVehiculo(patente);
		if (!vehiculoEncontrado.Disponibilidad)
		{
			throw new VehiculoNoDisponibleException();
		}
		vehiculoEncontrado.Disponibilidad = false;
		float total = vehiculoEncontrado.CalcularAlquiler(dias);
		Alquiler nuevoAlquiler = new Alquiler(clienteEncontrado, vehiculoEncontrado, dias, total);
		alquileres.Add(nuevoAlquiler);
		System.Console.WriteLine("El alquiler fue concretado con exito");
	}
	public void MostrarClientes()
	{
		foreach(Cliente c in clientes)
		{
			c.MostrarDatosCliente();
		}
	}
	

	public void MostrarHistorialAlquileres()
	{
    	if (alquileres.Count == 0)
    	{
        	System.Console.WriteLine("No hay alquileres registrados en el historial.");
			System.Console.WriteLine("--------------------------------------------------");
    	}
    	else
    	{
        	foreach (Alquiler a in alquileres)
        	{
            	a.MostrarDatosAlquiler();
        	}
    	}
	}
}

}

