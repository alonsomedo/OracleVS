using Capa_Entidades;
using Capa_Negocio;
using System;
using System.Web.Services;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAVM
{
	public partial class Login : System.Web.UI.Page
	{
		protected void Page_Load(object sender, EventArgs e)
		{
		
		}

		protected void BtnIngreso_Click(object sender, EventArgs e)
		{
			Usuario ObjEmpleado = new Usuario();

			ObjEmpleado = UsuarioLN.GetInstance().AccesoSistema(Username.Text, Password.Text);


			if (ObjEmpleado != null)
			{
				Session["usuario"] = ObjEmpleado.Username;
                Session["perfilUsuario"] = ObjEmpleado.RolUsuario.IdRolUsuario;
                Response.Redirect("Index.aspx");
			}
			else
			{
				Response.Write("<script>alert('Verifique su usuario y contraseña')</script>");
			}
		}
        [WebMethod]
        public static bool CerrarSesion()
        {
            HttpContext.Current.Session.Abandon();
            return true;
        }


    }
}