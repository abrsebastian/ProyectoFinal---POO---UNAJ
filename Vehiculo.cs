
using System;
using System.Runtime.CompilerServices;

namespace tp
{
	
	public class Vehiculo
	{
		protected string patente;
		protected string marca;
		protected string modelo;
		protected int anio;
		protected float precioxdia;
		protected bool disponibilidad;
		
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

		/*public virtual void CargarDatosVehiculo(string marca, string modelo, string patente, int anio, float precioxdia)
		{
			System.Console.WriteLine("Ingrese Marca del vehiculo:");
			marca = Console.ReadLine();
			System.Console.WriteLine("Ingrese Modelo del vehiculo");
			modelo = Console.ReadLine();
			System.Console.WriteLine("ingrese la Patente del Vehiculo");
			patente = Console.ReadLine();
			System.Console.WriteLine("Ingrese el año del vehiculo");
			anio = Convert.ToInt32(Console.ReadLine());
			System.Console.WriteLine("Ingrese el precio por dia");
			precioxdia = float.Parse(Console.ReadLine());
		}*/
		
		public virtual void MostrarDatos()
		{
    		Console.WriteLine("Patente: " + patente);
    		Console.WriteLine("Marca: " + marca);
    		Console.WriteLine("Modelo: " + modelo);
    		Console.WriteLine("Año: " + anio);
		}
	}
}
