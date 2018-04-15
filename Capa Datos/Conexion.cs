using System;
using System.Collections.Generic;
using Oracle.ManagedDataAccess.Client;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Datos
{
	public class Conexion
	{
		#region "PATRON SINGLETON"
		private static Conexion conexion = null;

		private Conexion() { }
		public static Conexion GetInstance()
		{
			if (conexion == null)
			{
				conexion = new Conexion();
			}
			return conexion;
		}
		#endregion

		//public OracleConnection ConexionDB()
		//{
		//	OracleConnection cn = new OracleConnection(ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
		//	return cn;
		//}

		public OracleConnection ConexionDB()
        {

            //OracleConnection cn = new
            //    OracleConnection(@"server = 192.168.1.60; Initial Catalog=MUNDOFARMA_BD; user id=admin;password=admin");
            OracleConnection cn = new
            OracleConnection(@"Data Source = 192.168.1.65:1521 /oracle; User Id = system; Password = oracle");

            return cn;
        }
	}
}
