using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class DetalleVenta
    {
        public int IdDetalle { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public Venta Venta { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}
