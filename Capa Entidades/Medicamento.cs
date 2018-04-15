using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Medicamento
    {
		public string CodMedicamento { get; set; }
		public string Descripcion { get; set; }
        public decimal PrecioCompra { get; set; }
        public decimal PrecioVenta { get; set; }
        public int Stock { get; set; }
        public int StockMinimo { get; set; }
        public string FechaVencimiento { get; set; }
        public TipoMedicamento TipoMedicamento { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
