using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
	public class RepProveedor
	{
		public int IdRepPro { get; set; }
		public string Nombre { get; set; }
		public string Paterno { get; set; }
		public string Materno { get; set; }
		public string Telefono { get; set; }
		public string Correo { get; set; }
		public Proveedor Proveedor { get; set; }
	}
}
