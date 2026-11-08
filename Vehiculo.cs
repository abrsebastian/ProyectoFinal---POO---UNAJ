
using System;

namespace tp
{
	
	public class Vehiculo
	{
		private string patente;
		private string marca;
		private string modelo;
		private int anio;
		private float precioxdia;
		private bool disponibilidad;
		
		public Vehiculo(string patente, string marca, string modelo, int anio, float precioxdia)
		{
			this.patente=patente;
			this.marca=marca;
			this.modelo=modelo;
			this.anio=anio;
			this.precioxdia=precioxdia;
			this.disponibilidad=true;
		}
		public virtual float CalcularAlquiler(int dias)
		{
			return precioxdia * dias;
		}
		public string Patente
		{
			get { return patente; }
		}
		public float PrecioxDia
		{ 
			get {return precioxdia;}
		}
		public bool Disponibilidad
		{
    		get { return disponibilidad; }
    		set { disponibilidad = value; }
		}
		public virtual void MostrarDatos()
		{
    		Console.WriteLine("Patente: {0} " + patente);
    		Console.WriteLine("Marca: {0}" + marca);
    		Console.WriteLine("Modelo: {0}" + modelo);
    		Console.WriteLine("Año: {0}" + anio);
		}
	}
}
