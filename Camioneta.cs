
using System;

namespace tp
{
	public class Camioneta : Vehiculo, ISeguroAdicional
	{
		private int capacidadCarga;
		private bool es4x4;
		private string traccion; 
		string tipoDeCamioneta;

		//600 a 1200 livianas, 850 a 1100 medianas 1500 a 3000 pesadas
		
		public Camioneta(string patente, string marca, string modelo, int anio, float precioxdia, int capacidadCarga, bool es4x4)
			:base (patente, marca, modelo, anio, precioxdia)
		{	
			if(capacidadCarga < 600 || capacidadCarga > 1500)
			{
				throw new ArgumentException("La capacidad de carga debe estar entre 600 a 1500 kg");
			}

			if (es4x4){traccion = "4x4";}
			else{traccion = "Trasera";}

			if(capacidadCarga >= 600 && capacidadCarga <= 800) {tipoDeCamioneta = "Liviana";}
			if(capacidadCarga > 800 && capacidadCarga <= 1200) {tipoDeCamioneta = "Mediana";}
			if(capacidadCarga > 1200 && capacidadCarga <= 1500) {tipoDeCamioneta = "Pesada";}

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
