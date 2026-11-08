
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

        public override void CargarDatosVehiculo(string marca, string modelo, string patente, int anio, float precioxdia)
        {
			System.Console.WriteLine("Ingrese la cilindrada");
			cilindrada = Convert.ToInt32(Console.ReadLine());

            base.CargarDatosVehiculo(marca, modelo, patente, anio, precioxdia);
        }
	}
}
