using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Permisos
    {
        public ML.Usuario Usuario { get; set; }
        public ML.Estado Estado { get; set; }
        public List<object> ListPermisos { get; set; }
        public bool Update { get; set; }
    }
}
