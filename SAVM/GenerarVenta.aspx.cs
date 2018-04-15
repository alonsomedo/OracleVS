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
	public partial class GenerarVenta : System.Web.UI.Page
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
                if (idRolUsuario == 2 || idRolUsuario == 4)
                {
                    Response.Redirect("Index.aspx");
                }

            }
        }

		[WebMethod]
		public static string RegistrarVenta(string _Codventa, string _FecVenta, decimal _Igv, decimal _Total)
		{
			string usuario = HttpContext.Current.Session["usuario"].ToString();
			bool resultado = false;

			Venta venta = new Venta()
			{
				CodVenta = _Codventa,
				FecVenta = _FecVenta,
				Igv = _Igv,
				Total = _Total,
				Usuario = new Usuario()
				{
					Username = usuario
				}
			};

			resultado = VentaLN.GetInstance().RegistrarVenta(venta);

			return resultado == true ? "Correcto" : "Incorrecto";
		}
		[WebMethod]
		public static string RegistrarDetalleVenta(decimal _precio, int _cantidad, decimal _subtotal, string _codmedicamento, string _codventa)
		{
			bool resultado = false;
			DetalleVenta detalle = new DetalleVenta()
			{
				Precio = _precio,
				Cantidad = _cantidad,
				Subtotal = _subtotal,
				Medicamento = new Medicamento()
				{
					CodMedicamento = _codmedicamento
				},
				Venta = new Venta()
				{
					CodVenta = _codventa
				}
			};

			resultado = VentaLN.GetInstance().RegistrarDetalleVenta(detalle);

			return resultado == true ? "Correcto" : "Incorrecto";
		}

		[WebMethod]
		public static string GenerarNroVenta()
		{
			string resultado = "";

			resultado = VentaLN.GetInstance().GenerarNroVenta();

			return resultado;
		}

	}
}