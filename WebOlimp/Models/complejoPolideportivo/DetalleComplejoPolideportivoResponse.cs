using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.complejoPolideportivo
{
    public class DetalleComplejoPolideportivoResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public DetalleComplejoPolideportivoResponse_Ok data { get; set; }
        public DetalleComplejoPolideportivoResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class DetalleComplejoPolideportivoResponse_Ok
    {
        public string Message { get; set; }
        public ItemComplejoPolideportivoDetalle data { get; set; }
    }
    public class ItemComplejoPolideportivoDetalle
    {
        public int id_complejo_poli { get; set; }
        public int id_sede { get; set; }
        public string cod_complejo_poli { get; set; }
        public string nombre_complejo_poli { get; set; }
        public Nullable<bool> estado { get; set; }
    }

    public class DetalleComplejoPolideportivoResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}