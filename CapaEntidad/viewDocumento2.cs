using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaEntidad
{
   public class viewDocumento2
    {
        public string secuencia { get; set; }
        public string nombre { get; set; }
        public string nombreUsuario { get; set; }
        public string Departamento_Origen { get; set; }
        public string Departamento_Destino { get; set; }
        public Nullable<System.DateTime> fechaDocumento { get; set; }
    }
}
