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
    public partial class Medicamentos : System.Web.UI.Page
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
                if (idRolUsuario == 3 || idRolUsuario == 4)
                {
                    Response.Redirect("Index.aspx");
                }

            }

        }
        [WebMethod]
        public static List<Medicamento> ListarMedicamento()
        {
            List<Medicamento> Lista = null;
            Lista = MedicamentoLN.GetInstance().ListarMedicamento();
            return Lista;
        }
        [WebMethod]
        public static bool RegistrarMedicamento(string codmedicamento, string medicamento, decimal preComUni, decimal preVenUni, int stock, int stockminimo, string fechaVencimiento, string tipoMedicamento, long proveedor)
        {
            
            Medicamento objMedicamento = new Medicamento()
            {
                CodMedicamento = codmedicamento,
                Descripcion = medicamento,
                PrecioCompra = preComUni,
                PrecioVenta = preVenUni,
                Stock = stock,
                StockMinimo = stockminimo,
                FechaVencimiento = fechaVencimiento,
                TipoMedicamento = new TipoMedicamento()
                {
                    Descripcion = tipoMedicamento
                },
                Proveedor = new Proveedor()
                {
                    RUC = proveedor
                }

            };
            return MedicamentoLN.GetInstance().RegistrarMedicamento(objMedicamento);
        }

        [WebMethod]
        public static List<TipoMedicamento> ListarTipoMedicamento()
        {
            List<TipoMedicamento> Lista = null;

            Lista = MedicamentoLN.GetInstance().ListarTipoMedicamento();

            return Lista;

        }



    }
}