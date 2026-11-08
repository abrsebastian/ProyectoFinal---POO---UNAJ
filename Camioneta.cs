
using System;

namespace tp
{
	public class Camioneta : Vehiculo, ISeguroAdicional
	{
		private int capacidadCarga;
		private bool es4x4;
		
		public Camioneta(string patente, string marca, string modelo, int anio, float precioxdia, int capacidadCarga, bool es4x4)
			:base (patente, marca, modelo, anio, precioxdia)
		{
			this.capacidadCarga=capacidadCarga;
			this.es4x4=es4x4;
		}
		public override float CalcularAlquiler(int dias)
		{
			float total = PrecioxDia * dias;
			if (es4x4)
			{
				total = total + (5000 * dias);
			}
			return total;
		}
		public float CalcularSeguro (int dias)
		{ 
			return 12000 * dias;
		}
		public override void MostrarDatos()
		{
			base.MostrarDatos();
			
			Console.WriteLine("Capacidad de carga: " + capacidadCarga);
			Console.WriteLine("Es 4x4: "+ es4x4);
		}
	}
}
