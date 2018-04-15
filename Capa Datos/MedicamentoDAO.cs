using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
	public class MedicamentoDAO
	{
		#region "PATRON SINGLETON"
		private static MedicamentoDAO DaoMedicamento = null;
		private MedicamentoDAO() { }
		public static MedicamentoDAO GetInstance()
		{
			if (DaoMedicamento == null)
			{
				DaoMedicamento = new MedicamentoDAO();
			}
			return DaoMedicamento;
		}
		#endregion

		public List<Medicamento> ListarMedicamento()
		{
			List<Medicamento> lista = new List<Medicamento>();
			OracleConnection cn = null;
			OracleCommand cmd = null;
			OracleDataReader dr = null;
			try
			{
				cn = Conexion.GetInstance().ConexionDB();
				cmd = new OracleCommand("SP_LISTAMEDICAMENTOS", cn);
				cmd.CommandType = CommandType.StoredProcedure;
				cn.Open();
				dr = cmd.ExecuteReader();

				while (dr.Read())
				{
					Medicamento ObjMedicamento = new Medicamento()
					{
						CodMedicamento = Convert.ToString(dr[0]),
						Descripcion = Convert.ToString(dr[1]),
						PrecioCompra = Convert.ToDecimal(dr[2]),
						PrecioVenta = Convert.ToDecimal(dr[3]),
						Stock = Convert.ToInt32(dr[4]),
						StockMinimo = Convert.ToInt32(dr[5]),
						FechaVencimiento = Convert.ToDateTime(dr[6].ToString()).ToShortDateString(),

                        TipoMedicamento = new TipoMedicamento()
						{
							Descripcion = Convert.ToString(dr[7]),
						},

						Proveedor = new Proveedor()
						{
							RazonSocial = dr[8].ToString()
						}

					};
					lista.Add(ObjMedicamento);
				}
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				cn.Close();
			}
			return lista;

		}

        public bool RegistrarMedicamento(Medicamento objMedicamento)
        {
            OracleCommand cmd = null;
            OracleConnection cn = null;
            bool resultado = false;
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_REGMEDICAMENTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@CODMEDICAMENTO", objMedicamento.CodMedicamento);
                cmd.Parameters.Add("@DESCRIPCION", objMedicamento.Descripcion);
                cmd.Parameters.Add("@PRECOMPRA", objMedicamento.PrecioCompra);
                cmd.Parameters.Add("@PREVENTA", objMedicamento.PrecioVenta);
                cmd.Parameters.Add("@STOCK", objMedicamento.Stock);
                cmd.Parameters.Add("@STOCKMINIMO", objMedicamento.StockMinimo);
                cmd.Parameters.Add("@FECHA", objMedicamento.FechaVencimiento);
                cmd.Parameters.Add("@TIPMEDICAMENTO", objMedicamento.TipoMedicamento.Descripcion);
                cmd.Parameters.Add("@RUC", objMedicamento.Proveedor.RUC);
                cn.Open();
                resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;

            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally {
                cn.Close();
            }
            return resultado;
        }

        public List<TipoMedicamento> ListarTipoMedicamento()
        {
            OracleConnection cn = null;
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            List<TipoMedicamento> lista = new List<TipoMedicamento>();
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_LISTATIPOMEDICAMENTO", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoMedicamento objTipoMedicamento = new TipoMedicamento()
                    {
                        IdTipoMedicamento = Convert.ToInt16(dr[0].ToString()),
                        Descripcion = dr[1].ToString()

                    };
                    lista.Add(objTipoMedicamento);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }

    }
}
