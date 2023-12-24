using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;

namespace WebOlimp.Models.sede
{
    public class EliminarSedeResponse
    {
        public HttpStatusCode codeHTTP { get; set; }
        public string messageHTTP { get; set; }
        public EliminarSedeResponse_Ok data { get; set; }
        public EliminarSedeResponse_BadRequestYOtros data_badquest_otros { get; set; }
    }
    public class EliminarSedeResponse_Ok
    {
        public string Message { get; set; }

    }
    public class EliminarSedeResponse_BadRequestYOtros
    {
        public string Message { get; set; }
    }
}