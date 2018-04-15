using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
	public class ProveedorLN
	{
		#region "PATRON SINGLETON"
		private static ProveedorLN objLN = null;
		private ProveedorLN() { }
		public static ProveedorLN GetInstance()
		{
			if (objLN == null)
			{
				objLN = new ProveedorLN();
			}
			return objLN;
		}
		#endregion

		public List<RepProveedor> ListarRepProveedores()
		{
			try
			{
				return ProveedorDAO.GetInstance().ListarRepProveedores();
			}
			catch (Exception ex)
			{
				throw ex;
			}
		}
        public string CalcularIncidentesProveedor(Proveedor objProveedor)
        {
            try
            {
                return ProveedorDAO.GetInstance().CalcularIncidentesProveedor(objProveedor);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public Proveedor RegistrarProveedor(Proveedor objProveedor)
        {
            try
            {
                return ProveedorDAO.GetInstance().RegistrarProveedor(objProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void EliminarProveedor(Proveedor objProveedor)
        {
            try
            {
                ProveedorDAO.GetInstance().EliminarProveedor(objProveedor);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
