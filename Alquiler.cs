using System;

namespace tp
{
	public class Alquiler
	{
		private Cliente cliente;
		private Vehiculo vehiculo;
		private int dias;
		private float total;
	
		public Alquiler(Cliente cliente, Vehiculo vehiculo, int dias, float total)
		{
    		this.cliente = cliente;
    		this.vehiculo = vehiculo;
    		this.dias = dias;
    		this.total = total;
		}

		public Cliente Cliente
		{
			get{return Cliente;}
		}

		public Vehiculo Vehiculo
		{
			get{return Vehiculo;}
		}

		public int Dias
		{
			get{return dias;}
		}
		
		public float Total
		{
			get{return total;}
		}

		public void MostrarDatosAlquiler()
		{	
			System.Console.WriteLine("----------------------------------------- ");
			System.Console.WriteLine("Datos del alquiler:");
			System.Console.WriteLine("-----------------------------------------");
			cliente.MostrarDatosCliente();
			System.Console.WriteLine("-----------------------------------------");
			vehiculo.MostrarDatos();
			System.Console.WriteLine("-----------------------------------------");
			System.Console.WriteLine("Dias: " + dias);
			System.Console.WriteLine("Total: " + total);
			System.Console.WriteLine("-----------------------------------------");

		}
	}


}
