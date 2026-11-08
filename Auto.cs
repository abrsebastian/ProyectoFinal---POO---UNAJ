
using System;

namespace tp
{
	
	public class Auto : Vehiculo , ISeguroAdicional
	{
		private int cantDePuertas;
		private bool cajaAutomatica;
		
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
		public override void MostrarDatos()
		{
    		base.MostrarDatos();

    		Console.WriteLine("Puertas: " + cantDePuertas);
    		Console.WriteLine("Caja automática: " + cajaAutomatica);
		}
	}
}
