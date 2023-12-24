using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebOlimp.Models.sede
{
    public class CrearSedeRequest
    {
        public string nombre_sede { get; set; }
        public int numero_complejos { get; set; }
        public decimal presupuesto { get; set; }
        public bool estado { get; set; }
    }
}