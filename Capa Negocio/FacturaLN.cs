using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Capa_Entidades;
using Capa_Datos;

namespace Capa_Negocio
{
    public class FacturaLN
    {
        #region "PATRON SINGLETON"
        private static FacturaLN objFactura = null;
        private FacturaLN() { }
        public static FacturaLN GetInstance()
        {
            if (objFactura == null)
            {
                objFactura = new FacturaLN();
            }
            return objFactura;
        }

        #endregion

        public bool RegistrarFacturaProveedor(FacturaProveedor objFactura)
        {
            try
            {
                return FacturaProveedorDAO.GetInstance().RegistrarFacturaProveedor(objFactura);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public bool RegistrarDetalleFacturaProveedor(DetalleFacturaProveedor objDetalleFactura)
        {
            try
            {
                return FacturaProveedorDAO.GetInstance().RegistrarDetalleFacturaProveedor(objDetalleFactura);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
