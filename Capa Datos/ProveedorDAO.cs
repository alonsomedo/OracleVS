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
    public class ProveedorDAO
    {
        #region "PATRON SINGLETON"
        private static ProveedorDAO objDAO = null;
        private ProveedorDAO() { }
        public static ProveedorDAO GetInstance()
        {
            if (objDAO == null)
            {
                objDAO = new ProveedorDAO();
            }
            return objDAO;
        }
        #endregion

        public List<RepProveedor> ListarRepProveedores()
        {
            List<RepProveedor> lista = new List<RepProveedor>();

            OracleConnection cn = null;
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_LISTARPROVEEDORES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();

                while (dr.Read())
                {
                    RepProveedor obj = new RepProveedor()
                    {
                        Nombre = Convert.ToString(dr[0]),
                        Paterno = Convert.ToString(dr[1]),
                        Materno = Convert.ToString(dr[2]),
                        Telefono = Convert.ToString(dr[3]),
                        Correo = Convert.ToString(dr[4]),
                        Proveedor = new Proveedor()
                        {
                            RUC = Convert.ToInt64(dr[5]),
                            RazonSocial = Convert.ToString(dr[6]),
                            Direccion = Convert.ToString(dr[7]),
                        }
                    };
                    lista.Add(obj);
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

        public string CalcularIncidentesProveedor(Proveedor objProveedor)
        {
            OracleConnection cn = null;
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            string nroincidentes = "";
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_INCIDENTESPROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@NRORUC", objProveedor.RUC);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    nroincidentes = dr[0].ToString();
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
            return nroincidentes;
        }

        public Proveedor RegistrarProveedor(Proveedor objProveedor)
        {
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            OracleConnection cn = null;
            Proveedor Proveedor = new Proveedor();
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_REGISTRARPROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RAZSOCIAL", objProveedor.RazonSocial);
                cmd.Parameters.Add("@RUC", objProveedor.RUC);
                cmd.Parameters.Add("@DIRECCION", objProveedor.Direccion);
                cmd.Parameters.Add("@ESTADO", objProveedor.Estado);
                //Representante Proveedor
                cmd.Parameters.Add("@CORREO", objProveedor.Representante.Correo);
                cmd.Parameters.Add("@NOMBRE", objProveedor.Representante.Nombre);
                cmd.Parameters.Add("@PATERNO", objProveedor.Representante.Paterno);
                cmd.Parameters.Add("@MATERNO", objProveedor.Representante.Materno);
                cmd.Parameters.Add("@TELEFONO", objProveedor.Representante.Telefono);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    
                    {

                        Proveedor.RUC = Convert.ToInt64(dr[0]);
                        Proveedor.RazonSocial = Convert.ToString(dr[1]);
                        Proveedor.Direccion = Convert.ToString(dr[2]);
                        Proveedor.Representante = new RepProveedor()
                        {

                            Nombre = Convert.ToString(dr[3]),
                            Paterno = Convert.ToString(dr[4]),
                            Materno = Convert.ToString(dr[5]),
                            Telefono = Convert.ToString(dr[6]),
                            Correo = Convert.ToString(dr[7]),
                        };

                    };
                }
                return Proveedor;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }

        public void EliminarProveedor(Proveedor objProveedor)
        {
            OracleConnection cn = null;
            OracleCommand cmd = null;
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_ELIMINARPROVEEDOR", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RUC", objProveedor.RUC);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
        }


    }
}
