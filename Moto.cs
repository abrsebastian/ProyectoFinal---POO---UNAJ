
using System;

namespace tp
{
	public class Moto : Vehiculo
	{
		private int cilindrada;
		
		public Moto(string patente, string marca, string modelo, int anio, float precioxdia, int cilindrada)
			:base(patente, marca, modelo, anio, precioxdia)
		{
			this.cilindrada=cilindrada;
		}
		public override float CalcularAlquiler(int dias)
		{
			float total = PrecioxDia * dias;
			if (cilindrada < 250)
			{
				total= total * 0.85f;
			}
			return total;
		}
		public override void MostrarDatos()
		{
			base.MostrarDatos();
			
			Console.WriteLine("Cilindrada: " + cilindrada);
		}
		
	}
}
