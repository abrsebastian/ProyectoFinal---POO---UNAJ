
using System;

namespace tp
{
	
	public class Auto : Vehiculo , ISeguroAdicional
	{
		private int cantDePuertas;
		private bool cajaAutomatica;
		private string tipoDeAuto;
		private string tipoDeTransmision;
		
		public Auto (string patente, string marca, string modelo, int anio, float precioxdia, int cantDePuertas, bool cajaAutomatica)
			:base (patente, marca, modelo, anio, precioxdia)
		{
			this.cantDePuertas=cantDePuertas;
			this.cajaAutomatica=cajaAutomatica;
		}
		public override float CalcularAlquiler(int dias)
		{
			float total = PrecioxDia * dias;
			if (cajaAutomatica)
			{
				total = total * 1.10f;
			}
			return total;
		}
		public float CalcularSeguro (int dias)
		{
			return 8000 * dias;
		}

        public override void CargarDatosVehiculo(string marca, string modelo, string patente, int anio, float precioxdia)
        {
			System.Console.WriteLine("Ingrese la cantidad de puertas");
			cantDePuertas = Convert.ToInt32(Console.ReadLine());
			if(cantDePuertas != 2 || cantDePuertas != 3 || cantDePuertas != 4 || cantDePuertas != 5)
			{
				do
				{
					System.Console.WriteLine("El número de puertas ingresado no es válido, intente de nuevo");
					cantDePuertas = Convert.ToInt32(Console.ReadLine());
				}
				while(cantDePuertas != 2 || cantDePuertas != 3 || cantDePuertas != 4 || cantDePuertas != 5);

				switch (cantDePuertas)
				{
					case 2:
						tipoDeAuto = "Coupé";
					break;
					case 3:
						tipoDeAuto = "Hatch 3 puertas";
					break;
					case 4: 
						tipoDeAuto = "Sedan";
					break;
					case 5:
						tipoDeAuto = "Hatch 5 puertas";
					break;
					default: System.Console.WriteLine("Opción inválida");
					break;
				}
			}

			string opcion;
			System.Console.WriteLine("¿El auto es de transmisión Manual o Automática? (M/A)");
            opcion = Console.ReadLine().ToLower();
			
			if(opcion.ToLower() != "m" || opcion.ToLower() != "a")
			{
				do
				{
					System.Console.WriteLine("Opción inválida, ingrese (M/A)");
					opcion = Console.ReadLine().ToLower();
				}
				while(opcion.ToLower() != "m" || opcion.ToLower() != "a");
			}

			if(opcion.ToLower() == "m")
			{
				tipoDeTransmision = "Manual";
				cajaAutomatica = false;
			}
			if(opcion.ToLower() == "a")
			{
				tipoDeTransmision = "Automatica";
				cajaAutomatica = true;
			}

            base.CargarDatosVehiculo(marca, modelo, patente, anio, precioxdia);
        }
		public override void MostrarDatos()
		{
    		base.MostrarDatos();

    		Console.WriteLine("Puertas: " + cantDePuertas);
    		Console.WriteLine("Caja automática: " + cajaAutomatica);
		}


	}
}
