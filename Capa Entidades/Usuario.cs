using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class Usuario
    {
        public string Username { get; set; }
        public string Pass { get; set; }
		public string Nombre { get; set; }
		public string Paterno { get; set; }
		public string Materno { get; set; }
		public long Dni { get; set; }
		public bool Estado { get; set; }
		public RolUsuario RolUsuario { get; set; }
    }
}
