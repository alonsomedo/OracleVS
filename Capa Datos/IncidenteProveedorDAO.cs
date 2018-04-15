using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using System.Data;
using Oracle.ManagedDataAccess.Client;

namespace Capa_Datos
{
    public class IncidenteProveedorDAO
    {
        #region "PATRON SINGLETON"
        private static IncidenteProveedorDAO DaoIncidente = null;
        private IncidenteProveedorDAO() { }
        public static IncidenteProveedorDAO GetInstance()
        {
            if (DaoIncidente == null)
            {
                DaoIncidente = new IncidenteProveedorDAO();
            }
            return DaoIncidente;
        }
        #endregion

        public List<TipoIncidencia> ListarTipoIncidente()
        {
            OracleConnection cn = null;
            OracleDataReader dr = null;
            OracleCommand cmd = null;
            List<TipoIncidencia> lista = new List<TipoIncidencia>();
            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_LISTATIPOINCIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    TipoIncidencia ObjTipoIncidencia = new TipoIncidencia()
                    {
                        Descripcion = Convert.ToString(dr[0])

                    };
                    lista.Add(ObjTipoIncidencia);
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            finally
            {
                cn.Close();
            }
            return lista;
        }


        public bool RegistrarIncidenteProveedor(IncidenteProveedor objIncidente )
        {
            bool resultado = false;
            OracleConnection cn = null;
            OracleCommand cmd = null;

            try
            {
                cn = Conexion.GetInstance().ConexionDB();

                cmd = new OracleCommand("SP_REGISTRARINCIDENTE", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@RUC", objIncidente.RucPro);
                cmd.Parameters.Add("@DESCRIPCION", objIncidente.Descripcion);
                cmd.Parameters.Add("@TIPOINCIDENTE", objIncidente.TipoIncidencia.Descripcion);
                cmd.Parameters.Add("@FECHA", objIncidente.FecIncidente);
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

        public List<IncidenteProveedor> ListarIncidentes()
        {
            OracleConnection cn = null;
            OracleCommand cmd = null;
            OracleDataReader dr = null;
            List<IncidenteProveedor> Lista = new List<IncidenteProveedor>();

            try
            {
                cn = Conexion.GetInstance().ConexionDB();
                cmd = new OracleCommand("SP_LISTARINCIDENTES", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cn.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    IncidenteProveedor objIncidentes = new IncidenteProveedor()
                    {
                        Proveedor = new Proveedor()
                        {
                            RUC = long.Parse(dr[0].ToString()),
                            RazonSocial = dr[1].ToString(),
                        },
                        Descripcion = dr[2].ToString(),
                        TipoIncidencia = new TipoIncidencia()
                        {
                            Descripcion = dr[3].ToString()
                        },
                        FecIncidente = Convert.ToDateTime(dr[4].ToString()).ToShortDateString()

                    };
                    Lista.Add(objIncidentes);
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
            return Lista;
        }
    }
}
