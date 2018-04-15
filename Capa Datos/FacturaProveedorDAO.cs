using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Capa_Entidades;

namespace Capa_Datos
{
    public class FacturaProveedorDAO
    {
        #region "PATRON SINGLETON"
        private static FacturaProveedorDAO objFacturaDAO = null;
        private FacturaProveedorDAO() { }
        public static FacturaProveedorDAO GetInstance()
        {
            if (objFacturaDAO == null)
            {
                objFacturaDAO = new FacturaProveedorDAO();
            }
            return objFacturaDAO;
        }

        #endregion
        public bool RegistrarFacturaProveedor(FacturaProveedor objFactura)
        {
            OracleConnection cn = null;
            OracleCommand cmd = null;
            bool resultado = false;

            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_REGISTRARFACTURA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NROFACTURA", objFactura.NroFactura);
                cmd.Parameters.Add("@FECHA", objFactura.FecFactura);
                cmd.Parameters.Add("@TOTAL", objFactura.Total);
                cmd.Parameters.Add("@RUCPRO", objFactura.Proveedor.RUC);
                cn.Open();
                resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return resultado;

        }

        public bool RegistrarDetalleFacturaProveedor(DetalleFacturaProveedor objDetalleFactura)
        {
            bool resultado = false;
            OracleCommand cmd = null;
            OracleConnection cn = null;
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_REGDETALLEFACTURA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@PREUNITARIO", objDetalleFactura.PreUnitario);
                cmd.Parameters.Add("@CANTIDAD", objDetalleFactura.Cantidad);
                cmd.Parameters.Add("@IMPORTE", objDetalleFactura.Importe);
                cmd.Parameters.Add("@NROFACTURA", objDetalleFactura.FacturaProveedor.NroFactura);
                cmd.Parameters.Add("@CODMEDICAMENTO", objDetalleFactura.Medicamento.CodMedicamento);
                cn.Open();

                resultado = cmd.ExecuteNonQuery() >= 1 ? true : false;

            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return resultado;
        }


    }
}
