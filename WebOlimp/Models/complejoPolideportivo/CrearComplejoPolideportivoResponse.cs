using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.complejoPolideportivo
{
    public class CrearComplejoPolideportivoResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public CrearComplejoPolideportivoResponse_Ok data { get; set; }
        public CrearComplejoPolideportivoResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class CrearComplejoPolideportivoResponse_Ok
    {
        public string Message { get; set; }
        public int id_complejo_poli { get; set; }

    }
    public class CrearComplejoPolideportivoResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}