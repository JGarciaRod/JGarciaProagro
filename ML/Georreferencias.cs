using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Georreferencias
    {
        public int IdGeorreferencias { get; set; }
        public ML.Estado Estado { get; set; }
        public double? Latitud { get; set; }
        public double? Longitud { get; set; }
        public List<object> ListGeorreferencias { get; set; }
    }
}
