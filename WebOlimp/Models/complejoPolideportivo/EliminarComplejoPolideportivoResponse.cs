using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.complejoPolideportivo
{
    public class EliminarComplejoPolideportivoResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public EliminarComplejoPolideportivoResponse_Ok data { get; set; }
        public EliminarComplejoPolideportivoResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class EliminarComplejoPolideportivoResponse_Ok
    {
        public string Message { get; set; }

    }
    public class EliminarComplejoPolideportivoResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}