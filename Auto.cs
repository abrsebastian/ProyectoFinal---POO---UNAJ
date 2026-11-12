
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

			if (cajaAutomatica)
			{
				tipoDeTransmision = "Automatica";
			}
			else
			{
				tipoDeTransmision = "Manual";
			}

			switch (cantDePuertas)
			{
				case 2: tipoDeAuto = "Coupé"; break;
				case 3: tipoDeAuto = "Hatch 3 Puertas"; break;
				case 4: tipoDeAuto = "Sedán"; break;
				case 5: tipoDeAuto = "Hatch 5 Puertas"; break;
			}

			if(cantDePuertas < 2 || cantDePuertas > 5)
			{
				throw new ArgumentException("La cantidad de puertas ingresadas no es válida");
			}

			this.cantDePuertas=cantDePuertas;
			this.cajaAutomatica=cajaAutomatica;
			this.tipo = "Auto";
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

		public override void MostrarDatos()
		{
    		base.MostrarDatos();

    		Console.WriteLine("Tipo de Auto: " + tipoDeAuto);
    		Console.WriteLine("Transmisión: " + tipoDeTransmision);
			System.Console.WriteLine("El  precio por día: $" + base.precioxdia);
		}

        public override bool TieneSeguroAdicional()
        {
            return true;
        }


	}
}
