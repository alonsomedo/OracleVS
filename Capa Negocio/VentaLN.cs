using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
	public class VentaLN
	{
		#region "PATRON SINGLETON"
		private static VentaLN obj = null;
		private VentaLN() { }
		public static VentaLN GetInstance()
		{
			if (obj == null)
			{
				obj = new VentaLN();
			}
			return obj;
		}
		#endregion

		public bool RegistrarVenta(Venta venta)
		{
			try
			{
				return VentaDAO.GetInstance().RegistrarVenta(venta);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public bool RegistrarDetalleVenta(DetalleVenta detalle)
		{
			try
			{
				return VentaDAO.GetInstance().RegistrarDetalleVenta(detalle);
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
		public string GenerarNroVenta()
		{
			try
			{
				return VentaDAO.GetInstance().GenerarNroVenta();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
	}
}
