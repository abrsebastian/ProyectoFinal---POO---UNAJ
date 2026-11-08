
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

        public override void CargarDatosVehiculo(string marca, string modelo, string patente, int anio, float precioxdia)
        {
			System.Console.WriteLine("¿Que capacidad de carga tiene?");
			capacidadCarga = Convert.ToInt32(Console.ReadLine());

			if(capacidadCarga < 600)
			{
				do
				{
					System.Console.WriteLine("La capacidad mínima no puede ser menor a 600kg");
					capacidadCarga  = Convert.ToInt32(Console.ReadLine());
				}
				while(capacidadCarga < 600);
			}
			if(capacidadCarga > 1500)
			{
				do
				{
					System.Console.WriteLine("La capacidad de carga no puede superar los 2000kg");
					capacidadCarga = Convert.ToInt32(Console.ReadLine());
				}
				while(capacidadCarga > 1500);
			}
			if(capacidadCarga >= 600 || capacidadCarga <= 800)
			{
				tipoDeCamioneta = "Liviana";
			}
			if(capacidadCarga > 800 || capacidadCarga <= 1200)
			{
				tipoDeCamioneta = "Mediana";
			}
			if(capacidadCarga > 1200 || capacidadCarga <= 1500)
			{
				tipoDeCamioneta = "Pesada";
			}

			string opcion = "";
			System.Console.WriteLine("¿Es tracción 4x4? (S/N)");

			opcion = Console.ReadLine().ToLower();

			if(opcion.ToLower() != "s" || opcion.ToLower() != "n")
			{
				do
				{
					System.Console.WriteLine("La opción ingresada no es válida, ingrese (S/N)");
					opcion = Console.ReadLine().ToLower();
				}
				while(opcion.ToLower() != "s" || opcion.ToLower() != "n");
			}

			if(opcion.ToLower() == "s")
			{
				traccion = "4x4";
				es4x4 = true;
			}
			else if(opcion.ToLower() == "n")
			{
				traccion = "Trasera";
				es4x4 = false;
			}	

            base.CargarDatosVehiculo(marca, modelo, patente, anio, precioxdia);
        }
		public override void MostrarDatos()
		{
			base.MostrarDatos();
			
			Console.WriteLine("Capacidad de carga: " + capacidadCarga);
			Console.WriteLine("Es 4x4: "+ es4x4);
		}
	}
}
