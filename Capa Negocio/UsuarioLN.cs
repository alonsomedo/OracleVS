using Capa_Datos;
using Capa_Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Negocio
{
    public class UsuarioLN
    {
		#region PATRON SINGLETON
		private static UsuarioLN ObjEmpleado = null;
		private UsuarioLN() { }
		public static UsuarioLN GetInstance()
		{
			if (ObjEmpleado == null)
			{
				ObjEmpleado = new UsuarioLN();
			}
			return ObjEmpleado;
		}
		#endregion

		public Usuario AccesoSistema(String usuario, String clave)
		{
			try
			{
				return UsuarioDAO.GetInstance().AccesoSistema(usuario, clave);
			}
			catch (Exception ex)
			{
				throw ex;
			}

		}
	}
}
