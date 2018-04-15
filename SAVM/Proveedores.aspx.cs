using Capa_Entidades;
using Capa_Negocio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SAVM
{
    public partial class Proveedores : System.Web.UI.Page
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
                if (idRolUsuario == 3)
                {
                    Response.Redirect("Index.aspx");
                }

            }
        }

        [WebMethod]
        public static List<RepProveedor> ListarRepProveedores()
        {
            List<RepProveedor> Lista = null;
            Lista = ProveedorLN.GetInstance().ListarRepProveedores();
            return Lista;
        }

        [WebMethod]
        public static string CalcularIncidentesProveedor(long _ruc)
        {
            string incidentes = "0";
            Proveedor objProveedor = new Proveedor()
            {
                RUC = _ruc
            };
            incidentes = ProveedorLN.GetInstance().CalcularIncidentesProveedor(objProveedor);

            return incidentes;
        }


        [WebMethod]
        public static Proveedor RegistrarProveedor(string razonsocial, string ruc, string direccion, string correo, string nombre, string paterno, string materno, string telefono)
        {
            Proveedor objProveedor = new Proveedor()
            {
                RazonSocial = razonsocial,
                Direccion = direccion,
                RUC = long.Parse(ruc),
                Estado = '1',
                Representante = new RepProveedor()
                {
                    Correo = correo,
                    Nombre = nombre,
                    Paterno = paterno,
                    Materno = materno,
                    Telefono = telefono
                }

            };
            return objProveedor = ProveedorLN.GetInstance().RegistrarProveedor(objProveedor);
        }
        [WebMethod]
        public static void EliminarProveedor(string ruc)
        {
            Proveedor objProveedor = new Proveedor()
            {
                RUC = long.Parse(ruc)
            };

            ProveedorLN.GetInstance().EliminarProveedor(objProveedor);


        }

    }
    
}