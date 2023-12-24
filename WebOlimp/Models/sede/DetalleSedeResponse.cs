using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.sede
{
    public class DetalleSedeResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public DetalleSedeResponse_Ok data { get; set; }
        public DetalleSedeResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class DetalleSedeResponse_Ok
    {
        public string Message { get; set; }
        public ItemSedeDetalle data { get; set; }
    }
    public class ItemSedeDetalle
    {
        public int id_sede { get; set; }
        public string cod_sede { get; set; }
        public string nombre_sede { get; set; }
        public Nullable<int> numero_complejos { get; set; }
        public Nullable<decimal> presupuesto { get; set; }
        public Nullable<bool> estado { get; set; }
    }

    public class DetalleSedeResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}