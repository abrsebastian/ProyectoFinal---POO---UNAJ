using System;

namespace tp
{
	public class Cliente
	{
		private string nombre;
		private string apellido;
		private int dni;
		private int telefono;
		
		public Cliente(string nombre, string apellido, int dni, int telefono)
		{
			this.nombre=nombre;
			this.apellido=apellido;
			this.dni=dni;
			this.telefono=telefono;
		}
		public int Dni
		{
			get { return dni;}
		}
		public string Nombre
		{
			get { return nombre;}
		}
		
		public string Apellido
		{
			get { return apellido;}
		}
		
		public int Telefono
		{
			get { return telefono;}
		}
		
		public void MostrarDatosCliente()
		{	
			System.Console.WriteLine("----------------------------------------");
			System.Console.WriteLine("Nombre: {0}", nombre);
			System.Console.WriteLine("Apellido: {0}", apellido);
			System.Console.WriteLine("DNI: {0}", dni);
			System.Console.WriteLine("Teléfono: {0}", telefono);
		}
	}
}
