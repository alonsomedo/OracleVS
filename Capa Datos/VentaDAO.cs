using System;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;

namespace Capa_Datos
{
	public class VentaDAO
	{
		#region "PATRON SINGLETON"
		private static VentaDAO venta = null;

		private VentaDAO() { }
		public static VentaDAO GetInstance()
		{
			if (venta == null)
			{
				venta = new VentaDAO();
			}
			return venta;
		}
		#endregion

		public bool RegistrarVenta(Venta venta)
		{
			bool resultado = false;
			OracleConnection cn = null;
			OracleCommand cmd = null;

			try
			{
				cn = Conexion.GetInstance().ConexionDB();

				cmd = new OracleCommand("SP_REGVENTA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@CODVENTA", venta.CodVenta);
				cmd.Parameters.Add("@FECVENTA", venta.FecVenta);
				cmd.Parameters.Add("@IGV", venta.Igv);
				cmd.Parameters.Add("@TOTAL", venta.Total);
				cmd.Parameters.Add("@IDUSUARIO", venta.Usuario.Username);
				cn.Open();
				resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;
			}
			catch (OracleException ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}
			
			return resultado;
		}
		public bool RegistrarDetalleVenta(DetalleVenta obj)
		{
			bool resultado = false;
			OracleConnection cn = null;
			OracleCommand cmd = null;

			try
			{
				cn = Conexion.GetInstance().ConexionDB();

				cmd = new OracleCommand("SP_REGDETALLEVENTA", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cmd.Parameters.Add("@PREUNITARIO", obj.Precio);
				cmd.Parameters.Add("@CANTIDAD", obj.Cantidad);
				cmd.Parameters.Add("@SUBTOTAL", obj.Subtotal);
				cmd.Parameters.Add("@CODMEDICAMENTO", obj.Medicamento.CodMedicamento);
				cmd.Parameters.Add("@CODVENTA", obj.Venta.CodVenta);
				cn.Open();
				resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;

			}
			catch (OracleException ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}

			return resultado;
		}
		public string GenerarNroVenta()
		{
			string codigo_venta = string.Empty;
			int valor = 0;
			int year = DateTime.Today.Year;
			string substring = string.Empty;

			OracleConnection cn = null;
			OracleCommand cmd = null;
			OracleDataReader dr = null;
			try
			{
				cn = Conexion.GetInstance().ConexionDB();

				cmd = new OracleCommand("select top 1 CODVENTA FROM VENTA ORDER BY CODVENTA DESC", cn);
				cn.Open();
				dr = cmd.ExecuteReader();

				if (dr.Read())
				{
					if (Convert.ToString(dr[0]).ToString().Length >= 1)
					{
						substring = Convert.ToString(dr[0]).Substring(5);
					}
					else
					{
						substring = "0";
					}

					substring = Convert.ToString(dr[0]).Substring(5);
					valor = Convert.ToInt32(substring) + 1;

					if (valor < 10)
					{
						codigo_venta = string.Format("V" + "{0}" + "0000" + "{1}", year.ToString(), valor.ToString());
					}
					if (valor >= 10)
					{
						codigo_venta = string.Format("V" + "{0}" + "000" + "{1}", year.ToString(), valor.ToString());
					}
					if (valor >= 100)
					{
						codigo_venta = string.Format("V" + "{0}" + "00" + "{1}", year.ToString(), valor.ToString());
					}
					if (valor >= 1000)
					{
						codigo_venta = string.Format("V" + "{0}" + "0" + "{1}", year.ToString(), valor.ToString());
					}
				}
				else
				{
					codigo_venta = string.Format("V" + "{0}" + "00001", year.ToString());
				}
			}
			catch (OracleException ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}
			return codigo_venta;

		}
	}
}
