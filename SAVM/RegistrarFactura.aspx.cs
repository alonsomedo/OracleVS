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
    public partial class RegistrarFactura : System.Web.UI.Page
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
        public static bool RegistrarFacturaProveedor(string _codFactura,string _fecha,long _ruc, decimal _total)
        {
            bool resultado = false;
            FacturaProveedor objFactura = new FacturaProveedor()
            {
                NroFactura = _codFactura,
                FecFactura = _fecha,
                Proveedor = new Proveedor()
                {
                    RUC = _ruc
                },
                Total = _total

            };

            return resultado = FacturaLN.GetInstance().RegistrarFacturaProveedor(objFactura);
        }

        [WebMethod]
        public static bool RegistrarDetalleFacturaProveedor(decimal _precio, int _cantidad, decimal _importe, string _nroFactura, string _codMedicamento)
        {
            bool resultado = false;
            DetalleFacturaProveedor objDetalleFactura = new DetalleFacturaProveedor()
            {
                FacturaProveedor = new FacturaProveedor()
                {
                    NroFactura = _nroFactura
                },
                PreUnitario = _precio,
                Cantidad = _cantidad,
                Importe = _importe,
                Medicamento = new Medicamento()
                {
                    CodMedicamento = _codMedicamento
                }

            };

            return resultado = FacturaLN.GetInstance().RegistrarDetalleFacturaProveedor(objDetalleFactura);
        }

    }
}