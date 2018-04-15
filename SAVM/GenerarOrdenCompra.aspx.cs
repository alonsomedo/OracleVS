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
	public partial class GenerarOrdenCompra : System.Web.UI.Page
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
		public static string GenerarNroOC()
		{
			string resultado = "";

			resultado = OrdenCompraLN.GetInstance().GenerarNroOC();

			return resultado;
		}

		[WebMethod]
		public static string RegistrarOC(string _CodOc, string _FecOC, decimal _Igv, decimal _Total, long _Ruc)
		{
			bool resultado = false;

			OrdenCompra obj = new OrdenCompra()
			{
				CodOrdCompra = _CodOc,
				FecOrdCompra = _FecOC,
				Igv = _Igv,
				Total = _Total,
				Proveedor = new Proveedor()
				{
					RUC = _Ruc
				}
			};
			resultado = OrdenCompraLN.GetInstance().RegistrarOC(obj);

			return resultado == true ? "Correcto" : "Incorrecto";
		}

		[WebMethod]
		public static string RegistrarDetalleOC(decimal _precio, int _cantidad, decimal _subtotal, string _codmedicamento, string _codoc)
		{
			bool resultado = false;

			DetalleOrdenCompra obj = new DetalleOrdenCompra()
			{
				Precio = _precio,
				Cantidad = _cantidad,
				Subtotal = _subtotal,
				Medicamento = new Medicamento()
				{
					CodMedicamento = _codmedicamento
				},
				OrdenCompra = new OrdenCompra()
				{
					CodOrdCompra = _codoc
				}
			};
			resultado = OrdenCompraLN.GetInstance().RegistrarDetalleOC(obj);

			return resultado == true ? "Correcto" : "Incorrecto";
		}

	}
}