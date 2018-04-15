using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using Capa_Entidades;
using Capa_Negocio;

namespace SAVM
{
	public partial class RegistrarIncidente : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
            if (Session["usuario"] == null)
            {
                Response.Redirect("Login.aspx");
            }
            else if (Session["usuario"] != null)
            {
                int idRolUsuario = Convert.ToInt32(Session["perfilUsuario"]);
                if (idRolUsuario == 3 || idRolUsuario == 2)
                {
                    Response.Redirect("Index.aspx");
                }

            }
        }

        [WebMethod]
        public static List<TipoIncidencia> ListarTipoIncidente()
        {
            List<TipoIncidencia> Lista = null;

            Lista = IncidenteLN.GetInstance().ListarTipoIncidente();

            return Lista;

        }
        [WebMethod]
        public static string RegistrarIncidenteProveedor(string ruc, string tipoincidencia, string fecha, string desIncidente)
        {
            bool resultado = false;
            IncidenteProveedor objIncidente = new IncidenteProveedor()
            {
                RucPro = long.Parse(ruc),
                FecIncidente = fecha,
                Descripcion = desIncidente.Trim(),
                TipoIncidencia = new TipoIncidencia()
                {
                    Descripcion = tipoincidencia
                }

            };

            resultado = IncidenteLN.GetInstance().RegistrarIncidenteProveedor(objIncidente);
            return resultado == true ? "Correcto" : "Incorrecto";

        }

      

    }
}