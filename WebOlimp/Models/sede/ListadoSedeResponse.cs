using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.sede
{
    public class ListadoSedeResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public ListadoSedeResponse_Ok data { get; set; }
        public ListadoSedeResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class ListadoSedeResponse_Ok
    {
        public string Message { get; set; }
        public List<ItemSede> data { get; set; }
    }
    public class ItemSede
    {
        public int id_sede { get; set; }
        public string cod_sede { get; set; }
        public string nombre_sede { get; set; }
        public Nullable<int> numero_complejos { get; set; }
        public Nullable<decimal> presupuesto { get; set; }
        public Nullable<bool> estado { get; set; }
        public string fecha_actualizacion { get; set; }
    }

    public class ListadoSedeResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}