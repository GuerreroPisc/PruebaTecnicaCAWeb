using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebOlimp.Models.complejoPolideportivo
{
    public class CrearComplejoPolideportivoRequest
    {
        public int id_sede { get; set; }
        public string nombre_complejo_poli { get; set; }
        public bool estado { get; set; }
    }
}