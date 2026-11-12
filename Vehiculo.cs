
using System;
using System.Runtime.CompilerServices;

namespace tp
{
	
	public abstract class Vehiculo
	{
		protected string patente;
		protected string marca;
		protected string modelo;
		protected int anio;
		protected float precioxdia;
		protected bool disponibilidad;
		public string tipo;
		
		public Vehiculo(string patente, string marca, string modelo, int anio, float precioxdia)
		{
			this.patente=patente;
			this.marca=marca;
			this.modelo=modelo;
			this.anio=anio;
			this.precioxdia=precioxdia;
			this.disponibilidad=true;
		}
		
		public string Tipo
		{
			get{ return tipo;}
			protected set {}
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

		public virtual bool TieneSeguroAdicional()
    	{
        	return false;
    	}
		
		public virtual void MostrarDatos()
		{
    		Console.WriteLine("Patente: " + patente);
    		Console.WriteLine("Marca: " + marca);
    		Console.WriteLine("Modelo: " + modelo);
    		Console.WriteLine("Año: " + anio);
		}
	}
}
