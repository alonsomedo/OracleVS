using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAVM
{
    public partial class ReporteMedicamentoVencimiento : System.Web.UI.Page
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
    }
}