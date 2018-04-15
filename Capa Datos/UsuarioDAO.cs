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
    public class UsuarioDAO
    {
        #region "PATRON SINGLETON"
        private static UsuarioDAO DaoUsuario = null;

        private UsuarioDAO() { }
        public static UsuarioDAO GetInstance()
        {
            if (DaoUsuario == null)
            {
                DaoUsuario = new UsuarioDAO();
            }
            return DaoUsuario;
        }
        #endregion

        public Usuario AccesoSistema(String usuario, String clave)
        {
            OracleConnection cn = null;
            OracleCommand cmd = null;
            Usuario objUsuario = null;
            OracleDataReader dr = null;

            try
            {
                cn = Conexion.GetInstance().ConexionDB();

                cmd = new OracleCommand("SP_ACCESOSISTEMA", cn);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.Add("@username", usuario);
                cmd.Parameters.Add("@password", clave);
                cn.Open();
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    objUsuario = new Usuario()
                    {
                        Username = dr[0].ToString(),
                        Pass = dr[1].ToString(),
                        RolUsuario = new RolUsuario()
                        {
                            IdRolUsuario = Convert.ToInt32(dr[2].ToString()),
                            Descripcion = dr[3].ToString()

                        }
                    };

                }
            }
            catch (OracleException ex)
            {
                objUsuario = null;
                throw ex;
            }
            finally
            {
                cn.Close();
            }

            return objUsuario;

        }
    }
}
