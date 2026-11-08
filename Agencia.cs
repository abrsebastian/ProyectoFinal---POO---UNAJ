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
		public void AgregarVehiculo(Vehiculo v)
		{

			vehiculos.Add(v);
		}

		public void MostrarVehiculos()
		{
			foreach (Vehiculo v in vehiculos)
			{
				v.MostrarDatos();
			}
		}

		public void EliminarVehiculo(string buscarPatente)
		{
			Vehiculo vehiculoEncontrado = null;
			foreach(Vehiculo v in vehiculos)
			{
				if(v.Patente == buscarPatente)
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
			System.Console.WriteLine("Ingrese el nombre del Cliente:");
			nombre = Console.ReadLine();

			System.Console.WriteLine("Ingrese el apellido:");
			apellido = Console.ReadLine();

			System.Console.WriteLine("Ingrese el DNI");
			dni = Convert.ToInt32(Console.ReadLine());

			System.Console.WriteLine("Ingrese el número de telefono");
			telefono = Convert.ToInt32(Console.ReadLine());

			Cliente nuevoCliente = new Cliente(nombre,apellido,dni, telefono);

			clientes.Add(nuevoCliente);

			System.Console.WriteLine("Cliente agregado con éxito.");
		}

		public void RealizarAlquiler(int dni, string patente, int dias)
		{
			System.Console.WriteLine("Ingrese el DNI del cliente:");
			Cliente clienteEncontrado = null;
			foreach (Cliente c in clientes)
			{
				if(c.Dni == dni)
				{
					clienteEncontrado = c;
					break;
				}			
			}
			if (clienteEncontrado == null)
			{
				Console.WriteLine("Cliente no encontrado.");
				return;
			}
			
			Vehiculo vehiculoEncontrado = null;
			foreach (Vehiculo v in vehiculos)
			{
				if (v.Patente == patente)
				{
					vehiculoEncontrado = v;
					break;
				}
			}
			if (vehiculoEncontrado == null)
			{
				Console.WriteLine("Vehiculo no encontrado.");
				return;
			}
			if (!vehiculoEncontrado.Disponibilidad)
			{
    			throw new VehiculoNoDisponibleException();
			}		
			
			vehiculoEncontrado.Disponibilidad = false;			

			float total = vehiculoEncontrado.CalcularAlquiler(dias);
			
			Alquiler nuevoAlquiler = new Alquiler(clienteEncontrado, vehiculoEncontrado, dias, total);
			
			alquileres.Add(nuevoAlquiler);
		}

		public void MostrarClientes()
		{
			foreach(Cliente c in clientes)
			{
				c.MostrarDatosCliente();
			}
		}

		public void MostrarAlquileres()
		{
			foreach(Alquiler al in alquileres)
			{
				al.MostrarDatosAlquiler();
			}
		}

		
	
	}
}
