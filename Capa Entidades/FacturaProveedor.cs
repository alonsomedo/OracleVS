using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
	public class FacturaProveedor
	{
		public string NroFactura { get; set; }
		public string FecFactura { get; set; }
		public decimal Total { get; set; }
		public Proveedor Proveedor { get; set; }
	}
}
