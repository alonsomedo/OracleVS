using Capa_Entidades;
using Capa_Negocio;
using System.Web.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAVM
{
    public partial class ConsultarIncidente : System.Web.UI.Page
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
                if ( idRolUsuario == 3||idRolUsuario ==2)
                {
                    Response.Redirect("Index.aspx");
                }
                
            }
        }

        [WebMethod]
        public static List<IncidenteProveedor> ListarIncidentes()
        {
            List<IncidenteProveedor> Lista = null;

            Lista = IncidenteLN.GetInstance().ListarIncidentes();

            return Lista;

        }
    }
}