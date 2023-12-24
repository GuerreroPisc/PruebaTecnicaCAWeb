using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.maestro
{
    public class ListadoMaestroResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public ListadoMaestroResponse_Ok data { get; set; }
        public ListadoMaestroResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class ListadoMaestroResponse_Ok
    {
        public string Message { get; set; }
        public List<ItemMaestroSede> data { get; set; }
    }
    public class ItemMaestroSede
    {
        public int id_sede { get; set; }
        public string cod_sede { get; set; }
        public string nombre_sede { get; set; }
    }

    public class ListadoMaestroResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}