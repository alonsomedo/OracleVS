using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class DetalleOrdenCompra
    {
        public int IdDetalle { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public decimal Subtotal { get; set; }
        public OrdenCompra OrdenCompra { get; set; }
        public Medicamento Medicamento { get; set; }
    }
}