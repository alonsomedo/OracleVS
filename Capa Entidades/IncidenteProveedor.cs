using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capa_Entidades
{
    public class IncidenteProveedor
    {
        public string CodIncPro { get; set; }
        public string FecIncidente { get; set; }
        public string Descripcion { get; set; }
        public long RucPro { get; set; }
        public TipoIncidencia TipoIncidencia { get; set; }
        public Proveedor Proveedor { get; set; }
    }
}
