﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ML
{
    public class Usuario
    {
        public int IdUsuario { get; set; }
        public string Passwoord { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaIngreso { get; set; }
        public string RFC { get; set; }

        public List<object> Usuarios { get; set; }
    }
}
