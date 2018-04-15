using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Venta
    {
		public int IdVenta { get; set; }
		public string CodVenta { get; set; }
		public string FecVenta { get; set; }
		public decimal Igv { get; set; }
		public decimal Total { get; set; }
		public Usuario Usuario { get; set; }
	}
}
