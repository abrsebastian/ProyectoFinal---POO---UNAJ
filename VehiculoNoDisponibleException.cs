using System;

namespace tp
{
	
	public class VehiculoNoDisponibleException : Exception
	{
		public VehiculoNoDisponibleException()
			:base("Vehiculo no disponible.")
		{
		}
	}
}
