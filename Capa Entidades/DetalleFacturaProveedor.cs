using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
	public class DetalleFacturaProveedor
	{
		public int IdDetalle { get; set; }
		public decimal PreUnitario { get; set; }
		public int Cantidad { get; set; }
		public decimal Importe { get; set; }
		public FacturaProveedor FacturaProveedor { get; set; }
		public Medicamento Medicamento { get; set; }
	}
}
